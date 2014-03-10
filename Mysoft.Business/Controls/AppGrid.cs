using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;
using ControlCheck.Business.Attributes;

namespace Mysoft.Business.Controls
{
    /// <summary>
    /// AppGrid和AppGridE在配置上是无法区分的，因此共用一个类
    /// </summary>
    public class AppGrid : BaseControl
    {
        public AppGrid()
        {
            Id = "";
            Describe = "";
        }

        [MapContract(Describe = "id", Ignore = true)]
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "row", IsNullable = true)]
        public AppGridRow Row { get; set; }

        [XmlElement(ElementName = "summary", IsNullable = true)]
        public AppGridSummary Summary { get; set; }

        [XmlIgnore]
        public string Describe { get; set; }

        #region AppGridE的属性

        [MapContract(Describe = "冻结列数")]
        [XmlAttribute(AttributeName = "fastnesscount")]
        public int FastNessCount { get; set; }

        [MapContract(Describe = "行头风格，0，不启用 1，序号列 2，复选框列")]
        [XmlAttribute(AttributeName = "SerialType")]
        public int SerialType { get; set; }

        #endregion AppGridE的属性

        /// <summary>
        /// AppGrid和AppGridE在XML标签上无法区分，仅能根据cell.celltype属性是否有值来判断
        /// </summary>
        public void Arrange()
        {
            if (Row != null)
            {
                var cellTypeCells = Row.AppGridCells.Find(a => a.CellType != AppGridCellType.None);
                if (cellTypeCells != null)
                {
                    
                }
            }
        }
    }

    public class AppGridRow
    {
        public AppGridRow()
        {
            Attributes = new List<AppControlAttribute>();
            AppGridCells = new List<AppGridCell>();
        }
        
        [XmlArray(ElementName = "attributes")]
        [XmlArrayItem(ElementName = "attribute", Type = typeof (AppControlAttribute))]
        public List<AppControlAttribute> Attributes { get; set; }

        [XmlElement(ElementName = "cell")]
        public List<AppGridCell> AppGridCells { get; set; }

        /// <summary>
        /// 这个类比较特殊，字段的样式属性是在AppGridCell中定义的
        /// 但是数据结构是在Attributes中定义，因此这里采用字典分类
        /// </summary>
        public void Fill()
        {
            Dictionary<string, AppControlAttribute> cells = new Dictionary<string, AppControlAttribute>();
            
            foreach (AppControlAttribute a in Attributes)
            {
                if (!string.IsNullOrEmpty(a.Field))
                {
                    if (!cells.ContainsKey(a.Field))
                    {
                        cells.Add(a.Field, a);
                    }
                }
            }

            foreach (AppGridCell c in AppGridCells)
            {
                if (!string.IsNullOrEmpty(c.Field) && cells.ContainsKey(c.Field))
                {
                    AppControlAttribute temp = cells[c.Field];
                    c.Name = temp.Name;
                    c.DataType = temp.DataType;
                }
            }
        }
    }

    public class AppGridSummary
    {
        [MapContract(Describe = "标题")]
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [MapContract(Describe = "合计字段名")]
        [XmlAttribute(AttributeName = "sumtotalfilter")]
        public string SumTotalFilter { get; set; }

        [XmlElement(ElementName = "cell")]
        public List<AppGridCell> AppGridCells { get; set; }
    }

    public class AppGridCell : AppGridCellBase
    {
        public AppGridCell()
        {
            Field = "";
            Title = "";
            SumTotalField = "";
            Format = "";
            Align = "";
            Name = "";
            DataType = "varchar";
            OtherAttributes = new Collection<XmlAttribute>();
            CellType = AppGridCellType.None;
        }

        /// <summary>
        /// 指定合计字段名（支持SQL表达式：Summary1+Summary2），该字段只能是数值类型
        /// </summary>
        [MapContract(Describe = "合计字段名", Ignore = true)]
        [XmlAttribute(AttributeName = "sumtotalfield")]
        public string SumTotalField { get; set; }

        [MapContract(Describe = "标题列宽", Ignore = true)]
        [XmlAttribute(AttributeName = "titlewidth")]
        public int TitleWidth { get; set; }

        [MapContract(Describe = "数据输出格式")]
        [XmlAttribute(AttributeName = "format")]
        public string Format { get; set; }

        [MapContract(Describe = "对齐方式")]
        [XmlAttribute(AttributeName = "align")]
        public string Align { get; set; }

        [MapContract(Describe = "是否允许排序")]
        [XmlAttribute(AttributeName = "sortable")]
        public bool Sortable { get; set; }

        #region 非SDK定义但归属于它的成员

        [MapContract(Describe = "属性名称", Ignore = true)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [MapContract(Describe = "数据类型", Ignore = true)]
        [XmlAttribute(AttributeName = "datatype")]
        public string DataType { get; set; }

        #endregion 非SDK定义但归属于它的成员

        #region AppGridE的属性

        /// <summary>
        /// blank，check，datetime，hyperlink，layer，number，select，select2，text，texticon
        /// </summary>
        [MapContract(Describe = "控件类型")]
        [XmlAttribute(AttributeName = "celltype")]
        public AppGridCellType CellType { get; set; }

        /// 新增记录时，控件是否可填。0 为只读，1 为可填，默认值为 1。
        [XmlAttribute(AttributeName = "createapi")]
        [MapContract(Describe = "新增记录时，控件是否可填")]
        public bool Createapi { get; set; }

        /// 修改记录时，控件是否可填。0 为只读，1 为可填，默认值为 1。
        [XmlAttribute(AttributeName = "updateapi")]
        [MapContract(Describe = "修改记录时，控件是否可填")]
        public bool Updateapi { get; set; }

        /// 是否必填项。0 为非必填，1 为必填，2 为建议填写，默认值为 0 。
        [XmlAttribute(AttributeName = "req")]
        [MapContract(Describe = "是否必填项")]
        public bool Req { get; set; }

        /// 是否必填项。0 为非必填，1 为必填，2 为建议填写，默认值为 0 。
        [XmlAttribute(AttributeName = "issave")]
        [MapContract(Describe = "是否保存", Ignore = true)]
        public bool IsSave { get; set; }

        #endregion AppGridE的属性

        /// <summary>
        /// 其余未被识别的属性
        /// </summary>
        [XmlAnyAttribute]
        public Collection<XmlAttribute> OtherAttributes { get; set; }

        /// <summary>
        /// 其余未被识别的节点
        /// </summary>
        [XmlAnyElement]
        public Collection<XmlElement> OtherElements { get; set; }
    }

    /// <summary>
    /// 单元格基类，共有属性，做规则校验时方便使用
    /// </summary>
    public class AppGridCellBase
    {
        [MapContract(Describe = "数据来源字段名")]
        [XmlAttribute(AttributeName = "field")]
        public string Field { get; set; }

        [MapContract(Describe = "列名")]
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [MapContract(Describe = "列宽", Ignore = true)]
        [XmlAttribute(AttributeName = "width")]
        public string Width { get; set; }
    }

}