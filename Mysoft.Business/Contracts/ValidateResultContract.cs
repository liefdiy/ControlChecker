//using ControlCheck.Business.Attributes;
//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Xml.Serialization;

//namespace Mysoft.Business.Contracts
//{
//    [XmlRoot(ElementName = "ValidateResult")]
//    public class ValidateResultContract
//    {
//        [XmlElement(Type = typeof(PageModel), ElementName = "Page")]
//        public List<PageModel> Pages { get; set; }
//    }

//    [XmlType(TypeName = "Page")]
//    public class PageModel
//    {
//        public PageModel()
//        {
//            Url = "";
//            Describe = "";
//            Title = "";
//        }

//        [MapContract(Describe = "页面地址")]
//        [XmlAttribute(AttributeName = "url")]
//        public string Url { get; set; }

//        [MapContract(Describe = "页面XML")]
//        [XmlAttribute(AttributeName = "xml")]
//        public string Xml { get; set; }

//        [MapContract(Describe = "页面标题")]
//        [XmlAttribute(AttributeName = "title")]
//        public string Title { get; set; }

//        [MapContract(Describe = "页面备注")]
//        [XmlAttribute(AttributeName = "describe")]
//        public string Describe { get; set; }

//        [XmlArrayItem(Type = typeof(ControlModel), ElementName = "Control")]
//        public List<ControlModel> Controls { get; set; }
//    }

//    public class ControlModel
//    {
//        public ControlModel()
//        {
//            Describe = "";
//            Type = "";
//            Name = "";
//            Result = true;
//            Properties = new List<PropertyModel>();
//            Children = new List<ControlModel>();
//        }

//        [XmlAttribute(AttributeName = "name")]
//        public string Name { get; set; }

//        [XmlAttribute(AttributeName = "describe")]
//        public string Describe { get; set; }

//        [XmlAttribute(AttributeName = "type")]
//        public string Type { get; set; }

//        [XmlAttribute(AttributeName = "result")]
//        public bool Result { get; set; }

//        [XmlArray(ElementName = "Properties"), XmlArrayItem(Type = typeof(PropertyModel), ElementName = "Property")]
//        public List<PropertyModel> Properties { get; set; }

//        [XmlArrayItem(Type = typeof(ControlModel), ElementName = "Control")]
//        public List<ControlModel> Children { get; set; }

//        [XmlIgnore]
//        public object Token { get; set; }
//    }

//    public class PropertyModel
//    {
//        public PropertyModel()
//        {
//            Name = "";
//            Describe = "";
//            Type = "";
//            Value = "";
//            Result = true;
//            Expect = null;
//            Actual = null;
//            Options = null;
//        }

//        [XmlAttribute(AttributeName = "name")]
//        public string Name { get; set; }

//        [XmlAttribute(AttributeName = "describe")]
//        public string Describe { get; set; }

//        [XmlAttribute(AttributeName = "type")]
//        public string Type { get; set; }

//        [XmlAttribute(AttributeName = "value")]
//        public string Value { get; set; }

//        [XmlAttribute(AttributeName = "displayvalue")]
//        public string DisplayValue { get; set; }

//        [XmlAttribute(AttributeName = "result")]
//        public bool Result { get; set; }

//        [XmlAttribute(AttributeName = "expect")]
//        public string Expect { get; set; }

//        [XmlAttribute(AttributeName = "actual")]
//        public string Actual { get; set; }

//        [XmlElement(ElementName = "Option")]
//        public List<PropertyOption> Options { get; set; }

//        public static List<PropertyModel> Convert(object obj)
//        {
//            List<PropertyModel> list = new List<PropertyModel>();
//            if (obj == null) return list;

//            PropertyInfo[] properties = obj.GetType().GetProperties();
//            foreach (PropertyInfo property in properties)
//            {
//                object[] attrs = property.GetCustomAttributes(typeof(XmlAttributeAttribute), false);
//                object[] mcattrs = property.GetCustomAttributes(typeof(MapContractAttribute), false);

//                if (attrs.Length > 0)
//                {
//                    XmlAttributeAttribute a = attrs[0] as XmlAttributeAttribute;
//                    PropertyModel pm = new PropertyModel();
//                    MapContractAttribute mc = null;
//                    if (mcattrs.Length > 0)
//                    {
//                        mc = mcattrs[0] as MapContractAttribute;
//                        pm.Describe = mc.Describe;
//                    }

//                    pm.Name = a.AttributeName;
                    
//                    object o = property.GetValue(obj, null);
//                    if (o != null)
//                    {
//                        Type otype = mc.EnumType ?? property.PropertyType;

//                        if (otype.IsValueType || otype == typeof(string))
//                        {
//                            pm.Value = property.GetValue(obj, null).ToString();
//                        }

//                        if (otype == typeof (bool))
//                        {
//                            pm.Value = pm.Value.ToLower();
//                        }

//                        if (otype.IsEnum)
//                        {
//                            pm.Options = new List<PropertyOption>();
//                            pm.Value = System.Convert.ToInt32(o).ToString();
//                            var enumMembers = Enum.GetValues(otype);
//                            foreach (var enumMember in enumMembers)
//                            {
//                                PropertyOption option = new PropertyOption();
//                                option.Value = ((int)enumMember).ToString();
//                                option.Text = enumMember.ToString().ToLower();
//                                pm.Options.Add(option);
//                            }
//                            pm.DisplayValue = Enum.GetName(otype, o).ToLower();
//                        }
//                        pm.Type = SwitchTypeName(otype);
//                    }

//                    list.Add(pm);
//                }
//            }

//            return list;
//        }

//        private static string SwitchTypeName(Type type)
//        {
//            if (type == typeof (int))
//            {
//                return "int";
//            }
//            else if (type.IsEnum)
//            {
//                return "list";
//            }
//            else
//            {
//                return type.Name.ToLower();
//            }
//        }
//    }

//    public class PropertyOption
//    {
//        [XmlAttribute(AttributeName = "value")]
//        public string Value { get; set; }

//        [XmlText]
//        public string Text { get; set; }
//    }
//}