using System;

namespace Mysoft.Common.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 字符串比较，忽略大小写
        /// </summary>
        /// <param name="me"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool EqualIgnoreCase(this string me, string other)
        {
            return String.Compare(me, other, true, System.Globalization.CultureInfo.CurrentCulture) == 0;
        }
    }
}