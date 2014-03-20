using System.Xml;

namespace Mysoft.Business.Validation
{
    using ControlCheck.Business.Attributes;
    using Mysoft.Business.Controls;
    using Mysoft.Business.Manager;
    using Mysoft.Business.Validation.Db;
    using Mysoft.Business.Validation.Entity;
    using Mysoft.Common.Extensions;
    using Mysoft.Common.Utility;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;

    public delegate void OnNotifyHandler(object sender, EventArgs e);

    public static class AppValidationManager
    {
        /// <summary>
        /// 枚举类型字典，Key：枚举类，Value: [key: 枚举项text, value: 枚举项value]
        /// </summary>
        private static IDictionary<Type, IDictionary<string, int>> EnumDics = new Dictionary<Type, IDictionary<string, int>>();
        private static readonly object s_locker = new object();
        private static readonly List<Type> s_Validations = new List<Type>();

        public static event OnNotifyHandler OnNotify;

        static AppValidationManager()
        {
            lock (s_locker)
            {
                IEnumerable<Type> types = typeof(AppValidationManager).Assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.IsSubclassOf(typeof(AppValidationBase)))
                    {
                        s_Validations.Add(type);
                    }
                }

                s_Validations.Sort(Comparison);
            }
        }

        private static int Comparison(Type a, Type b)
        {
            object[] ao = a.GetCustomAttributes(typeof(ValidationAttribute), false);
            object[] bo = a.GetCustomAttributes(typeof(ValidationAttribute), false);

            int aorder = 999, border = 999;
            if(ao.Length > 0)
            {
                ValidationAttribute ava = ao[0] as ValidationAttribute;
                if(ava != null) aorder = ava.Order;
            }

            if(bo.Length > 0)
            {
                ValidationAttribute bva = bo[0] as ValidationAttribute;
                if(bva != null) border = bva.Order;
            }

            return aorder.CompareTo(border);
        }

        public static List<PageResult> Validate(string dir)
        {
            if (!Directory.Exists(dir))
            {
                throw new DirectoryNotFoundException("指定ERP站点路径不存在");
            }
            return ValidateFiles(Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories).ToList<string>());
        }

        public static List<Result> ValidateControl(AppControl control)
        {
            List<Result> properties = new List<Result>();
            foreach (Type type in s_Validations)
            {
                IAppValidation validation = Activator.CreateInstance(type) as IAppValidation;
                if (validation != null)
                {
                    validation.Validate(control);
                    List<Result> list = validation.GetResults() as List<Result>;
                    if (list != null)
                    {
                        properties.AddRange(list);
                    }
                }
            }
            return properties;
        }

        public static List<Result> ValidateFields(object mp)
        {
            List<Result> results = new List<Result>();
            PropertyInfo[] properties = mp.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                object[] mapContract = property.GetCustomAttributes(typeof(MapContractAttribute), false);
                object value = property.GetValue(mp, null);
                MapContractAttribute mc = null;
                if (mapContract.Length > 0)
                {
                    mc = mapContract[0] as MapContractAttribute;
                    if ((value == null) && mc.IsRequired)
                    {
                        results.Add(new Result("必须字段未配置", string.Format("{0}字段不能为空，{1}", property.Name, mc.Describe), Level.Error, typeof(AppValidationManager)));
                    }
                    if (mc.PassValid) continue;
                }
                if (property.PropertyType.IsGenericType && (property.PropertyType.GetGenericTypeDefinition() == typeof(List<>)))
                {
                    if (value != null)
                    {
                        int count = Convert.ToInt32(property.PropertyType.GetProperty("Count", BindingFlags.Public | BindingFlags.Instance).GetValue(value, null));
                        for (int i = 0; i < count; i++)
                        {
                            object obj = property.PropertyType.GetProperty("Item").GetValue(value, new object[] { i });
                            try
                            {
                                results.AddRange(ValidateFields(obj));
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
                else if (property.PropertyType.Module.Name.EqualIgnoreCase(typeof(MapContractAttribute).Assembly.ManifestModule.Name) && (value != null))
                {
                    try
                    {
                        results.AddRange(ValidateFields(value));
                    }
                    catch (Exception)
                    {
                    }
                }
                if (mc != null)
                {
                    value = (value == null) ? "" : value.ToString();
                    if (mc.EnumType != null)
                    {
                        int v;
                        //缓存枚举
                        if (!EnumDics.ContainsKey(mc.EnumType))
                        {
                            IDictionary<string, int> dic = new Dictionary<string, int>();
                            FieldInfo[] efields = mc.EnumType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
                            foreach (FieldInfo ef in efields)
                            {
                                object[] attrs = ef.GetCustomAttributes(typeof(XmlEnumAttribute), false);
                                if (attrs.Length > 0)
                                {
                                    XmlEnumAttribute xmlEnum = attrs[0] as XmlEnumAttribute;
                                    if (!string.IsNullOrEmpty(xmlEnum.Name))
                                    {
                                        v = (int)Enum.Parse(mc.EnumType, ef.GetValue(mp).ToString(), true);
                                        dic.Add(xmlEnum.Name.ToLower(), v);
                                    }
                                }
                            }
                            EnumDics.Add(mc.EnumType, dic);
                        }

                        if (mc.EnumValueType == EnumValueType.Value)
                        {
                            //如果配置值对应枚举的value
                            v = -1;
                            if (!int.TryParse(value.ToString(), out v))
                            {
                                results.Add(new Result("配置错误", string.Format("{0}字段值必须为数字，配置值:{1}。{2}", property.Name, value, mc.InvalidMessage), Level.Error, typeof(AppValidationManager)));
                            }
                            else if (Enum.GetName(mc.EnumType, v) == null)
                            {
                                results.Add(new Result("配置错误", string.Format("{0}字段值配置错误:{1}。{2}", property.Name, value, mc.InvalidMessage), Level.Error, typeof(AppValidationManager)));
                            }
                        }
                        else if (!EnumDics[mc.EnumType].ContainsKey(value.ToString().ToLower()))
                        {
                            //配置值对应枚举的text
                            results.Add(new Result("配置错误", string.Format("{0}字段值配置错误:{1}。{2}", property.Name, value, mc.InvalidMessage), Level.Error, typeof(AppValidationManager)));
                        }
                    }
                    else if (!IsValid(mc, value.ToString()))
                    {
                        results.Add(new Result("配置错误", string.Format("{0}字段应为{1}类型，配置值：{2}。{3}", new object[] { property.Name, mc.Type.ToString(), value, mc.InvalidMessage }), Level.Error, typeof(AppValidationManager)));
                    }
                }
            }
            return results;
        }

        public static List<PageResult> ValidateFiles(List<string> files)
        {
            DbAccessManager.Init(AppConfigManager.ConnectionString);

            List<PageResult> pageResults = new List<PageResult>();
            if (files != null)
            {
                int total = files.Count<string>();
                for (int i = 0; i < total; i++)
                {
                    Exception ex;
                    PageResult pr = null;
                    string file = files[i];
                    Notify(string.Format("检测({0}/{1}):{2}", i + 1, total, file));

                    MapPage page = null;

                    try
                    {
                        page = GetPage(file);
                    }
                    catch (Exception exception1)
                    {
                        ex = exception1;
                        if (IsMapXml(file))
                        {
                            pr = GetPageResult("配置文件不规范", ex.Message, file);
                        }
                        else
                        {
                            pr = GetPageResult("忽略文件", "非MAP配置文件。", file, Level.Message);
                        }
                        pageResults.Add(pr);
                    }

                    if (page != null)
                    {
                        pr = new PageResult();

                        try
                        {
                            pr = ValidatePage(page);
                        }
                        catch (Exception exception2)
                        {
                            ex = exception2;
                            pr.Results.Add(new Result("验证执行出错", ex.StackTrace, Level.Warn, typeof(AppValidationManager)));
                        }

                        if (pr.Results.Count > 0)
                        {
                            pageResults.Add(pr);
                        }
                    }
                }
            }
            return pageResults;
        }

        public static PageResult ValidatePage(MapPage mp)
        {
            PageResult page = new PageResult
            {
                Xml = mp.PageXml,
                Results = new List<Result>()
            };
            page.Results.AddRange(ValidateFields(mp));

            foreach (AppControl appControl in mp.Controls)
            {
                page.Results.AddRange(ValidateControl(appControl));
                if (appControl.View != null)
                {
                    page.SubPages = new List<PageResult>();
                    foreach (AppFindViewItem item in appControl.View.AppFindViewItems)
                    {
                        if (item.SubPage != null)
                        {
                            if (page.Xml.EqualIgnoreCase(PathHelper.MapPath(item.XmlUrl)))
                            {
                                page.Results.Add(new Result("坑爹", "视图配置地址指向自己会造成死循环！你们Leader知道吗！", Level.Error, typeof(AppValidationManager)));
                                continue;
                            }
                            page.SubPages.Add(ValidatePage(item.SubPage));
                        }
                    }
                }
            }

            if (mp.SubPages != null)
            {
                foreach (MapPage subPage in mp.SubPages)
                {
                    if (!subPage.PageXml.EqualIgnoreCase(page.Xml))
                    {
                        page.SubPages.Add(ValidatePage(subPage));
                    }
                }
            }
            return page;
        }

        public static bool IsMapXml(string xml)
        {
            bool result = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(xml);
                if (doc.DocumentElement == null) return false;

                result = doc.DocumentElement.Name.EqualIgnoreCase("page");
            }
            catch (Exception)
            {
            }
            return result;
        }

        public static MapPage GetPage(string filepath)
        {
            MapPage page = XmlHelper.XmlDeserializeFromFile<MapPage>(filepath);
            page.PageXml = filepath;
            return page;
        }

        private static PageResult GetPageResult(string title, string message, string xml, Level level = Level.Warn)
        {
            PageResult pr = new PageResult();
            pr.Xml = xml;
            pr.Results.Add(new Result(title, message, level, typeof(AppValidationManager)));
            return pr;
        }

        private static bool IsValid(MapContractAttribute mc, string value)
        {
            switch (mc.Type)
            {
                case FieldType.Number:
                    return (string.IsNullOrEmpty(value) || value.IsNumber());

                case FieldType.Float:
                    return (string.IsNullOrEmpty(value) || value.IsFloat());

                case FieldType.DateTime:
                    return (string.IsNullOrEmpty(value) || value.IsDateTime(""));

                case FieldType.Boolean:
                    return (string.IsNullOrEmpty(value) || value.IsBoolean());

                case FieldType.Custom:
                    {
                        Regex regex = new Regex(mc.Regex);
                        return regex.Match(value).Success;
                    }
            }
            return true;
        }

        private static void Notify(string message)
        {
            if (OnNotify != null)
            {
                OnNotify(message, new EventArgs());
            }
        }
    }
}