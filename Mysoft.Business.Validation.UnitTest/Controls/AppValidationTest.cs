using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mysoft.Business.Controls;
using Mysoft.Business.Manager;
using Mysoft.Business.Validation.Db;
using Mysoft.Business.Validation.Entity;
using Mysoft.Common.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mysoft.Business.Validation.UnitTest.Controls
{
    [TestClass]
    public class AppValidationTest
    {
        [TestMethod]
        public void CommmonTest()
        {
            //AppForm form = new AppForm();
            //var tab = new AppFormTab();
            //var section = new AppFormSection();
            //var item = new AppFormItem();
            //item.Options = new List<SelectOption>();
            //SelectOption so1 = new SelectOption();
            //so1.Value = "1";
            //so1.Text = "yes ";
            //SelectOption so2 = new SelectOption();
            //so2.Value = "0";
            //so2.Text = "no ";
            //item.Options.Add(so1);
            //item.Options.Add(so2);
            //section.Items.Add(item);
            //tab.Sections.Add(section);
            //form.Tabs.Add(tab);

            //var formXml = XmlHelper.XmlSerialize(form);

            DbAccessManager.Init("Server=wh-pc066;database=dotnet_erp302sp1_scxxw;user id=sa;password=95938");
            MapPage page = GetPage();
            PageResult pageresult = AppValidationManager.ValidatePage(page);
            foreach (Result result in pageresult.Results)
            {
                Debug.WriteLine(string.Format("Level: {0}, Title: {1}, Message: {2}", result.Level, result.Title, result.Message));
            }
        }

        private MapPage GetPage()
        {
            AppConfigManager.Setting.WebSite.SiteRoot = @"E:\10.5.11.17\四川新希望\ERP302\安全漏洞检测-分支\明源整体解决方案\Map";
            string testdata = "";
            //testdata = @"E:\10.5.11.17\四川新希望\ERP302\安全漏洞检测-分支\明源整体解决方案\Map\Cbgl\PUB\SelectProductPlanProduct.xml";
            testdata = @"E:\360云盘\Mysoft\源码\MySourceCode\ControlChecker\Mysoft.Business.Validation.UnitTest\TestData\AppForm.xml";

            var boo = AppValidationManager.IsMapXml(testdata);

            List<PageResult> pages = AppValidationManager.ValidateFiles(new List<string>() { testdata });

            MapPage page = null;
            try
            {
                page = AppValidationManager.GetPage(testdata);
            }
            catch (Exception)
            {
                string content = FileHelper.Read(testdata);
                content = Regex.Replace(content, "(encoding=\"gb2312\"|xmlns=\"http://map.mysoft.com/2_0/XMLSchema\")", "", RegexOptions.IgnoreCase);
                page = XmlHelper.XmlDeserialize<MapPage>(content);
            }

            return page;
        }

        [TestMethod]
        public void ValidateDirTest()
        {
            AppConfigManager.Setting.Db.Database = "dotnet_erp302sp1_scxxw";
            AppConfigManager.Setting.Db.UserId = "sa";
            AppConfigManager.Setting.Db.Password = "95938";
            AppConfigManager.Setting.Db.Server = "wh-pc066";
            AppConfigManager.Setting.WebSite.SiteRoot = @"E:\10.5.11.17\四川新希望\ERP302\安全漏洞检测-分支\明源整体解决方案\Map";

            //AppValidationManager.OnNotify += (sender, args) => Debug.WriteLine(sender);
            List<string> list = new List<string>();
            GetDirectories(AppConfigManager.Setting.WebSite.SiteRoot, list);
            List<PageResult> pages = AppValidationManager.ValidateFiles(list);
            foreach (PageResult page in pages)
            {
                Debug.WriteLine(string.Format("Page: {0}", page.Xml));
                foreach (Result result in page.Results)
                {
                    Debug.WriteLine(string.Format("\tLevel: {0}, Title: {1}, Message: {2}, Type: {3}", result.Level, result.Title, result.Message, result.Validation == null ? "" : result.Validation.Name));
                }
            }
        }

        private bool IsIgnore(string dir)
        {
            return Regex.Match(dir, AppConfigManager.Setting.Dir.IgnoreDir, RegexOptions.IgnoreCase).Success;
        }

        private void GetDirectories(string dir, List<string> list)
        {
            string[] temps = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly);
            foreach (string s in temps)
            {
                if (!IsIgnore(s))
                {
                    List<string> files = GetFiles(s);
                    list.AddRange(files);
                }

                GetDirectories(s, list);
            }
        }

        private List<string> GetFiles(string dir)
        {
            IEnumerable<string> files = Directory.GetFiles(dir, "*.xml", SearchOption.TopDirectoryOnly).Where(f => !IsIgnore(f));
            return files.ToList();
        }
    }
}