using System.Collections.Generic;
using System.Xml.Serialization;
using ControlCheck.Business.Attributes;

namespace Mysoft.Business.Controls
{
    public class AppFormMenu
    {
        [XmlArray(ElementName = "menus")]
        [XmlArrayItem(ElementName = "menu")]
        public List<Menu> Menus { get; set; }

        [XmlArray(ElementName = "shortcuts")]
        [XmlArrayItem(ElementName = "shortcut")]
        public List<ShortCut> ShortCuts { get; set; }
    }

    public class Menu
    {
        [XmlAttribute(AttributeName = "title")]
        [MapContract(Describe = "菜单名称, '-'表示分隔线", IsRequired = true)]
        public string Title { get; set; }

        [XmlElement(ElementName = "menuitem")]
        public List<MenuItem> MenuItems { get; set; }
    }

    public class MenuItem
    {
        /// <summary>
        /// 菜单项 id，可选
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        [MapContract(Describe = "菜单项id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "title")]
        [MapContract(Describe = "菜单名称, '-'表示分隔线", IsRequired = true)]
        public string Title { get; set; }

        [XmlAttribute(AttributeName = "icon")]
        [MapContract(Describe = "菜单项的图标")]
        public string Icon { get; set; }

        [XmlAttribute(AttributeName = "active")]
        [MapContract(Describe = "禁用/启用", Type = FieldType.Boolean)]
        public string Active { get; set; }

        [XmlAttribute(AttributeName = "display")]
        [MapContract(Describe = "菜单的隐藏/显示", Type = FieldType.Boolean)]
        public string Display { get; set; }

        [XmlAttribute(AttributeName = "actionid")]
        [MapContract(Describe = "动作点")]
        public string ActionId { get; set; }

        [XmlAttribute(AttributeName = "action")]
        [MapContract(Describe = "单击调用的函数")]
        public string Action { get; set; }

        [XmlElement(ElementName = "menuitem")]
        public List<MenuItem> MenuItems { get; set; }
    }

}