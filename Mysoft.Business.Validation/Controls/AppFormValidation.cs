using Mysoft.Business.Controls;
using Mysoft.Business.Validation.Entity;

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

            ValidateForm(form);
        }

        private void ValidateForm(AppForm form)
        {
            foreach (AppFormTab tab in form.Tabs)
            {
                foreach (AppFormSection section in tab.Sections)
                {
                    foreach (AppFormItem item in section.Items)
                    {
                        string field = string.IsNullOrEmpty(item.Name) ? item.Field : item.Name;

                        if (string.IsNullOrEmpty(field))
                        {
                            AddResult("未设置控件名，请设置field或name的值，否则控件将自动命名为Unnamed{x}", Level.Warn);
                            field = string.Format("tab:{0}, section: {1},", tab.Title, section.Title);
                        }

                        ValidateReq(item.Req, field);
                        ValidateCreateapi(item.Createapi, field);
                        ValidateUpdateapi(item.Updateapi, field);

                        if (item.Type == AppFormItemType.Datetime)
                        {
                            ValidateTime(item.Time, field);
                        }

                        if (item.Type == AppFormItemType.Select)
                        {
                            if (!string.IsNullOrEmpty(item.Sql))
                            {
                                string error = "";
                                bool b = ValidateSql(item.Sql, out error);
                                if (b == false)
                                {
                                    AddResult(field, "sql", "正确执行", error, Level.Error);
                                }
                            }
                        }

                        ValidateAttribute(item.OtherAttributes);
                    }
                }
            }
        }
    }
}