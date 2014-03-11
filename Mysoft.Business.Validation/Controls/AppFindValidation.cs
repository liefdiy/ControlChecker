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

        private void ValidateFind(AppControl control)
        {
            if (control.Query.Standard == null)
            {
                AddResult("未配置标准查询", Level.Warn);
                return;
            }

            CheckQuery(control.Query.Standard.Items, true);
            CheckQuery(control.Query.Advanced.Items, false);
        }

        private void CheckQuery(List<AppFindQueryItem> items, bool isStandard)
        {
            foreach (AppFindQueryItem item in items)
            {
                AppFormItemType v;
                try
                {
                    //检查枚举值是否被支持
                    v = (AppFormItemType)Enum.Parse(typeof(AppFormItemType), item.Type, true);
                }
                catch (Exception)
                {
                    AddResult(string.Format("{0}字段的type属性值配置错误", item.Field), Level.Error);
                    return;
                }

                if (!string.IsNullOrEmpty(item.Sql) && v != AppFormItemType.Select)
                {
                    AddResult(string.Format("{0}字段的SQL属性无效，仅高级查询的select子控件支持", item.Field), Level.Warn);
                }

                string time = GetOtherAttribute(item, "time");
                if (!string.IsNullOrEmpty(time) && v == AppFormItemType.Datetime)
                {
                    ValidateTime(time, item.Field);
                }

                if (isStandard)
                {
                    if ((v == AppFormItemType.Text || v == AppFormItemType.Number || v == AppFormItemType.Datetime ||
                         v == AppFormItemType.Lookup) == false)
                    {
                        AddResult(string.Format("标准查询/{0}字段的type值无效，仅支持text,number,datetime,lookup", item.Field), Level.Warn);
                    }
                }
                else
                {
                    if ((v == AppFormItemType.Text || v == AppFormItemType.Number || v == AppFormItemType.Datetime ||
                         v == AppFormItemType.Lookup || v == AppFormItemType.Select) == false)
                    {
                        AddResult(string.Format("高级查询/{0}字段的type值无效，仅支持text,number,datetime,lookup,select", item.Field), Level.Warn);
                    }

                    //select控件
                    if (!string.IsNullOrEmpty(item.Sql))
                    {
                        if (v == AppFormItemType.Select)
                        {
                            string error = "";
                            if (ValidateSql(item.Sql, out error) == false)
                            {
                                AddResult("Sql错误：" + error, Level.Error);
                            }
                        }
                    }
                }
            }
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