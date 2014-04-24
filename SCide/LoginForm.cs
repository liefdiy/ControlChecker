using Mysoft.Business.Manager;
using Mysoft.Common.Utility;
using System;
using System.Windows.Forms;

namespace SCide
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    btnOk_Click(null, null);
                }
            };
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AppConfigManager.Setting.User.Password = EncryptionHelper.AesHelper.Encrypt(txbPassword.Text.Trim());
            AppConfigManager.Setting.User.UserName = txbUserName.Text;
            this.Close();
        }
    }
}