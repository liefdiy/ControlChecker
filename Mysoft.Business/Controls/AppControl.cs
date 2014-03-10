using ControlCheck.Business.Attributes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mysoft.Business.Controls
{
    #region 控件类型

    public static class ControlType
    {
        public const string AppPage = "page";

        public const string AppForm = "appForm";
        public const string AppFormSection = "section";
        public const string AppFormTab = "tab";
        public const string AppFormText = "text";
        public const string AppFormMemo = "memo";
        public const string AppFormPwd = "password";

        public const string AppFind = "appFind";
        public const string AppQuery = "query";
        public const string AppQueryStandard = "standard";
        public const string AppQueryAdvanced = "advanced";

        public const string AppViewList = "appViewList";
        public const string AppView = "view";

        public const string AppGrid = "appGrid";
        public const string AppGridRow = "row";
        public const string AppGridSummary = "summary";
        public const string AppGridCell = "cell";

        public const string AppGridE = "appGridE";

        public const string AppGridTree = "gridTree";

        public const string AppNavBar = "nav";
        public const string AppNavItem = "navitem";
    }

    public enum OperatorType
    {
        [MapContract(Describe = "等于")]
        [XmlEnum(Name = "eq")]
        Eq,

        [MapContract(Describe = "不等于")]
        [XmlEnum(Name = "ne")]
        NotEqual,

        [MapContract(Describe = "大于")]
        [XmlEnum(Name = "gt")]
        Greater,

        [MapContract(Describe = "大于等于")]
        [XmlEnum(Name = "ge")]
        GreaterAndEqual,

        [MapContract(Describe = "小于")]
        [XmlEnum(Name = "lt")]
        Lower,

        [MapContract(Describe = "小于等于")]
        [XmlEnum(Name = "le")]
        LowerAndEqual,

        [MapContract(Describe = "类似。自动在值前后加“%”")]
        [XmlEnum(Name = "like")]
        Like,

        [MapContract(Describe = "类似。自动在值前面加“%”")]
        [XmlEnum(Name = "llike")]
        LikeBefore,

        [MapContract(Describe = "类似。自动在值后面加“%”")]
        [XmlEnum(Name = "rlike")]
        LikeAfter,

        [MapContract(Describe = "类似。不自动加“%”")]
        [XmlEnum(Name = "nlike")]
        LikeEqual,

        [MapContract(Describe = "不类似")]
        [XmlEnum(Name = "not-like")]
        NotLike,

        [MapContract(Describe = "为空")]
        [XmlEnum(Name = "null")]
        Null,

        [MapContract(Describe = "非空")]
        [XmlEnum(Name = "not-null")]
        NotNull,

        [MapContract(Describe = "包含")]
        [XmlEnum(Name = "in")]
        In,

        [MapContract(Describe = "不包含")]
        [XmlEnum(Name = "not-in")]
        NotIn,

        [MapContract(Describe = "特殊操作符，直接使用给定的值作为过滤条件。")]
        [XmlEnum(Name = "replace")]
        Replace,

    }

    public enum AppFormItemType
    {
        [XmlEnum(Name = "text")]
        Text,

        [XmlEnum(Name = "memo")]
        Memo,

        [XmlEnum(Name = "password")]
        Password,

        [XmlEnum(Name = "number")]
        Number,

        [XmlEnum(Name = "datetime")]
        Datetime,

        [XmlEnum(Name = "radio")]
        Radio,

        [XmlEnum(Name = "select")]
        Select,

        [XmlEnum(Name = "lookup")]
        Lookup,

        [XmlEnum(Name = "hidden")]
        Hidden,

        [XmlEnum(Name = "hyperlink")]
        HyperLink,

        [XmlEnum(Name = "blank")]
        Blank
    }

    public enum AppGridCellType
    {
        [XmlIgnore]
        None,

        [XmlEnum(Name = "text")]
        Text,

        [XmlEnum(Name = "check")]
        Check,

        [XmlEnum(Name = "datetime")]
        Datetime,

        [XmlEnum(Name = "hyperlink")]
        HyperLink,

        [XmlEnum(Name = "layer")]
        Layer,

        [XmlEnum(Name = "number")]
        Number,

        [XmlEnum(Name = "select")]
        Select,

        [XmlEnum(Name = "select2")]
        Select2,

        [XmlEnum(Name = "texticon")]
        TextIcon,

        [XmlEnum(Name = "blank")]
        Blank
    }

    public enum RequireLevel
    {
        [XmlEnum(Name = "optional")]
        Optional = 0,

        [XmlEnum(Name = "required")]
        Required = 1,

        [XmlEnum(Name = "proposed")]
        Proposed = 2
    }

    #endregion 控件类型

    /// <summary>
    /// 控件类
    /// </summary>
    [XmlType(TypeName = "control")]
    public class AppControl
    {
        public AppControl()
        {
            Id = "";
            Describe = "";
        }

        [MapContract(Required = true)]
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "datasource")]
        public DataSource DataSource { get; set; }

        /// <summary>
        /// 控件
        /// </summary>
        [XmlElement(ElementName = "form", Type = typeof(AppForm))]
        [XmlElement(ElementName = "grid", Type = typeof(AppGrid))]
        [XmlElement(ElementName = "gridtree", Type = typeof(AppGridTree))]
        [XmlElement(ElementName = "nav", Type = typeof(AppNavBar))]
        public BaseControl Control { get; set; }

        [XmlIgnore]
        public string Describe { get; set; }

        /// <summary>
        /// 传参用
        /// </summary>
        [XmlIgnore]
        public object Token { get; set; }

        #region AppFind

        [XmlElement(ElementName = "view")]
        public AppFindView View { get; set; }

        [XmlElement(ElementName = "query")]
        public AppFindQuery Query { get; set; }

        #endregion AppFind

        #region AppGridMenu

        [XmlElement(ElementName = "title")]
        public AppGridMenuTitle MenuTitle { get; set; }

        #endregion AppGridMenu
    }

    public abstract class BaseControl
    {
    }

    /// <summary>
    /// 数据源定义节点
    /// </summary>
    public class DataSource
    {
        public DataSource()
        {
            Entity = "";
            KeyName = "";
            SqlNode = new SqlNode();
            Type = "";
            DependencySql = new List<string>();
        }

        [MapContract(Describe = "3.0开始支持“SP”或“StoredProcedure”", Ignore = true)]
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [MapContract(Describe = "数据表")]
        [XmlAttribute(AttributeName = "entity")]
        public string Entity { get; set; }

        [XmlAttribute(AttributeName = "keyname")]
        public string KeyName { get; set; }

        [MapContract(Ignore = true)]
        [XmlIgnore]
        public string Sql
        {
            get { return SqlNode.Text; }
        }

        [XmlElement(ElementName = "sql")]
        public SqlNode SqlNode { get; set; }

        /// <summary>
        /// 分页模式，默认为0，值为1时必须无重复列
        /// </summary>
        [XmlAttribute(AttributeName = "pagemode")]
        public int PageMode { get; set; }

        [XmlArray(ElementName = "dependencysql")]
        [XmlArrayItem(ElementName = "sql", Type = typeof(string))]
        public List<string> DependencySql { get; set; }

        [XmlElement(ElementName = "order")]
        public Order Order { get; set; }
    }

    public class SqlNode
    {
        public SqlNode()
        {
            Text = "";
        }

        [XmlText]
        public string Text { get; set; }
    }

    public class Order
    {
        public Order()
        {
            Field = "";
        }

        [MapContract(Describe = "排序字段")]
        [XmlAttribute(AttributeName = "field")]
        public string Field { get; set; }

        [MapContract(Describe = "是否按降序排序")]
        [XmlAttribute(AttributeName = "descending")]
        public bool Descending { get; set; }
    }
}