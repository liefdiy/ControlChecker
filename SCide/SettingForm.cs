using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using Mysoft.Business.Manager;

namespace SCide
{
    public partial class SettingForm : Form
    {
        private SynchronizationContext context;

        public SettingForm()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
        }

        protected override void OnLoad(EventArgs e)
        {
            txbDb.Text = AppConfigManager.Setting.Db.Database;
            txbUserId.Text = AppConfigManager.Setting.Db.UserId;
            txbPwd.Text = AppConfigManager.Setting.Db.Password;
            txbServer.Text = AppConfigManager.Setting.Db.Server;
            base.OnLoad(e);
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            string connstring = string.Format("Server={0};database={1};user id={2};password={3}", 
                txbServer.Text, 
                txbDb.Text,
                txbUserId.Text, 
                txbPwd.Text);

            ExecuteHandler handler = (o, args) =>
                                         {
                                             bool flag = CanAccessDb(connstring);
                                             
                                             context.Post(d =>
                                                              {
                                                                  MessageBox.Show(this, (bool)d ? "Succeed!" : "Failed!"); 
                                                                  btntest.Enabled = true;
                                                              }, flag);
                                         };

            btntest.Enabled = false;
            handler.BeginInvoke(sender, e, null, null);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AppConfigManager.Setting.Db.Database = txbDb.Text;
            AppConfigManager.Setting.Db.UserId = txbUserId.Text;
            AppConfigManager.Setting.Db.Password = txbPwd.Text;
            AppConfigManager.Setting.Db.Server = txbServer.Text;
            this.Close();
        }

        public bool CanAccessDb(string connstring)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();
                }
                return true;
            }
            catch (Exception)
            {
                
            }
            return false;
        }
    }
}