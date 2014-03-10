using Mysoft.Business.Validation.Db;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mysoft.Business.Validation
{
    public static class CommonValidation
    {
        private static readonly Regex EqualRegex = new Regex(@"[1-4]+\s*=\s*[1-4]+", RegexOptions.IgnoreCase);

        #region 公共方法

        public static string GetFilter(string sql)
        {
            //替换类似1=1
            string temp = EqualRegex.Replace(sql, "1=2");

            //移除类似[本人]的查询关键字
            temp = DbAccessManager.Keyword.Aggregate(temp, (current, k) => current.Replace(k, "(null)"));

            return temp;
        }

        public static void ExecuteSql(string sql)
        {
            SqlConnection conn = new SqlConnection(DbAccessManager.Connectstring);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool HasSqlKeywords(string sql)
        {
            return Regex.IsMatch(sql, @"[^\w]+(option|COMPUTE)[^\w]+", RegexOptions.IgnoreCase);
        }

        public static string GetPageSqlByNotIn(string sql, string entity, string primaryKey)
        {
            string strSql = sql.Substring(sql.IndexOf("SELECT ") + 6);
            strSql = "SELECT TOP 10 " + strSql;

            if (!string.IsNullOrEmpty(primaryKey))
            {
                var strTemp = ((string.IsNullOrEmpty(entity)) ? "" : entity + ".") + primaryKey.Replace("\'", "\'\'") + " NOT IN (SELECT TOP 10 " + ((string.IsNullOrEmpty(entity)) ? "" : entity + ".") + primaryKey.Replace("\'", "\'\'") + " " + Regex.Replace(strSql, ".*?FROM\\b", "FROM", RegexOptions.Singleline) + ")";
                if (strSql.LastIndexOf("WHERE ") > 0)
                {
                    strSql = strSql.Replace("WHERE ", "WHERE " + strTemp + " AND ");
                }
                else if (strSql.IndexOf("ORDER BY ") > 0)
                {
                    strSql = strSql.Replace("ORDER BY ", "WHERE " + strTemp + " ORDER BY ");
                }
                else
                {
                    strSql += " WHERE " + strTemp;
                }
                return strSql;
            }

            return sql;
        }

        public static string GetPageSqlByRowNumber(string strSql)
        {
            int index = strSql.LastIndexOf("ORDER BY");
            strSql = "WITH _t AS (SELECT ROW_NUMBER() OVER(" + strSql.Substring(index) + ") AS _RowNumber," + strSql.Substring(0, index) + ")" + " SELECT * FROM _t" + " WHERE _RowNumber BETWEEN 0 AND 10 ORDER BY _RowNumber";
            return strSql;
        }

        public static bool CheckCase(string sql, int pagemode)
        {
            if (pagemode == 1 || pagemode == 2)
            {
                if (!Regex.IsMatch(sql, "(SELECT|FROM|WHERE)", RegexOptions.CultureInvariant))
                {
                    return false;
                }

                int start = sql.IndexOf("(");
                if (start >= 0)
                {
                    int end = sql.IndexOf(")", start);
                    string temp = sql.Substring(start, end - start);
                    if (Regex.IsMatch(temp, "(SELECT|FROM|WHERE)", RegexOptions.CultureInvariant))
                    {
                        return false;
                    }
                }


            }

            return true;
        }

        #endregion 公共方法
    }
}