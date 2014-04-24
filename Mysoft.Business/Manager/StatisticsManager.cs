using System;
using System.Net;
using System.Text;
using System.Web;
using Mysoft.Common.Utility;

namespace Mysoft.Business.Manager
{
    public enum OperationOption
    {
        Check,
        Format
    }

    public class StatisticsManager
    {
        private static readonly string IncreaseCounterUrl = System.Configuration.ConfigurationManager.AppSettings["statisticsite_IncreaseCounter"] + "?appName=ControlChecker";
        private static readonly string GetTimeUrl = System.Configuration.ConfigurationManager.AppSettings["statisticsite_GetTime"];

        //private const string AppName = "ControlChecker";

        /// <summary>
        /// 探测当前域身份是否能访问站点
        /// </summary>
        /// <returns></returns>
        public static bool CurrentIdentityCanAccess()
        {
            HttpWebResponse response = Request(GetTimeUrl, CredentialCache.DefaultCredentials);
            return response.StatusCode != HttpStatusCode.Unauthorized;
        }

        /// <summary>
        /// 调用计数器
        /// </summary>
        /// <param name="opr"></param>
        /// <param name="identity"></param>
        /// <param name="remark"></param>
        public static void IncreaseCounter(OperationOption opr, ICredentials identity, string remark = "")
        {
            string url = IncreaseCounterUrl + "&eventName=" + opr.ToString() + "&Remark=" + HttpUtility.HtmlDecode(remark);
            Request(url, identity);
        }

        public static HttpWebResponse Request(string url, ICredentials identity)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.ContentType = "application/x-www-form-urlencoded";
                request.Credentials = identity;
                return request.GetResponse() as HttpWebResponse;
            }
            catch (WebException webEx)
            {
                AppConfigManager.Setting.User.UserName = "";
                AppConfigManager.Setting.User.Password = "";

                return webEx.Response as HttpWebResponse;
            }
            catch (Exception ex)
            {
                FileHelper.Write("error.log", string.Format("---\t{0}\t---\r\n{1}\r\n{2}\r\n-------------\r\n", DateTime.Now, url, ex.StackTrace), Encoding.UTF8, true);
            }
            return null;
        }
    }
}