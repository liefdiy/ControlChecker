using System.Collections.Generic;
using System.Xml.Serialization;
using ControlCheck.Business.Attributes;

namespace Mysoft.Business.Controls
{
    [XmlRoot(ElementName = "page")]
    public class MapPage
    {
        public MapPage()
        {
            Funcid = "";
            Application = "";
            PageTitle = "";
            PageUrl = "";
            PageXml = "";

            Controls = new List<AppControl>();
        }

        [XmlArray(ElementName = "controls")]
        [XmlArrayItem(ElementName = "control", Type = typeof(AppControl))]
        public List<AppControl> Controls { get; set; }

        /// 页面所属的功能模块代码。
        [MapContract(Ignore = true)]
        [XmlAttribute(AttributeName = "funcid")]
        public string Funcid { get; set; }

        /// 功能权限。
        [MapContract(Ignore = true)]
        [XmlAttribute(AttributeName = "actionid")]
        public string ActionId { get; set; }

        /// 页面所属的系统代码。
        [MapContract(Ignore = true)]
        [XmlAttribute(AttributeName = "application")]
        public string Application { get; set; }

        [XmlIgnore]
        public string PageTitle { get; set; }

        [XmlIgnore]
        public string PageUrl { get; set; }

        private string _PageXml = "";

        [XmlIgnore]
        public string PageXml {
            get
            {
                if (string.IsNullOrEmpty(_PageXml) && !string.IsNullOrEmpty(PageUrl))
                {
                    //如果页面地址不为空，且页面xml未指定，则页面xml给默认地址
                    _PageXml = PageUrl.Replace("aspx", "xml");
                }
                return _PageXml;
            }
            set { _PageXml = value; }
        }

        [XmlIgnore]
        public List<MapPage> SubPages { get; set; }

        [MapContract(Ignore = true)]
        [XmlAttribute(AttributeName = "id")]
        public string PageId { get; set; }

        /// <summary>
        /// 控件整理，移除不支持的控件，给AppGrid附上标题
        /// 得到MapPage对象后都需要调用
        /// </summary>
        public void Arrange()
        {
            int appGridIndex = -1, appGridMenuIndex = -1;
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                AppControl ac = Controls[i];
                if (ac.MenuTitle != null)
                {
                    appGridMenuIndex = i;
                }
                else if(ac.Control is AppGrid)
                {
                    appGridIndex = i;
                }
                if (IsNotSupport(ac))
                {
                    Controls.Remove(ac);
                }
            }

            //给appGrid加上标题
            if (appGridIndex > -1 && appGridMenuIndex > -1)
            {
                Controls[appGridIndex].Describe = Controls[appGridMenuIndex].MenuTitle.Title;
            }
        }

        private bool IsNotSupport(AppControl ac)
        {
            return (ac.Control == null && ac.View == null && ac.Query == null && ac.MenuTitle == null);
        }
    }
}