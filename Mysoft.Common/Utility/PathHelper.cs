using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Mysoft.Common.Utility
{
    public static class PathHelper
    {
        private static string AbsoluteDir = "";

        public static void SetAbsoluteDir(string path)
        {
            if (string.IsNullOrEmpty(AbsoluteDir))
            {
                AbsoluteDir = path;
            }
            if (!Directory.Exists(AbsoluteDir))
            {
                throw new DirectoryNotFoundException("指定站点根目录无效");
            }
        }

        public static string MapPath(string url)
        {
            string path = string.Empty;
            if (HttpContext.Current != null)
            {
                path = HttpContext.Current.Server.MapPath(url);
            }
            else
            {
                if (url.IndexOf(@"/") == 0 || url.IndexOf(@"\") == 0)
                {
                    url = url.Substring(1);
                }

                path = Path.Combine(AbsoluteDir, url).Replace("/", @"\");
            }
            return path;
        }

        public static string CreateDir(string url)
        {
            if (!Directory.Exists(url))
            {
                return Directory.CreateDirectory(url).FullName;
            }
            return url;
        }

        public static List<string> GetDirectory(string root, string filter)
        {
            List<string> list = new List<string>();
            string[] ignoredir = filter.Split(';');
            if (!Directory.Exists(root)) throw new DirectoryNotFoundException(root + "路径不存在");

            string[] directories = Directory.GetDirectories(root, "");
            foreach (string directory in directories)
            {
            }

            return list;
        }
    }
}