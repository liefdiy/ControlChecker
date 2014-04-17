using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Update
{
    public partial class FrmDownload : Form
    {
        private string Url = "";
        private string ProcessName = "";
        private const int BufferSize = 4018;

        private SynchronizationContext _context;

        public FrmDownload(string url, string procName)
        {
            InitializeComponent();
            Url = url;
            ProcessName = procName;
            _context = SynchronizationContext.Current;
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                Download(Url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Url);
                Application.Exit();
                Environment.Exit(0);
            }

            base.OnLoad(e);
        }

        private void Download(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 10000;    //10s超时
            if (request == null) return;

            DownloadParams dp = new DownloadParams();
            dp.Request = request;
            dp.DestFilePath = Path.Combine(Application.StartupPath, "temp.zip");

            request.BeginGetResponse(AsyncCallBack, dp);
        }

        private void AsyncCallBack(IAsyncResult ar)
        {
            try
            {
                if (ar.IsCompleted)
                {
                    DownloadParams dp = ar.AsyncState as DownloadParams;
                    HttpWebResponse response = dp.Request.EndGetResponse(ar) as HttpWebResponse;
                    Stream stream = response.GetResponseStream();

                    int length = (int)response.ContentLength;

                    byte[] buffer = new byte[BufferSize];
                    int count = 0;
                    using (FileStream filestream = new FileStream(dp.DestFilePath ?? "temp.zip", FileMode.Create))
                    {
                        int downloaded = 0;
                        while (true)
                        {
                            count = stream.Read(buffer, 0, BufferSize);
                            downloaded += count;

                            if (count > 0)
                            {
                                //notice
                                filestream.Write(buffer, 0, count);
                                _context.Post(d => { this.lb_progress.Text = d + "%"; }, downloaded * 100 / length);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    response.Close();

                    //unzip
                    ZipHelper.UnZip(dp.DestFilePath, Application.StartupPath);
                    File.Delete(dp.DestFilePath);

                    if (!string.IsNullOrEmpty(ProcessName))
                    {
                        //run controlchecker
                        Process process = new Process();
                        process.StartInfo.FileName = ProcessName;
                        process.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Url);
            }
            finally
            {
                Application.Exit();
                Environment.Exit(0);
            }
        }

        internal class DownloadParams
        {
            public HttpWebRequest Request { get; set; }

            public string DestFilePath { get; set; }
        }
    }
}