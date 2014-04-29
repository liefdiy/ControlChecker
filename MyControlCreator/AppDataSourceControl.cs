using MyControlCreator.Base;
using Mysoft.Business.Controls;

namespace MyControlCreator
{
    public partial class AppDataSourceControl : AppBaseControl, IAppControl
    {
        public AppDataSourceControl()
        {
            InitializeComponent();
        }

        public AppControl GetControl()
        {
            throw new System.NotImplementedException();
        }

        public void BindControl(AppControl control)
        {
            throw new System.NotImplementedException();
        }
    }
}