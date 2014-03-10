using System.Xml;
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

namespace Mysoft.Business.Validation
{
    public delegate void OnNotifyHandler(object sender, EventArgs e);

    public static class AppValidationManager
    {
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
            }
        }

        /// <summary>
        /// 特殊规则验证，得到验证不通过的结果
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
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
                    if (list == null) continue;
                    properties.AddRange(list);
                    validation.Dispose();
                }
            }

            return properties;
        }

        public static PageResult ValidatePage(MapPage mp)
        {
            PageResult page = new PageResult();
            page.Xml = mp.PageXml;
            page.Results = new List<Result>();

            foreach (AppControl appControl in mp.Controls)
            {
                page.Results.AddRange(ValidateControl(appControl));

                if (appControl.View != null)
                {
                    page.SubPages = new List<PageResult>();

                    //视图
                    foreach (var item in appControl.View.AppFindViewItems)
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

            //子页面
            if (mp.SubPages != null)
            {
                foreach (var subPage in mp.SubPages)
                {
                    if (subPage.PageXml.EqualIgnoreCase(page.Xml)) continue;
                    page.SubPages.Add(ValidatePage(subPage));
                }
            }

            return page;
        }

        public static List<PageResult> Validate(string dir)
        {
            if (!Directory.Exists(dir)) throw new DirectoryNotFoundException("指定ERP站点路径不存在");
            string[] files = Directory.GetFiles(dir, "*.xml", SearchOption.AllDirectories);
            return ValidateFiles(files.ToList());
        }

        public static List<PageResult> ValidateFiles(List<string> files)
        {
            DbAccessManager.Init(AppConfigManager.ConnectionString);
            List<PageResult> pageResults = new List<PageResult>();
            if (files == null) return pageResults;

            int total = files.Count();
            for (int i = 0; i < total; i++)
            {
                string file = files[i];
                Notify(string.Format("检测({0}/{1}):{2}", i + 1, total, file));

                MapPage page = null;
                try
                {
                    page = GetPage(file);
                }
                catch (Exception ex)
                {
                    PageResult pr = null;
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
                    PageResult pr = new PageResult();

                    try
                    {
                        pr = ValidatePage(page);
                    }
                    catch (Exception ex)
                    {
                        pr.Results.Add(new Result("验证执行出错", ex.StackTrace, Level.Warn, typeof(AppValidationManager)));
                    }
                    if (pr.Results.Count > 0)
                    {
                        pageResults.Add(pr);
                    }
                }
            }

            return pageResults;
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

        private static void Notify(string message)
        {
            if (OnNotify != null)
            {
                OnNotify(message, new EventArgs());
            }
        }
    }
}