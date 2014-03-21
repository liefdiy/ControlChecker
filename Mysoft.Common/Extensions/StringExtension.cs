using System;
using System.Globalization;

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
            return String.Compare(me, other, true, CultureInfo.CurrentCulture) == 0;
        }

        public static bool ContainsIgnoreCase(this string me, string other)
        {
            return me.IndexOf(other, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static bool IsBoolean(this string me)
        {
            bool b = true;
            return bool.TryParse(me, out b);
        }

        public static bool IsNumber(this string me)
        {
            double v = 0;
            return double.TryParse(me, out v);
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

        public static bool IsNotNullOrEmpty(this string me)
        {
            return !string.IsNullOrEmpty(me);
        }

        public static bool IsTypeOfEnum(this string me, Type type)
        {
            try
            {
                Enum.Parse(type, me, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsFloat(this string me)
        {
            float result = 0f;
            return float.TryParse(me, out result);
        }

        public static bool IsDateTime(this string me, string format = "")
        {
            if (string.IsNullOrEmpty(format))
            {
                switch (me.Trim().Length)
                {
                    case 14:
                        format = "yyyy-MM-dd HH:mm";
                        break;

                    case 19:
                        format = "yyyy-MM-dd HH:mm:ss";
                        break;
                }
            }
            DateTime dt = new DateTime();
            return DateTime.TryParseExact(me, format, null, DateTimeStyles.None, out dt);
        }
    }
}