using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;
using ControlCheck.Business.Attributes;

namespace Mysoft.Business.Controls
{
    public class AppNavBar : BaseControl
    {
        public AppNavBar()
        {
            NavsItems = new List<AppNavItem>();
        }

        [XmlElement(ElementName = "navitem")]
        public List<AppNavItem> NavsItems { get; set; }
    }

    public class AppNavItem
    {
        [MapContract(Describe = "Id")]
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [MapContract(Describe = "标签页显示名")]
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [MapContract(Describe = "新增状态是否显示该标签页")]
        [XmlAttribute(AttributeName = "isshowonadd")]
        public string IsShowOnAdd { get; set; }

        [MapContract(Describe = "标签页对应的页面地址")]
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }

        [MapContract(Describe = "是否显示", Type = FieldType.Boolean)]
        [XmlAttribute(AttributeName = "display")]
        public string IsDisplay { get; set; }

        /// <summary>
        /// 其它参数
        /// </summary>
        [XmlAnyElement]
        public Collection<XmlElement> OtherElements { get; set; }

        [XmlIgnore]
        public string Xml { get; set; }

        [XmlIgnore]
        public MapPage SubPage { get; set; }
    }
}