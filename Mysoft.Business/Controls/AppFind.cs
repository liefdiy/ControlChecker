using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using ControlCheck.Business.Attributes;
using Mysoft.Business.Manager;
using Mysoft.Common.Utility;

namespace Mysoft.Business.Controls
{
    ///// <summary>
    ///// appForm控件，格式比较奇葩，定义在AppControl中了
    ///// </summary>
    //public class AppFind
    //{
    //}

    [MapContract(Type = "appViewList", Describe = "视图列表")]
    public class AppFindView
    {
        public AppFindView()
        {
            AppFindViewItems = new List<AppFindViewItem>();
            ResultXmlUrl = "";
            GroupId = "";
        }

        [MapContract(Describe = "查询结果视图", Ignore = true)]
        [XmlAttribute(AttributeName = "resultxmlurl")]
        public string ResultXmlUrl { get; set; }

        [MapContract(Describe = "历史查询所属的页面", Ignore = true)]
        [XmlAttribute(AttributeName = "groupid")]
        public string GroupId { get; set; }

        [XmlElement(ElementName = "item")]
        public List<AppFindViewItem> AppFindViewItems { get; set; }
    }

    [MapContract(Type = "view")]
    public class AppFindViewItem
    {
        /// <summary>
        /// 视图 id，定位视图用
        /// </summary>
        [XmlAttribute(AttributeName = "xmlid")]
        [MapContract(Describe = "视图id", Ignore = true)]
        public string XmlId { get; set; }

        /// <summary>
        /// 视图对应的 XML 文件地址
        /// </summary>
        [XmlAttribute(AttributeName = "xmlurl")]
        [MapContract(Describe = "视图XML路径", Ignore = true)]
        public string XmlUrl { get; set; }

        [XmlText]
        public string Title { get; set; }

        [XmlAttribute(AttributeName = "viewid")]
        [MapContract(Describe = "视图id", Ignore = true)]
        public string ViewId { get; set; }

        [XmlAttribute(AttributeName = "selected")]
        [MapContract(Describe = "是否默认视图")]
        public bool IsSelected { get; set; }

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
        /// <summary>
        /// 是否显示“视图内查询”复选框
        /// </summary>
        [MapContract(Describe = "是否显示“视图内查询”")]
        [XmlAttribute(AttributeName = "isshowcheckbox")]
        public bool IsShowCheckbox { get; set; }

        /// <summary>
        /// 在“视图内查询”选项默认是否勾选
        /// </summary>
        [XmlAttribute(AttributeName = "checkboxdefault")]
        [MapContract(Describe = "“视图内查询”选项默认是否勾选”")]
        public bool IsShoCheckboxDefault { get; set; }

        /// <summary>
        /// 是否显示【结果中查找】按钮
        /// </summary>
        [XmlAttribute(AttributeName = "queryinresult")]
        [MapContract(Describe = "是否显示【结果中查找】按钮")]
        public bool IsShowQueryInResult { get; set; }

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
        public List<AppFindQueryItem> AppFindViewItems { get; set; }
    }

    public class AppFindQueryAdvanced
    {
        [XmlArray(ElementName = "items")]
        [XmlArrayItem(ElementName = "item")]
        public List<AppFindQueryItem> AppFindViewItems { get; set; }
    }

    public class AppFindQueryItem
    {
        public AppFindQueryItem()
        {
            OtherAttributes = new Collection<XmlAttribute>();
        }

        [MapContract(Describe = "字段名")]
        [XmlAttribute(AttributeName = "field")]
        public string Field { get; set; }

        [MapContract(Describe = "字段类型")]
        [XmlAttribute(AttributeName = "type")]
        public AppFormItemType Type { get; set; }

        [MapContract(Describe = "查找方式")]
        [XmlAttribute(AttributeName = "operator")]
        public string Operator { get; set; }

        [MapContract(Describe = "标题")]
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [MapContract(Describe = "查询SQL")]
        [XmlAttribute(AttributeName = "sql")]
        public string Sql { get; set; }

        [XmlAnyAttribute]
        public Collection<XmlAttribute> OtherAttributes { get; set; }
    }
}