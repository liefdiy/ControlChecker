using System;

namespace ControlCheck.Business.Attributes
{
    public class MapContractAttribute : Attribute
    {
        // Methods
        public MapContractAttribute()
        {
            this.Type = FieldType.String;
            this.Describe = "";
            this.InvalidMessage = "";
        }

        public string Describe { get; set; }

        /// <summary>
        /// 枚举输出文字
        /// </summary>
        public string EnumText { get; set; }

        /// <summary>
        /// 对应枚举
        /// </summary>
        public Type EnumType { get; set; }

        /// <summary>
        /// 配置值对应枚举的类型，对应枚举的字符串还是int值
        /// </summary>
        public EnumValueType EnumValueType { get; set; }

        /// <summary>
        /// 验证失败时的提示
        /// </summary>
        public string InvalidMessage { get; set; }

        /// <summary>
        /// 是否必须字段
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// 是否跳过验证
        /// </summary>
        public bool PassValid { get; set; }

        /// <summary>
        /// 验证的正则表达式，当Type为Custom时生效
        /// </summary>
        public string Regex { get; set; }

        /// <summary>
        /// 配置值限定类型
        /// </summary>
        public FieldType Type { get; set; }
    }

    public enum EnumValueType
    {
        Text,
        Value
    }

    public enum FieldType
    {
        String,
        Number,
        Float,
        DateTime,
        Boolean,
        Custom
    }
}