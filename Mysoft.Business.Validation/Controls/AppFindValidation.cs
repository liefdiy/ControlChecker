using Mysoft.Business.Controls;
using Mysoft.Business.Validation.Entity;
using Mysoft.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Mysoft.Business.Validation.Controls
{
    internal class AppFindValidation : AppValidationBase
    {
        public override void Validate(AppControl control)
        {
            if (control.Query == null) return;  //不是grid

            ValidateFind(control);
        }

        private bool ValidateFind(AppControl control)
        {
            if (control.Query.Standard == null)
            {
                return AddResult("未配置标准查询", Level.Warn);
            }

            bool val = CheckQuery(control.Query.Standard.Items, true);
            val &= CheckQuery(control.Query.Advanced.Items, false);
            return val;
        }

        private bool CheckQuery(List<AppFindQueryItem> items, bool isStandard)
        {
            foreach (AppFindQueryItem item in items)
            {
                try
                {
                    //检查枚举值是否被支持
                    AppFormItemType v = (AppFormItemType)Enum.Parse(typeof(AppFormItemType), item.Type, true);
                    if (!string.IsNullOrEmpty(item.Sql) && v != AppFormItemType.Select)
                    {
                        AddResult(string.Format("{0}字段的SQL属性无效，仅高级查询的select子控件支持", item.Field), Level.Warn);
                    }

                    string time = GetOtherAttribute(item, "time");
                    if (!string.IsNullOrEmpty(time) && v == AppFormItemType.Datetime)
                    {
                        int t = -1;
                        if (!int.TryParse(time, out t))
                        {
                            AddResult(string.Format("{0}字段的time属性值必须为数字，且仅支持0,1,2", item.Field), Level.Error);
                        }
                        if (t < 0 || t > 2)
                        {
                            AddResult(string.Format("{0}字段的time属性值{1}错误，仅支持0,1,2", item.Field, t), Level.Error);
                        }
                    }

                    if (isStandard)
                    {
                        if ((v == AppFormItemType.Text || v == AppFormItemType.Number || v == AppFormItemType.Datetime ||
                             v == AppFormItemType.Lookup) == false)
                        {
                            return AddResult(string.Format("standard/{0}字段的type值无效，仅支持text,number,datetime,lookup", item.Field), Level.Warn);
                        }
                    }
                    else
                    {
                        if ((v == AppFormItemType.Text || v == AppFormItemType.Number || v == AppFormItemType.Datetime ||
                             v == AppFormItemType.Lookup || v == AppFormItemType.Select) == false)
                        {
                            return AddResult(string.Format("advanced/{0}字段的type值无效，仅支持text,number,datetime,lookup,select", item.Field), Level.Warn);
                        }

                        //select控件
                        if (!string.IsNullOrEmpty(item.Sql))
                        {
                            if (v == AppFormItemType.Select)
                            {
                                try
                                {
                                    CommonValidation.ExecuteSql(item.Sql);
                                }
                                catch (Exception)
                                {
                                    return AddResult(string.Format("{0}字段的SQL错误", item.Field), Level.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return AddResult(string.Format("{0}字段的type属性值配置错误", item.Field), Level.Error);
                }
            }

            return true;
        }

        private bool AddResult(string message, Level level)
        {
            Results.Add(new Result("AppFind", message, level, typeof(AppFindValidation)));
            return false;
        }

        private string GetOtherAttribute(AppFindQueryItem item, string name)
        {
            foreach (XmlAttribute attr in item.OtherAttributes)
            {
                if (attr.Name.EqualIgnoreCase(name))
                {
                    return attr.Value;
                }
            }
            return "";
        }
    }
}