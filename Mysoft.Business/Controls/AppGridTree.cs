using ControlCheck.Business.Attributes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mysoft.Business.Controls
{
    [XmlRoot(ElementName = "gridtree")]
    public class AppGridTree : BaseControl
    {
        /// <summary>
        /// 网格树默认展开级别
        /// </summary>
        [XmlElement(ElementName = "defaultexpandlevel")]
        public AppGridTreeExpandLevel ExpandLevel { get; set; }

        [XmlElement(ElementName = "colors")]
        public AppGridTreeColor Colors { get; set; }

        /// <summary>
        /// 冻结列标题
        /// </summary>
        [XmlElement(ElementName = "fixedtitles")]
        public AppGridTreeFixedTitles FixedTitles { get; set; }

        /// <summary>
        /// 非冻结列标题
        /// </summary>
        [XmlElement(ElementName = "titles")]
        public AppGridTreeTitles Titles { get; set; }

        [XmlElement(ElementName = "row")]
        public AppGridTreeRow Row { get; set; }

        [MapContract(Describe = "定义用于生成查询条件的表达式。其中的关键字“[code]”会被层级代码替换。", Ignore = true)]
        [XmlElement(ElementName = "queryreplace")]
        public AppGridTreeQueryReplace QueryPlace { get; set; }

        [MapContract(Describe = "是否支持多选")]
        [XmlAttribute(AttributeName = "mutiSelect")]
        public bool IsSupportMultiSelect { get; set; }

        [MapContract(Describe = "是否启用异步加载", Ignore = true)]
        [XmlAttribute(AttributeName = "syncload")]
        public bool IsSyncload { get; set; }

    }

    public class AppGridTreeExpandLevel
    {
        [MapContract(Describe = "是否启用异步加载", Ignore = true)]
        [XmlAttribute(AttributeName = "syncload")]
        public bool IsSyncload { get; set; }
    }

    public class AppGridTreeColor
    {
        [MapContract(Describe = "Div块边框颜色", Ignore = true)]
        [XmlElement(ElementName = "divborder")]
        public ColorItem DivBorder { get; set; }

        [MapContract(Describe = "表格边框颜色", Ignore = true)]
        [XmlElement(ElementName = "tableborder")]
        public ColorItem TableBorder { get; set; }

        [MapContract(Describe = "节点背景色", Ignore = true)]
        [XmlElement(ElementName = "level")]
        public List<ColorItem> Levels { get; set; }
    }

    public class ColorItem
    {
        [XmlText]
        public string ColorValue { get; set; }
    }

    public class AppGridTreeFixedTitles
    {
        [XmlElement(ElementName = "tr")]
        public List<AppGridTreeFixedTitleTr> Tr { get; set; }
    }

    public class AppGridTreeFixedTitleTr
    {
        [XmlElement(ElementName = "td")]
        public List<AppGridTreeFixedTitleTd> Td { get; set; }
    }

    public class AppGridTreeFixedTitleTd
    {
        [XmlText]
        public string Text { get; set; }
    }

    public class AppGridTreeTitles
    {
        [XmlElement(ElementName = "tr")]
        public List<AppGridTreeFixedTitleTr> Tr { get; set; }
    }

    public class AppGridTreeQueryReplace
    {
        [XmlText]
        public string Text { get; set; }
    }

    public class AppGridTreeRow
    {
        public AppGridTreeRow()
        {
            Attributes = new List<AppControlAttribute>();
            Cells = new List<AppGridTreeCell>();
        }
        
        [XmlArray(ElementName = "attributes")]
        [XmlArrayItem(ElementName = "attribute", Type = typeof (AppControlAttribute))]
        public List<AppControlAttribute> Attributes { get; set; }

        [XmlElement(ElementName = "cell")]
        public List<AppGridTreeCell> Cells { get; set; }
    }

    public class AppGridTreeCell : AppGridCellBase
    {
        public AppGridTreeCell()
        {
            //CellType = "text";
            Field = "";
            Title = "";
        }

        [MapContract(Describe = "是否冻结列")]
        [XmlAttribute(AttributeName = "fixed")]
        public bool IsFixed { get; set; }
    }
}