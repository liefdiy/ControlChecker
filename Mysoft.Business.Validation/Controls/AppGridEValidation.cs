using Mysoft.Business.Controls;
using Mysoft.Business.Validation.Entity;
using Mysoft.Common.Extensions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Mysoft.Business.Validation.Controls
{
    public class AppGridEValidation : AppValidationBase
    {
        public override void Validate(AppControl control)
        {
            AppGrid grid = control.Control as AppGrid;
            if (grid == null)
            {
                return;  //不是grid
            }

            var ds = control.DataSource;
            if (ds == null)
            {
                Results.Add(new Result("AppGridE", "未配置数据源", Level.Warn, typeof(AppGridEValidation)));
                return;
            }

            if (grid.Row != null && grid.Row.AppGridCells.Count > 0)
            {
                List<bool> _sumtype = new List<bool>();
                string _strSumTemp = "";

                if(grid.Summary != null && grid.Summary.AppGridCells.Count > 0)
                {
                    for (int i = 0; i < grid.Summary.AppGridCells.Count; i++)
                    {
                        var scell = grid.Summary.AppGridCells[i];
                        if(scell.SumTotalField.IsNotNullOrEmpty())
                        {
                            _strSumTemp += "," + scell.SumTotalField + " AS _s" + i;
                        }
                    }
                }

                //appGridE, appGrid
                foreach (var cell in grid.Row.AppGridCells)
                {
                    string strSql1 = "", strSql2 = "", _strSQL = "";
                    string error = string.Empty;

                    //替换关键字
                    string strSQL = CommonValidation.GetFilter(ds.Sql);

                    if (ds.PageMode.EqualIgnoreCase("2"))
                    {
                        string[] arrSql = SplitSql(strSQL);

                        if (arrSql != null)
                        {
                            strSql1 = arrSql[0];				    // 外层不带“SELECT”关键字的部分 SQL 语句
                            strSQL = arrSql[1];				        // 内层从“SELECT”关键字开始的 SQL 语句
                            strSql2 = GetSortedSql(arrSql[2], cell, ds);	// 外层 SQL
                        }
                    }

                    strSQL = GetSortedSql(strSQL, cell, ds);

                    //是否分页allowpaging, pageSize == 0
                    //allowpaing
                    if(ds.KeyName.IsNotNullOrEmpty())
                    {
                        //取记录数 if showPageCount
                        string strSQLTemp = Regex.Replace(strSQL, @"SELECT\s+([\w|\W]+)\s+FROM", "SELECT COUNT(*)" + _strSumTemp + " FROM");
                        strSQLTemp = Regex.Replace(strSQLTemp, @"\s+ORDER BY([\w|\W]+)", "");
                        if (!ValidateSql(strSQLTemp, out error))
                        {
                            Results.Add(new Result(string.Format("检查数据列{0}", cell.Field),
                                                string.Format("{0}字段当showPageCount == true时会出错：{1}", cell.OrderBy, error), Level.Error,
                                                GetType()));
                            return;
                        }
                        
                        if (ds.PageMode.EqualIgnoreCase("2"))
                        {
                            _strSQL = GetPageSql(strSQL, ds.Entity, ds.KeyName);
                            _strSQL = strSql1 + _strSQL + strSql2;
                        }
                        else
                        {
                            _strSQL = GetPageSql(strSQL, ds.Entity, ds.KeyName);
                        }
                    }
                    else
                    {
                        //不指定主键的分页查询
                    }

                    if (strSQL.IsNotNullOrEmpty() && !ValidateSql(_strSQL, out error))
                    {
                        Results.Add(new Result(string.Format("检查数据列{0}", cell.Field),
                                                string.Format("排序字段配置错误{0}：{1}", cell.OrderBy, error), Level.Error,
                                                GetType()));
                    }

                    if (cell.Attribute != null)
                    {
                        foreach (var attr in cell.Attribute.Attributes)
                        {
                            if (attr.Name.EqualIgnoreCase("sql"))
                            {
                                if (CommonValidation.IsIncorrectSql(attr.Value))
                                {
                                    Results.Add(new Result("AppGridE",
                                                            string.Format("[{0}]单元格的SQL有误：{1}", cell.Title,
                                                                            attr.Value), Level.Error,
                                                            typeof(AppGridEValidation)));
                                }
                            }
                        }
                    }
                }
            }
        }

        private string GetSortedSql(string sql, AppGridCell cell, DataSource ds)
        {
            string entity = ds.Entity;
            string pk = ds.KeyName;

            if (cell.Sortable.EqualIgnoreCase("true"))
            {
                //如果orderby为空则取entity.field作为排序条件，否则用orderby
                string strSortCol = cell.OrderBy.IsNotNullOrEmpty() ? cell.OrderBy : cell.Field;

                if (sql.LastIndexOf("ORDER BY") >= 0)
                {
                    //用当前列的orderby替换配置中的排序字段
                    sql = sql.Substring(0, sql.LastIndexOf("ORDER BY")) + "ORDER BY ";
                }
                else
                {
                    sql += " ORDER BY ";
                }

                if (cell.DataType.EqualIgnoreCase("text") || cell.DataType.EqualIgnoreCase("ntext"))
                {
                    strSortCol = "cast(" + strSortCol + " as varchar(2000))";
                }

                sql += strSortCol;

                if (pk.IsNotNullOrEmpty())
                {
                    if (!Regex.IsMatch(strSortCol, @"(^|\W)(" + pk + @")(\W|$)", RegexOptions.IgnoreCase))
                    {
                        sql += ",";
                        if (string.IsNullOrEmpty(entity))
                            sql += pk;
                        else
                            sql += entity + "." + pk;
                    }
                }
            }

            return sql;
        }

        /// <summary>
        /// 拆分 SQL 中排序子句的各排序列
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private List<string> SplitOrderString(string s)
        {
            bool bInQuot = false;   //是否在引号中
            int intParentheses = 0; //括号层数
            int intCount = s.Length - 1;
            int intLastIndex = 0;
            var arrCols = new List<string>();

            for (int i = 0; i < intCount; i++)
            {
                string t = s.Substring(i, 1);
                switch (t)
                {
                    case ",":
                        if (!bInQuot && intParentheses == 0)
                        {
                            arrCols.Add(s.Substring(intLastIndex, i - intLastIndex));
                            intLastIndex = i + 1;
                        }
                        break;

                    case "'":
                        if (bInQuot)
                        {
                            if (intCount > i && s.Substring(i + 1, 1) == "'")
                            {
                                i++;
                            }
                        }
                        bInQuot = !bInQuot;
                        break;

                    case "(":
                        if (!bInQuot) intParentheses++;
                        break;

                    case ")":
                        if (!bInQuot) intParentheses--;
                        break;

                    default:
                        break;
                }
            }
            arrCols.Add(s.Substring(intLastIndex));
            return arrCols;
        }

        private string[] SplitSql(string sql)
        {
            string[] arrSql = new string[3];
            int intIndex = sql.IndexOf("SELECT ");
            if (intIndex < 0)
                return null;

            arrSql[0] = sql.Substring(0, intIndex);		// 第一段 SQL

            sql = sql.Substring(intIndex);
            intIndex = SeekSqlEnd(sql);

            arrSql[1] = sql.Substring(0, intIndex);		// 第二段 SQL
            arrSql[2] = sql.Substring(intIndex);	// 第三段 SQL

            return arrSql;
        }

        private int SeekSqlEnd(string s)
        {
            bool bInQuot = false;   //是否在引号中
            int intParentheses = 0; //括号层数
            int intCount = s.Length - 1;
            int i = 0;
            for (; i < intCount; i++)
            {
                string t = s.Substring(i, 1);
                switch (t)
                {
                    case "'":
                        if (!bInQuot)
                        {
                            bInQuot = true;
                        }
                        else if (intCount > (i + 1) && s.Substring(i + 1, 1) == "'")
                        {
                            i++;
                        }
                        else
                        {
                            bInQuot = false;
                        }
                        break;

                    case "(":
                        if (!bInQuot) intParentheses++;
                        break;

                    case ")":
                        if (!bInQuot)
                        {
                            intParentheses--;
                            if (intParentheses < 0) return i;
                        }
                        break;

                    default:
                        break;
                }
            }
            return i;
        }

        private string GetPageSql(string sql, string entity, string primaryKey)
        {
            string strSql = sql.Substring(sql.IndexOf("SELECT ") + 6);
            strSql = "SELECT TOP 10" + strSql;
            if (primaryKey.IsNotNullOrEmpty())
            {
                string s = (entity.IsNotNullOrEmpty() ? entity + "." : "") + primaryKey.Replace("'", "''");
                string strTemp = strSql.Substring(strSql.IndexOf("FROM"));
                strTemp = s + " NOT IN (SELECT TOP 10 " + s + " " + strTemp + ")";

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
                    strSql = " WHERE " + strTemp;
                }
            }
            return strSql;
        }
    }
}