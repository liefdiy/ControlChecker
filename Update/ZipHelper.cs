using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace Update
{
    public static class ZipHelper
    {
        private const int BufferSize = 4096;

        /// <summary>
        /// ZIP解压缩
        /// </summary>
        /// <param name="filepath">压缩包路径</param>
        /// <param name="directory">解压目录</param>
        public static string UnZip(string filepath, string directory)
        {
            string unzipDirectory = directory;

            if (!File.Exists(filepath)) return null;

            using(ZipInputStream s = new ZipInputStream(File.OpenRead(filepath)))
            {
                byte[] buffer = new byte[BufferSize];
                int size = 0;

                ZipEntry entry;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                bool isRoot = true;
                while ((entry = s.GetNextEntry()) != null)
                {
                    string path = Path.Combine(directory, entry.Name);
                    if(entry.IsDirectory)
                    {
                        var info = Directory.CreateDirectory(path);
                        if (isRoot)
                        {
                            unzipDirectory = info.FullName;
                        }
                    }
                    else if(entry.IsFile)
                    {
                        string fullname = Path.Combine(directory, entry.Name);
                        if (File.Exists(fullname))
                        {
                            File.Delete(fullname);
                        }
                        FileStream fs = new FileStream(fullname, FileMode.CreateNew);
                        while (true)
                        {
                            size = s.Read(buffer, 0, BufferSize);
                            if (size > 0)
                            {
                                fs.Write(buffer, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        fs.Close();
                    }
                    isRoot = false;
                }
                return unzipDirectory;
            }
        }
    }
}