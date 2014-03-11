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

        public static bool IsBoolean(this string me)
        {
            bool b = true;
            return bool.TryParse(me, out b);
        }

        public static bool IsNumber(this string me)
        {
            int v = 0;
            return int.TryParse(me, out v);
        }

        public static bool IsBetween(this string me, int begin, int end)
        {
            int v = 0;
            int.TryParse(me, out v);
            return v >= begin && v <= end;
        }

        public static bool IsNotNull(this string me)
        {
            return me != null;
        }
    }
}