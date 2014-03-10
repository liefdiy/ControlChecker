using System;

namespace ControlCheck.Business.Attributes
{
    public class MapContractAttribute : Attribute
    {
        public string Type { get; set; }

        public string Describe { get; set; }

        public bool Ignore { get; set; }

        public Type EnumType { get; set; }

        /// <summary>
        /// 是否必须字段
        /// </summary>
        public bool Required { get; set; }
    }
}