using System;
using System.Windows.Forms;

namespace Update
{
    static class Program
    {
        /// <summary>
        /// 通用下载更新程序
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ////for test
            //args = new string[4];
            //args[0] = "-d";
            //args[1] = @"http://localhost:38764/MyControlChecker_v1.0.0.0.zip";
            //args[2] = "-f";
            //args[3] = @"E:\360云盘\Mysoft\源码\MySourceCode\ControlChecker\bin\Debug\MyControlChecker.EXE";

            if(args != null && args.Length > 0)
            {
                //url: 要下载的zip文件地址， processName下载后要执行的程序路径
                string url = "", processName = "", temp = "";

                for (int i = 0; i < args.Length; i++)
                {
                    temp = args[i];
                    if (temp.Equals("-d", StringComparison.OrdinalIgnoreCase))
                    {
                        if((i+1) < args.Length)
                        {
                            url = args[++i];
                        }
                    }
                    else if (temp.Equals("-f", StringComparison.OrdinalIgnoreCase))
                    {
                        if((i+1) < args.Length)
                        {
                            processName = args[++i];
                        }
                    }
                }
                if(string.IsNullOrEmpty(url) || string.IsNullOrEmpty(processName))
                {
                    return;    
                }

                //download from url
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmDownload(url, processName));
            }
        }
    }
}
