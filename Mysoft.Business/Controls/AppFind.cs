using ControlCheck.Business.Attributes;
using Mysoft.Business.Manager;
using Mysoft.Common.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;

namespace Mysoft.Business.Controls
{
    ///// <summary>
    ///// appForm控件，格式比较奇葩，定义在AppControl中了
    ///// </summary>
    //public class AppFind
    //{
    //}

    public class AppFindView
    {
        public AppFindView()
        {
            AppFindViewItems = new List<AppFindViewItem>();
            ResultXmlUrl = "";
            GroupId = "";
        }

        [MapContract(Describe = "查询结果视图")]
        [XmlAttribute(AttributeName = "resultxmlurl")]
        public string ResultXmlUrl { get; set; }

        [MapContract(Describe = "历史查询所属的页面")]
        [XmlAttribute(AttributeName = "groupid")]
        public string GroupId { get; set; }

        [XmlElement(ElementName = "item")]
        public List<AppFindViewItem> AppFindViewItems { get; set; }
    }

    public class AppFindViewItem
    {
        /// <summary>
        /// 视图 id，定位视图用
        /// </summary>
        [XmlAttribute(AttributeName = "xmlid")]
        [MapContract(Describe = "视图id")]
        public string XmlId { get; set; }

        /// <summary>
        /// 视图对应的 XML 文件地址
        /// </summary>
        [XmlAttribute(AttributeName = "xmlurl")]
        [MapContract(Describe = "视图XML路径")]
        public string XmlUrl { get; set; }

        [XmlText]
        public string Title { get; set; }

        [XmlAttribute(AttributeName = "viewid")]
        [MapContract(Describe = "视图id")]
        public string ViewId { get; set; }

        [XmlAttribute(AttributeName = "selected")]
        [MapContract(Describe = "是否默认视图", Type = FieldType.Boolean)]
        public string IsSelected { get; set; }

        private MapPage _SubPage = null;

        [XmlIgnore]
        public MapPage SubPage
        {
            get
            {
                if (!string.IsNullOrEmpty(XmlUrl) && _SubPage == null)
                {
                    try
                    {
                        PathHelper.SetAbsoluteDir(AppConfigManager.Setting.WebSite.SiteRoot);
                        string path = PathHelper.MapPath(XmlUrl);
                        _SubPage = XmlHelper.XmlDeserializeFromFile<MapPage>(path);
                        if (_SubPage != null)
                        {
                            _SubPage.Arrange();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

                return _SubPage;
            }
            set { _SubPage = value; }
        }
    }

    public class AppFindQuery
    {
        public AppFindQuery()
        {
            IsShowCheckboxDefault = "true";
            IsShowCheckbox = "false";
            IsShowQueryInResult = "false";
        }

        /// <summary>
        /// 是否显示“视图内查询”复选框
        /// </summary>
        [MapContract(Describe = "是否显示“视图内查询”", Type = FieldType.Boolean)]
        [XmlAttribute(AttributeName = "isshowcheckbox")]
        public string IsShowCheckbox { get; set; }

        /// <summary>
        /// 在“视图内查询”选项默认是否勾选
        /// </summary>
        [XmlAttribute(AttributeName = "showcheckboxdefault")]
        [MapContract(Describe = "“视图内查询”选项默认是否勾选”", Type = FieldType.Boolean)]
        public string IsShowCheckboxDefault { get; set; }

        /// <summary>
        /// 是否显示【结果中查找】按钮
        /// </summary>
        [XmlAttribute(AttributeName = "queryinresult")]
        [MapContract(Describe = "是否显示【结果中查找】按钮", Type = FieldType.Boolean)]
        public string IsShowQueryInResult { get; set; }

        /// <summary>
        /// 数据结构名称
        /// </summary>
        [MapContract(Describe = "数据结构名称(如表名、视图名)")]
        [XmlAttribute(AttributeName = "entity")]
        public string Entity { get; set; }

        [MapContract(Describe = "主键")]
        [XmlAttribute(AttributeName = "keyname")]
        public string KeyName { get; set; }

        /// <summary>
        /// 保存“历史查询”时，标识该历史查询所属的页面
        /// 当用户打开页面时，底层根据groupid从数据库中获取历史查询列表。
        /// </summary>
        [MapContract(Describe = "历史查询所属页面标识")]
        [XmlAttribute(AttributeName = "groupid")]
        public string GroupId { get; set; }

        /// <summary>
        /// 标准查找
        /// </summary>
        [XmlElement(ElementName = "standard")]
        public AppFindQueryStandard Standard { get; set; }

        /// <summary>
        /// 高级查找
        /// </summary>
        [XmlElement(ElementName = "advanced")]
        public AppFindQueryAdvanced Advanced { get; set; }
    }

    public class AppFindQueryStandard
    {
        [XmlArray(ElementName = "items")]
        [XmlArrayItem(ElementName = "item")]
        public List<AppFindQueryItem> Items { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        [XmlAttribute(AttributeName = "titlewidth")]
        public string TitleWidth { get; set; }
    }

    public class AppFindQueryAdvanced
    {
        [XmlArray(ElementName = "items")]
        [XmlArrayItem(ElementName = "item")]
        public List<AppFindQueryItem> Items { get; set; }
    }

    public class AppFindQueryItem
    {
        public AppFindQueryItem()
        {
            OtherAttributes = new Collection<XmlAttribute>();
            Type = AppFormItemType.Text.ToString();
        }

        [MapContract(Describe = "字段名")]
        [XmlAttribute(AttributeName = "field")]
        public string Field { get; set; }

        [MapContract(Describe = "字段类型，datetime,select,lookup,number或自定义", EnumType = typeof(AppFormItemType), EnumValueType = EnumValueType.Text
            , InvalidMessage = "控件类型如datetime,select,lookup,number等，请参照SDK")]
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [MapContract(Describe = "查找方式", EnumType = typeof(OperatorType), EnumValueType = EnumValueType.Text)]
        [XmlAttribute(AttributeName = "operator")]
        public string Operator { get; set; }

        [MapContract(Describe = "标题")]
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// 仅select控件有用
        /// </summary>
        [MapContract(Describe = "查询SQL，仅select控件有用")]
        [XmlAttribute(AttributeName = "sql")]
        public string Sql { get; set; }

        [MapContract(Describe = "查询SQL，仅lookup控件有用")]
        [XmlAttribute(AttributeName = "action")]
        public string Action { get; set; }

        [XmlAnyAttribute]
        public Collection<XmlAttribute> OtherAttributes { get; set; }

        [MapContract(Describe = "小数位")]
        [XmlAttribute(AttributeName = "acc")]
        public string Acc { get; set; }

        [MapContract(Describe = "标题")]
        [XmlAttribute(AttributeName = "dt")]
        public string Dt { get; set; }

        [MapContract(Describe = "标题")]
        [XmlAttribute(AttributeName = "是否显示千分号")]
        public string Grp { get; set; }

        [MapContract(Describe = "最大值")]
        [XmlAttribute(AttributeName = "max")]
        public string Max { get; set; }

        [MapContract(Describe = "最小值")]
        [XmlAttribute(AttributeName = "min")]
        public string Min { get; set; }
    }
}