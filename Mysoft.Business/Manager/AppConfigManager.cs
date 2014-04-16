using Mysoft.Common.Utility;
using System;
using System.Collections.Generic;

namespace Mysoft.Business.Manager
{
    public static class AppConfigManager
    {
        static AppConfigManager()
        {
            Setting = new Setting();
        }

        public const string Name = "Setting.config";

        public static string WorkSpace
        {
            get
            {
                return Environment.CurrentDirectory;
            }
        }

        public static string ConnectionString
        {
            get
            {
                return string.Format("Server={0};database={1};user id={2};password={3}",
                        Setting.Db.Server, Setting.Db.Database, Setting.Db.UserId, Setting.Db.Password);
            }
        }

        public static Setting Setting { get; private set; }

        public static void Load(string config)
        {
            try
            {
                Setting = XmlHelper.XmlDeserializeFromFile<Setting>(config);
            }
            catch (Exception)
            {
                
            }

            if (Setting == null)
            {
                Setting = new Setting();
            }
        }
    }

    public class Setting
    {
        public Setting()
        {
            Db = new DbSetting();
            Dir = new DirSetting();
            WebSite = new WebSiteSetting();
            App = new AppSetting();
        }

        public DbSetting Db { get; set; }

        public DirSetting Dir { get; set; }

        public WebSiteSetting WebSite { get; set; }

        public AppSetting App { get; set; }
    }

    public class DbSetting
    {
        public DbSetting()
        {
            Server = "";
            Database = "";
            UserId = "";
            Password = "";
            RegName = "";
        }

        public string RegName { get; set; }

        public string Server { get; set; }

        public string Database { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }
    }

    public class DirSetting
    {
        public DirSetting()
        {
            IgnoreDir = string.Format(".*({0}).*", "bin|obj|activex|_|images|img|temp|upfiles|aspnet|WebEditor|help");
            IgnoreFiles = string.Format(".*({0}).*", "ERP.xml|tmp.xml");
        }

        /// <summary>
        /// 要过滤的文件夹
        /// </summary>
        public string IgnoreDir { get; set; }

        /// <summary>
        /// 要过滤的文件
        /// </summary>
        public string IgnoreFiles { get; set; }
    }

    public class WebSiteSetting
    {
        public WebSiteSetting()
        {
            SiteRoot = "";
        }

        /// <summary>
        /// 站点根目录
        /// </summary>
        public string SiteRoot { get; set; }

        /// <summary>
        /// map版本
        /// </summary>
        public string Version { get; set; }
    }

    public class AppSetting
    {
        public AppSetting()
        {
            LastOpenedFiles = new List<string>();
        }

        public List<string> LastOpenedFiles { get; set; }
    }
}