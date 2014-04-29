using Mysoft.Business.Controls;

namespace MyControlCreator.Base
{
    public interface IAppControl
    {
        AppControl GetControl();

        void BindControl(AppControl control);
    }
}