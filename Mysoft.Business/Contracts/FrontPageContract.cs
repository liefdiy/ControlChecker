using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mysoft.Business.Contracts
{
    [XmlRoot(ElementName = "Page")]
    public class FrontPageContract
    {
        public FrontPageContract()
        {
            Id = "";
            Url = "";
            Xml = "";
            Title = "";
        }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }

        [XmlAttribute(AttributeName = "xml")]
        public string Xml { get; set; }

        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "SubPage")]
        public List<FrontPageContract> SubPages { get; set; }
    }
}