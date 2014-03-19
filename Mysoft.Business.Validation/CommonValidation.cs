using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Schema.ScriptDom;
using Microsoft.Data.Schema.ScriptDom.Sql;

namespace Mysoft.Business.Validation
{
    using Mysoft.Business.Validation.Db;
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class CommonValidation
    {
        private static readonly Regex EqualRegex = new Regex(@"[1-4]+\s*=\s*[1-4]+", RegexOptions.IgnoreCase);

        /// <summary>
        /// 校验SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool IsIncorrectSql(string sql)
        {
            TSql100Parser parser = new TSql100Parser(false);
            IList<ParseError> errors = new List<ParseError>();
            using (StringReader reader = new StringReader(sql))
            {
                parser.Parse(reader, out errors);
                return (errors.Count > 0);
            }
        }

        public static bool CheckCase(string sql, int pagemode)
        {
            if ((pagemode == 1) || (pagemode == 2))
            {
                if (!Regex.IsMatch(sql, "(SELECT|FROM|WHERE)", RegexOptions.CultureInvariant))
                {
                    return false;
                }
                int start = sql.IndexOf("(");
                if (start >= 0)
                {
                    int end = sql.IndexOf(")", start);
                    //如果子查询使用了大写
                    if (Regex.IsMatch(sql.Substring(start, end - start), "(SELECT|FROM|WHERE)", RegexOptions.CultureInvariant))
                    {
                        return false;
                    }

                    //如果SQL语句最后，最外层使用了小写
                    if (Regex.IsMatch(sql.Substring(end), "(order|by|where)", RegexOptions.CultureInvariant))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void ExecuteSql(string sql)
        {
            SqlConnection conn = new SqlConnection(DbAccessManager.Connectstring);
            try
            {
                conn.Open();
                new SqlCommand(sql, conn).ExecuteNonQuery();
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

        public static string GetFilter(string sql)
        {
            string temp = EqualRegex.Replace(sql, "1=2");
            return DbAccessManager.Keyword.Aggregate<string, string>(temp, (current, k) => current.Replace(k, "(null)")).Replace("[授权系统]", "select application from myapplication").Replace("[用户所属公司及下级公司过滤]", "''");
        }

        public static string GetPageSqlByNotIn(string sql, string entity, string primaryKey)
        {
            string strSql = sql.Substring(sql.IndexOf("SELECT ") + 6);
            strSql = "SELECT TOP 10 " + strSql;
            if (string.IsNullOrEmpty(primaryKey))
            {
                return sql;
            }
            string strTemp = (string.IsNullOrEmpty(entity) ? "" : (entity + ".")) + primaryKey.Replace("'", "''") + " NOT IN (SELECT TOP 10 " + (string.IsNullOrEmpty(entity) ? "" : (entity + ".")) + primaryKey.Replace("'", "''") + " " + Regex.Replace(strSql, @".*?FROM\b", "FROM", RegexOptions.Singleline) + ")";
            if (strSql.LastIndexOf("WHERE ") > 0)
            {
                return strSql.Replace("WHERE ", "WHERE " + strTemp + " AND ");
            }
            if (strSql.IndexOf("ORDER BY ") > 0)
            {
                return strSql.Replace("ORDER BY ", "WHERE " + strTemp + " ORDER BY ");
            }
            return (strSql + " WHERE " + strTemp);
        }

        public static string GetPageSqlByRowNumber(string strSql)
        {
            int index = strSql.LastIndexOf("ORDER BY");
            strSql = "WITH _t AS (SELECT ROW_NUMBER() OVER(" + strSql.Substring(index) + ") AS _RowNumber," + strSql.Substring(0, index) + ") SELECT * FROM _t WHERE _RowNumber BETWEEN 0 AND 10 ORDER BY _RowNumber";
            return strSql;
        }

        public static bool HasSqlKeywords(string sql)
        {
            return Regex.IsMatch(sql, @"[^\w]+(option|COMPUTE)[^\w]+", RegexOptions.IgnoreCase);
        }
    }
}