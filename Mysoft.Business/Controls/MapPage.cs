namespace Mysoft.Business.Controls
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "page")]
    public class MapPage
    {
        private string _PageXml = "";

        public MapPage()
        {
            this.Funcid = "";
            this.Application = "";
            this.PageTitle = "";
            this.PageUrl = "";
            this.PageXml = "";
            this.Controls = new List<AppControl>();
        }

        /// <summary>
        /// 控件整理，移除不支持的控件，给AppGrid附上标题
        /// 得到MapPage对象后都需要调用
        /// </summary>
        public void Arrange()
        {
            int appGridIndex = -1;
            int appGridMenuIndex = -1;
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                AppControl ac = this.Controls[i];
                if (ac.MenuTitle != null)
                {
                    appGridMenuIndex = i;
                }
                else if (ac.Control is AppGrid)
                {
                    appGridIndex = i;
                }
                if (this.IsNotSupport(ac))
                {
                    this.Controls.Remove(ac);
                }
            }
            //给appGrid加上标题
            if ((appGridIndex > -1) && (appGridMenuIndex > -1))
            {
                this.Controls[appGridIndex].Describe = this.Controls[appGridMenuIndex].MenuTitle.Text;
            }
        }

        private bool IsNotSupport(AppControl ac)
        {
            return ((((ac.Control == null) && (ac.View == null)) && (ac.Query == null)) && (ac.MenuTitle == null));
        }

        /// 功能权限。
        [XmlAttribute(AttributeName = "actionid")]
        public string ActionId { get; set; }

        /// 页面所属的系统代码。
        [XmlAttribute(AttributeName = "application")]
        public string Application { get; set; }

        [XmlArrayItem(ElementName = "control", Type = typeof(AppControl)), XmlArray(ElementName = "controls")]
        public List<AppControl> Controls { get; set; }

        /// 页面所属的功能模块代码。
        [XmlAttribute(AttributeName = "funcid")]
        public string Funcid { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string PageId { get; set; }

        [XmlIgnore]
        public string PageTitle { get; set; }

        [XmlIgnore]
        public string PageUrl { get; set; }

        [XmlIgnore]
        public string PageXml
        {
            get
            {
                if (!(!string.IsNullOrEmpty(this._PageXml) || string.IsNullOrEmpty(this.PageUrl)))
                {
                    this._PageXml = this.PageUrl.Replace("aspx", "xml");
                }
                return this._PageXml;
            }
            set
            {
                this._PageXml = value;
            }
        }

        [XmlIgnore]
        public List<MapPage> SubPages { get; set; }
    }
}