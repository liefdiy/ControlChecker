using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mysoft.Business.Contracts
{
    [XmlRoot(ElementName = "UserCase")]
    public class UserCaseContract
    {
        [XmlElement(Type = typeof (PageModel), ElementName = "Page")]
        public List<PageModel> Pages { get; set; }

        public FrontPageContract FrontPage { get; set; }
    }
}
