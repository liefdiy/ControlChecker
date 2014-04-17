using System;
using System.IO;
using SCide.UpdateCheckService;
using System.Reflection;
using System.Windows.Forms;
using System.Net;

namespace SCide
{
    public class UpdateProxy
    {
        public UpdateEntity UpdateEntity { get; private set; }

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
                            UpdateEntity = client.Check(titleAttribute.Title);
                            if(UpdateEntity != null)
                            {
                                Version ver = new Version(UpdateEntity.version);
                                return ver > assembly.GetName().Version;
                            }
                        }
                    }
                }
            }
            return false;
        }

        internal class DownloadParams
        {
            public HttpWebRequest Request { get; set; }
            public string DestFilePath { get; set; }
        }
    }
}