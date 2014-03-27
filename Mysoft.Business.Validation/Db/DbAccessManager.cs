using Mysoft.Business.Manager;
using Mysoft.Map.Extensions.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mysoft.Business.Validation.Db
{
    public class DbAccessManager
    {
        private static bool s_status = false;

        public static string Connectstring
        {
            get { return AppConfigManager.ConnectionString; }
        }

        public static void Init(string connstring)
        {
            if (!IsValidConnectString(connstring)) return;

            if (!s_status)
            {
                try
                {
                    //如何多次初始化，要更改连接字符串
                    Mysoft.Map.Extensions.Initializer.UnSafeInit(connstring);
                    s_status = true;
                    LoadKeyWord();
                }
                catch (Exception)
                {
                }
            }
        }

        public static void Reset()
        {
            LoadKeyWord();
        }

        private static bool IsValidConnectString(string connstring)
        {
            bool isvalid = !string.IsNullOrEmpty(connstring);

            bool standard = isvalid;
            standard = standard && connstring.IndexOf("server", StringComparison.OrdinalIgnoreCase) >= 0;
            standard = standard && connstring.IndexOf("database", StringComparison.OrdinalIgnoreCase) >= 0;

            bool trusted = isvalid;
            trusted = trusted && connstring.IndexOf("Data Source", StringComparison.OrdinalIgnoreCase) >= 0;
            trusted = trusted && connstring.IndexOf("Initial Catalog", StringComparison.OrdinalIgnoreCase) >= 0;

            bool sspi = isvalid;
            sspi = sspi && connstring.IndexOf("Integrated Security", StringComparison.OrdinalIgnoreCase) >= 0;

            return isvalid && (standard || trusted || sspi);
        }

        public static readonly List<string> Keyword = new List<string>();

        private static void LoadKeyWord()
        {
            DataTable table = CPQuery.From("SELECT KeywordName FROM dbo.myKeyword").FillDataTable();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Keyword.Add(table.Rows[i][0].ToString().Trim());
            }
        }
    }   // class DBAccessManager
}