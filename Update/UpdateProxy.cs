using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using Update.UpdateCheckService;

namespace Update
{
    public class UpdateProxy
    {
        private UpdateEntity updateEntity = null;

        private event EventHandler _OnDownloadFinished;

        public event EventHandler OnDownloadFinished
        {
            add { _OnDownloadFinished += value; }
            remove { _OnDownloadFinished -= value; }
        }

        public bool HasUpdate()
        {
            string filepath = Application.ExecutablePath;

            using (UpdateCheckSoapClient client = new UpdateCheckSoapClient())
            {
                if (File.Exists(filepath))
                {
                    Assembly assembly = Assembly.LoadFrom(filepath);
                    object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                    if (attributes.Length > 0)
                    {
                        // 请选择第一个属性
                        AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                        // 如果该属性为非空字符串，则将其返回
                        if (titleAttribute.Title != "")
                        {
                            updateEntity = client.Check(titleAttribute.Title);
                            if (updateEntity != null)
                            {
                                Version ver = new Version(updateEntity.version);
                                return ver > assembly.GetName().Version;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public void Download(string destPath)
        {
            HttpWebRequest request = WebRequest.Create(updateEntity.packagepath) as HttpWebRequest;
            if (request == null) return;

            DownloadParams dp = new DownloadParams();
            dp.Request = request;
            dp.DestFilePath = destPath;

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
                    BinaryReader br = new BinaryReader(stream);
                    FileStream fs = File.Create(dp.DestFilePath ?? "temp.zip");
                    fs.Write(br.ReadBytes(length), 0, length);
                    br.Close();
                    fs.Close();
                    response.Close();

                    if (_OnDownloadFinished != null)
                    {
                        _OnDownloadFinished(this, null);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal class DownloadParams
        {
            public HttpWebRequest Request { get; set; }

            public string DestFilePath { get; set; }
        }
    }
}