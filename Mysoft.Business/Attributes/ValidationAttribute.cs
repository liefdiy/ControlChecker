using System;

namespace ControlCheck.Business.Attributes
{
    public class ValidationAttribute : Attribute
    {
        // Methods
        public ValidationAttribute()
        {
            this.Describe = "";
            this.Order = 999;
        }

        /// <summary>
        /// 验证器描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 验证顺序
        /// </summary>
        public int Order { get; set; }
    }
}