using Mysoft.Business.Controls;

namespace Mysoft.Business.Validation.Controls
{
    internal class AppFormValidation : AppValidationBase
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
                    }
                }
            }
        }
    }
}