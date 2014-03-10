using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;
using ControlCheck.Business.Attributes;

namespace Mysoft.Business.Controls
{
    [XmlType(TypeName = "attribute")]
    public class AppControlAttribute
    {
        public AppControlAttribute()
        {
            Name = "";
            Field = "";
            DataType = "";
            Attributes = new Collection<XmlAttribute>();
        }

        [MapContract(Ignore = true)]
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [MapContract(Ignore = true)]
        [XmlAttribute(AttributeName = "field")]
        public string Field { get; set; }

        [MapContract(Ignore = true)]
        [XmlAttribute(AttributeName = "datatype")]
        public string DataType { get; set; }

        [XmlAnyAttribute]
        public Collection<XmlAttribute> Attributes { get; set; }
    }
}