using MyControlCreator.Base;
using System;
using Mysoft.Business.Controls;

namespace MyControlCreator
{
    public partial class AppFormControl : AppBaseControl, IAppControl
    {
        public AppFormControl()
        {
            InitializeComponent();
        }

        public Mysoft.Business.Controls.AppControl GetControl()
        {
            throw new NotImplementedException();
        }

        public void BindControl(AppControl control)
        {
            throw new NotImplementedException();
        }
    }
}