using ControlCheck.Business.Attributes;
using System.Collections.Generic;
using System.Xml.Serialization;
using Mysoft.Business.Contracts;

namespace Mysoft.Business.Controls
{
    public class AppDropDownList : BaseControl
    {
        public AppDropDownList()
        {
            TextField = new TextNode() { Text = "text" };
            ValueField = new TextNode() { Text = "value" };
        }

        [MapContract(Describe = "标题")]
        [XmlElement(ElementName = "title")]
        public TextNode Title { get; set; }

        [MapContract(Describe = "拼写查询过滤条件使用的字段")]
        [XmlElement(ElementName = "field")]
        public TextNode Field { get; set; }

        [MapContract(Describe = "下拉选项text绑定字段，默认为text")]
        [XmlElement(ElementName = "textfield")]
        public TextNode TextField { get; set; }

        [MapContract(Describe = "下拉选项value绑定字段，默认为value")]
        [XmlElement(ElementName = "valuefield")]
        public TextNode ValueField { get; set; }

        [MapContract(Describe = "下拉框项")]
        [XmlArray(ElementName = "options")]
        [XmlArrayItem(ElementName = "option")]
        public List<PropertyOption> Options { get; set; }
    }

    public class PropertyOption
    {
        [XmlText]
        public string Text { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}