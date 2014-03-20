using System.Collections.Generic;
using Mysoft.Business.Controls;
using Mysoft.Common.Extensions;
using Mysoft.Business.Validation.Entity;
using System;

namespace Mysoft.Business.Validation.Controls
{
    /// <summary>
    /// 不支持function节点的配置检测
    /// </summary>
    public class AppFormValidation : AppValidationBase
    {
        public override void Validate(AppControl control)
        {
            AppForm form = control.Control as AppForm;
            if (form == null) return;  //不是grid

            List<string> fields = GetFields(control.DataSource.Sql);

            foreach (AppFormTab tab in form.Tabs)
            {
                foreach (AppFormSection section in tab.Sections)
                {
                    foreach (AppFormItem item in section.Items)
                    {
                        string field = string.IsNullOrEmpty(item.Name) ? item.Field : item.Name;

                        if (string.IsNullOrEmpty(field))
                        {
                            //AddResult(string.Format("{0}未设置item控件名，请设置field或name的值，否则控件将自动命名为Unnamed+数字", item.Title), Level.Warn);
                            field = string.Format("tab:{0}, section: {1},", tab.Title, section.Title);
                        }

                        ValidateReq(item.Req, field);
                        ValidateCreateapi(item.Createapi, field);
                        ValidateUpdateapi(item.Updateapi, field);

                        if (item.Type.EqualIgnoreCase(AppFormItemType.Datetime.ToString()))
                        {
                            ValidateTime(item.Time, field);
                        }

                        if (item.Type.EqualIgnoreCase(AppFormItemType.Select.ToString()))
                        {
                            if (!string.IsNullOrEmpty(item.Sql))
                            {
                                string error = "";
                                if (ValidateSql(item.Sql, out error) == false)
                                {
                                    AddResult(field, "sql", "正确执行", error, Level.Error);
                                }
                            }
                        }

                        if (control.DataSource.IsSqlPassed)
                        {
                            if (!fields.Contains(item.Field) && !string.IsNullOrEmpty(item.Field))
                            {
                                Results.Add(new Result("字段配置错误", "SQL中未包含列" + item.Field, Level.Error,
                                                       typeof (AppFormValidation)));
                            }
                        }

                        ValidateAttribute(item.OtherAttributes, item.Title);

                        ValidateValue(item.Type, item.DefaultValue, item.Title);
                    }
                }
            }
        }

        private void ValidateValue(string itemType, string value, string title)
        {
            if(string.IsNullOrEmpty(value)) return;

            AppFormItemType type = (AppFormItemType)Enum.Parse(typeof(AppFormItemType), itemType);
            switch (type)
            {
                //case AppFormItemType.Text:
                //    break;
                //case AppFormItemType.Memo:
                //    break;
                //case AppFormItemType.Password:
                //    break;
                case AppFormItemType.Number:
                    if(!value.IsNumber())
                    {
                        Results.Add(new Result("字段默认值配置错误", string.Format("{0}的defaultvalue期望值为[数字类型]，实际值：{1}", title, value), Level.Error, typeof(AppFormValidation)));
                    }
                    break;
                case AppFormItemType.Datetime:
                    break;
                //case AppFormItemType.Radio:
                //    break;
                //case AppFormItemType.Select:
                //    break;
                //case AppFormItemType.Lookup:
                //    break;
                //case AppFormItemType.Hidden:
                //    break;
                //case AppFormItemType.HyperLink:
                //    break;
                //case AppFormItemType.Blank:
                //    break;
                default:
                    return;
            }
        }
    }
}