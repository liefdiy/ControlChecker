using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using Mysoft.Business.Manager;
using Mysoft.Common.Utility;

namespace SCide
{
    public partial class SettingForm : Form
    {
        private SynchronizationContext context;
        private Dictionary<string, DbConfig> dbDic = new Dictionary<string, DbConfig>();

        public SettingForm()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
        }

        protected override void OnLoad(EventArgs e)
        {
            cbb_reg.DataSource = GetMysoftSubKey();
            cbb_reg.Text = AppConfigManager.Setting.Db.RegName;
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
            AppConfigManager.Setting.Db.RegName = cbb_reg.Text;
            this.Close();
        }

        private void cbb_reg_SelectedValueChanged(object sender, EventArgs e)
        {
            string text = this.cbb_reg.Text;
            if (!string.IsNullOrEmpty(text) && this.dbDic.ContainsKey(text))
            {
                DbConfig config = this.dbDic[text];
                this.txbDb.Text = config.DBName;
                this.txbPwd.Text = config.SaPassword;
                this.txbServer.Text = config.ServerName;
                this.txbUserId.Text = config.UserName;
            }
        }

        private static string Decode(string inStr)
        {
            string str = null;
            int length = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            str = "";
            length = inStr.Trim().Length;
            num3 = length % 3;
            num4 = length % 9;
            num5 = length % 5;
            if ((length / 2) == Convert.ToInt32((int)(length / 2)))
            {
                num2 = num4 + num5;
            }
            else
            {
                num2 = num3 + num5;
            }
            int startIndex = 0;
            for (num6 = 0; num6 <= length; num6++)
            {
                startIndex = length - num6;
                if (startIndex < inStr.Length)
                {
                    str = str + Convert.ToChar((int)(Convert.ToChar(inStr.Substring(startIndex, 1)) + num2));
                }
                if (num2 == (num3 + num5))
                {
                    num2 = num4 + num5;
                }
                else
                {
                    num2 = num3 + num5;
                }
            }
            return str.PadRight(inStr.Length - length);
        }


        private List<string> GetMysoftSubKey()
        {
            RegistryKey localMachine = Registry.LocalMachine;
            string name = string.Empty;
            if (OSHelper.Is64Bit())
            {
                name = @"SOFTWARE\Wow6432Node\mysoft";
            }
            else
            {
                name = @"SOFTWARE\mysoft";
            }
            RegistryKey key2 = localMachine.OpenSubKey(name);
            if (key2 != null)
            {
                try
                {
                    foreach (string str2 in key2.GetSubKeyNames())
                    {
                        RegistryKey key3 = key2.OpenSubKey(str2);
                        DbConfig config = new DbConfig();
                        object obj2 = key3.GetValue("DBName");
                        config.DBName = (obj2 == null) ? "" : obj2.ToString();
                        obj2 = key3.GetValue("SaPassword");
                        config.SaPassword = (obj2 == null) ? "" : Decode(obj2.ToString());
                        obj2 = key3.GetValue("ServerName");
                        config.ServerName = (obj2 == null) ? "" : obj2.ToString();
                        obj2 = key3.GetValue("UserName");
                        config.UserName = (obj2 == null) ? "" : obj2.ToString();
                        key3.Close();
                        if (!this.dbDic.ContainsKey(str2))
                        {
                            this.dbDic.Add(str2, config);
                        }
                    }
                }
                finally
                {
                    key2.Close();
                    localMachine.Close();
                }
            }
            return this.dbDic.Keys.ToList<string>();
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

    internal class DbConfig
    {
        public string DBName { get; set; }

        public string SaPassword { get; set; }

        public string ServerName { get; set; }

        public string UserName { get; set; }
    }
}