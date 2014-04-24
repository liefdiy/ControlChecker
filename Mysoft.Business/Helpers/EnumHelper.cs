using ControlCheck.Business.Attributes;
using Mysoft.Business.Controls;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mysoft.Business.Helpers
{
    public class EnumKvPair
    {
        public EnumKvPair()
        {
            
        }

        public EnumKvPair(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; set; }

        public string Value { get; set; }
    }

    public class EnumHelper
    {
        static Dictionary<Type, List<EnumKvPair>> _cache = new Dictionary<Type, List<EnumKvPair>>();

        /// <summary>
        /// 读取枚举类型的Text、Value，Text为MapContractAttribute.Describe，Value为XmlEnumAttribute.Name
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<EnumKvPair> GetEnumKeyValue(Type enumType)
        {
            if(_cache.ContainsKey(enumType))
            {
                return _cache[enumType];
            }

            var enumMembers = Enum.GetValues(enumType);
            List<EnumKvPair> kvPairs = new List<EnumKvPair>();

            foreach (var enumMember in enumMembers)
            {
                EnumKvPair kp = new EnumKvPair();

                var p = typeof(OperatorType).GetField(enumMember.ToString());

                var attrs = p.GetCustomAttributes(typeof(MapContractAttribute), false);
                if (attrs.Length > 0)
                {
                    var mp = attrs[0] as MapContractAttribute;
                    if (mp != null)
                        kp.Text = mp.Describe;
                }

                var xmlAttrs = p.GetCustomAttributes(typeof(XmlEnumAttribute), false);
                if (xmlAttrs.Length > 0)
                {
                    var xml = xmlAttrs[0] as XmlEnumAttribute;
                    if (xml != null)
                        kp.Value = xml.Name;
                }

                kvPairs.Add(kp);
            }
            _cache.Add(enumType, kvPairs);
            return kvPairs;
        }
    }
}