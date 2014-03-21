using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mysoft.Business.Controls;
using Mysoft.Business.Validation.Entity;
using Mysoft.Common.Extensions;

namespace Mysoft.Business.Validation.Controls
{
    public class AppGridEValidation : AppValidationBase
    {
        public override void Validate(AppControl control)
        {
            AppGrid grid = control.Control as AppGrid;
            if (grid == null) return;  //不是grid

            var ds = control.DataSource;

            if (grid.Row != null && grid.Row.AppGridCells.Count > 0)
            {
                if (!string.IsNullOrEmpty(grid.Row.AppGridCells[0].CellType))
                {
                    //appGridE
                    var fieldDic = GetFieldsDic(ds.Sql);

                    string format = GetSqlFormat(ds);

                    foreach (var cell in grid.Row.AppGridCells)
                    {
                        if (cell.Attribute == null) continue;
                        foreach (var attr in cell.Attribute.Attributes)
                        {
                            if (attr.Name.EqualIgnoreCase("sql"))
                            {
                                if (CommonValidation.IsIncorrectSql(attr.Value))
                                {
                                    Results.Add(new Result("AppGridE", string.Format("[{0}]单元格的SQL有误：{1}", cell.Title, attr.Value), Level.Error, typeof(AppGridEValidation)));
                                }
                            }
                        }

                        if (ds != null)
                        {
                            if (!string.IsNullOrEmpty(cell.OrderBy))
                            {
                                if (fieldDic[cell.Field.ToLower()].Name.EqualIgnoreCase("text"))
                                {
                                    if (false == (cell.OrderBy.ContainsIgnoreCase("as") && cell.OrderBy.ContainsIgnoreCase("varchar")))
                                    {
                                        //如果是text或ntext类型，必须转为varchar，如果
                                        //todo: 版本区分
                                        //如何从DataTable中知道该字段在数据库中的类型？数据库查询需要区分该字段来源是表还是视图还是什么？
                                    }
                                }
                            }
                            else
                            {
                                string orderby = ds.Entity + "." + cell.Field;
                                //execute
                            }
                        }
                    }
                }
            }
        }

        private string GetSqlFormat(DataSource ds)
        {
            //未包含as varchar, as nvarchar
            string strSql = ds.Sql.Substring(ds.Sql.IndexOf("SELECT ", StringComparison.CurrentCulture) + 6);
            strSql = CommonValidation.GetFilter(strSql);
            string strOrderBy = string.Empty;

            if (strSql.LastIndexOf("ORDER BY") == 0)
            {
                strOrderBy = string.IsNullOrEmpty(ds.Entity) ? "" : (ds.Entity + ".") + ds.KeyName.Replace("'", "''");
                strSql += " order by " + strOrderBy;
            }
            else
            {
                strOrderBy = strSql.Substring(strSql.LastIndexOf("ORDER BY") + 8).Trim();
            }

            var arrList = SplitOrderString(strOrderBy);
            var arrTemp = new string[arrList.Count - 1];
            var arrTemp2 = new string[arrList.Count - 1];

            for (int i = 0; i < arrList.Count - 1; i++)
            {
                strSql = arrList[i] + " AS orderstr" + i.ToString() + "," + strSql;
                arrTemp[i] = "orderstr" + i.ToString() + " DESC";
                arrTemp2[i] = "orderstr" + i.ToString();
            }

            strSql = "SELECT * FROM (select top 1 * from (select top 1 " + strSql;
            strSql += ") a order by " + string.Join(",", arrTemp) + ") b ORDER BY " + string.Join(",", arrTemp2);

            string error = "";
            if (!ValidateSql(strSql, out error))
            {
                Results.Add(new Result(string.Format("检查数据列{0}", cell.Field),
                               string.Format("排序字段配置错误{0}：{1}", cell.OrderBy, error), Level.Error,
                               GetType()));
            }
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

    }
}