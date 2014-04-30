using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Mysoft.Business.Controls;
using Mysoft.Business.Validation.Db;
using Mysoft.Business.Validation.Entity;
using Mysoft.Common.Extensions;

namespace Mysoft.Business.Validation.Controls
{
    public class AppGridValidation : AppValidationBase
    {
        public override void Validate(AppControl control)
        {
            AppGrid grid = control.Control as AppGrid;
            if (grid == null) return;  //不是grid

            if (control.DataSource != null)
            {
                ValidateDataSource(control.DataSource);
            }

            ValidateColumns(grid, control.DataSource, control.State.IsSqlPassed);
        }

        /// <summary>
        /// 检测表格中数据列的列名是否包含在SQL中
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="ds"></param>
        /// <param name="isSqlPassed"></param>
        /// <returns></returns>
        private void ValidateColumns(AppGrid grid, DataSource ds, bool isSqlPassed)
        {
            if (ds.Type.EqualIgnoreCase("sp") || ds.Type.EqualIgnoreCase("StoredProcedure")) return; //存储过程不处理
            if (string.IsNullOrEmpty(ds.Sql)) return;

            //检查数据列是否在SQL语句中
            int begin = ds.Sql.IndexOf("select", StringComparison.OrdinalIgnoreCase);
            int end = ds.Sql.IndexOf("from", StringComparison.OrdinalIgnoreCase);

            if (end < begin || end < 0) return;
            if (ds.Sql.IndexOf("*", begin, end - begin, StringComparison.OrdinalIgnoreCase) < 0)
            {
                //如果没有*
                if (grid.Row == null || grid.Row.AppGridCells == null) return;

                //如果SQL语法没问题则校验绑定字段是否存在
                if (isSqlPassed)
                {
                    foreach (var appGridCell in grid.Row.AppGridCells)
                    {
                        if (ds.Sql.IndexOf(appGridCell.Field, StringComparison.OrdinalIgnoreCase) < 0)
                        {
                            Results.Add(new Result(string.Format("检查数据列{0}", appGridCell.Field),
                                                   string.Format("SQL中未包含{0}", appGridCell.Field), Level.Error,
                                                   GetType()));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 校验DataSource
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private void ValidateDataSource(DataSource ds)
        {
            int pagemode = 0;
            Int32.TryParse(ds.PageMode, out pagemode);
            if(pagemode == 0)
            {
                Results.AddRange(AnalysisSql(ds.Sql, ds.Entity, ds.KeyName, pagemode, ds.Order));
            }
        }

        private List<Result> AnalysisSql(string sql, string entity, string primaryKey, int pagemode, Order order)
        {
            List<Result> list = new List<Result>();
            if (string.IsNullOrEmpty(sql)) return list;

            //替换过滤条件
            string temp = CommonValidation.GetFilter(sql);

            //排序
            temp = GetOrderBy(temp, entity, primaryKey, list, order);

            //分页
            CheckPageSql(temp, entity, primaryKey, pagemode, list);

            //重复列
            CheckDumplicateColumn(temp, list);

            return list;
        }

        private string GetOrderBy(string sql, string entity, string primaryKey, List<Result> list, Order order)
        {
            if (order != null && !string.IsNullOrEmpty(order.Field))
            {
                if (!string.IsNullOrEmpty(primaryKey))
                {
                    sql = Regex.Replace(sql, @"ORDER\s+BY", "ORDER BY");
                    if (sql.LastIndexOf("ORDER BY", StringComparison.Ordinal) == -1)
                    {
                        sql += " ORDER BY " +
                               (string.IsNullOrEmpty(entity) ? primaryKey : string.Format("{0}.{1}", entity, primaryKey));
                    }
                }
            }

            try
            {
                CommonValidation.ExecuteSql(sql);
            }
            catch (Exception e)
            {
                list.Add(new Result("排序语句执行出错", string.Format("{0}\n\r{1}", e.Message, sql), Level.Error, GetType()));
            }
            return sql;
        }

        private void CheckPageSql(string sql, string entity, string primaryKey, int pagemode, List<Result> list)
        {
            string temp = sql;
            switch (pagemode)
            {
                case 1:
                    temp = CommonValidation.GetPageSqlByNotIn(sql, entity, primaryKey);
                    break;

                case 2:
                    temp = CommonValidation.GetPageSqlByRowNumber(sql);
                    break;
            }

            try
            {
                CommonValidation.ExecuteSql(temp);
            }
            catch (Exception e)
            {
                list.Add(new Result("分页语句执行出错", string.Format("{0}\n\r{1}", e.Message, temp), Level.Error, GetType()));
            }
        }

        private void CheckDumplicateColumn(string sql, List<Result> list)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            SqlConnection conn = new SqlConnection(DbAccessManager.Connectstring);

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                for (var i = 0; i < sdr.FieldCount; i++)
                {
                    string name = sdr.GetName(i);
                    if (dic.ContainsKey(name))
                    {
                        dic[name]++;
                        if (dic[name] == 2)
                        {
                            list.Add(new Result("SQL重复字段检查", string.Format("SQL中存在重复字段：{0}", name), Level.Error, GetType()));
                        }
                    }
                    else
                    {
                        dic.Add(name, 1);
                    }
                }
            }
            catch (Exception e)
            {
                list.Add(new Result("重复字段检查SQL执行出错", string.Format("{0}\n\r{1}", e.Message, sql), Level.Error, GetType()));
            }
            finally
            {
                conn.Close();
            }
        }
    }
}