using ControlCheck.Business.Attributes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mysoft.Business.Controls
{
    /// <summary>
    /// appForm控件
    /// </summary>
    public class AppForm : BaseControl
    {
        public AppForm()
        {
        }

        [XmlElement(ElementName = "tab")]
        public List<AppFormTab> Tabs { get; set; }
    }

    public class AppFormTab
    {
        public AppFormTab()
        {
            Title = "";
        }

        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "section")]
        public List<AppFormSection> Sections { get; set; }
    }

    public class AppFormSection
    {
        public AppFormSection()
        {
            Title = "";
            SecId = "";
            Display = true;
        }

        [MapContract(Describe = "控件标题")]
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        /// 是否显示区域标题
        [MapContract(Describe = "是否显示区域标题", Ignore = true)]
        [XmlAttribute(AttributeName = "showtitle")]
        public bool ShowTitle { get; set; }

        /// 指定每行包含的录入控件数量
        [MapContract(Ignore = true)]
        [XmlAttribute(AttributeName = "cols")]
        public int Cols { get; set; }

        /// 控件前面的标题所占的列宽
        [MapContract(Ignore = true)]
        [XmlAttribute(AttributeName = "titlewidth")]
        public string TitleWidth { get; set; }

        [MapContract(Ignore = true)]
        [XmlAttribute(AttributeName = "secid")]
        public string SecId { get; set; }

        /// 是否显示标题分隔条
        [MapContract(Describe = "是否显示标题分隔条", Ignore = true)]
        [XmlAttribute(AttributeName = "showbar")]
        public bool ShowBar { get; set; }

        /// 是否显示标题分隔条
        [MapContract(Describe = "是否显示")]
        [XmlAttribute(AttributeName = "display")]
        public bool Display { get; set; }

        [XmlElement(ElementName = "item")]
        public List<AppFormItem> Items { get; set; }
    }



    /// <summary>
    /// 每个子控件在反序列化的时候无法区分开，除非重写序列化
    /// 因此都合并为这个类
    /// </summary>
    public class AppFormItem
    {
        public AppFormItem()
        {
            Title = "";
            Type = AppFormItemType.Text;
            Field = "";
            Updateapi = true;
            Createapi = 1;
        }

        /// <summary>
        /// “text”表示控件为文本框控件
        /// “memo”表示控件为文本区控件。
        /// “password”表示控件为密码录入控件。
        /// “number”表示控件为数字录入控件。
        /// “datetime”表示控件为日期录入控件。
        /// </summary>
        [XmlAttribute(AttributeName = "type")]
        [MapContract(Describe = "控件类型")]
        public AppFormItemType Type { get; set; }

        [XmlAttribute(AttributeName = "field")]
        [MapContract(Describe = "数据来源字段")]
        public string Field { get; set; }

        //[XmlAttribute(AttributeName = "defaultvalue")]
        //[MapContract(Describe = "控件类型")]
        //public string DefaultValue { get; set; }

        //[XmlAttribute(AttributeName = "editvalue")]
        //[MapContract(Describe = "控件类型")]
        //public string EditValue { get; set; }

        [XmlAttribute(AttributeName = "title")]
        [MapContract(Describe = "控件标题")]
        public string Title { get; set; }

        //[XmlAttribute(AttributeName = "colspan")]
        [XmlIgnore]
        public int Colspan { get; set; }

        /// 新增记录时，控件是否可填。0 为只读，1 为可填，默认值为 1。
        [XmlAttribute(AttributeName = "createapi")]
        [MapContract(Describe = "新增记录时，控件是否可填")]
        public int Createapi { get; set; }

        /// 修改记录时，控件是否可填。0 为只读，1 为可填，默认值为 1。
        [XmlAttribute(AttributeName = "updateapi")]
        [MapContract(Describe = "修改记录时，控件是否可填")]
        public bool Updateapi { get; set; }

        /// 是否必填项。0 为非必填，1 为必填，2 为建议填写，默认值为 0 。
        [XmlAttribute(AttributeName = "req")]
        [MapContract(Describe = "是否必填项", EnumType = typeof(RequireLevel))]
        public int Req { get; set; }

        [XmlElement(ElementName = "attribute")]
        public AppControlAttribute OtherAttributes { get; set; }
    }
}