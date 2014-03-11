using gudusoft.gsqlparser;
using Mysoft.Business.Controls;
using Mysoft.Business.Validation.Db;
using Mysoft.Business.Validation.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Mysoft.Common.Extensions;

namespace Mysoft.Business.Validation.Controls
{
    public class DataSourceValidation : AppValidationBase
    {
        static readonly TGSqlParser Sqlparser = new TGSqlParser(TDbVendor.DbVMssql);

        public override void Dispose()
        {
            try
            {
                Sqlparser.Destroy();
                Sqlparser.Dispose();
            }
            catch (Exception)
            {
            }
            base.Dispose();
        }

        /// <summary>
        /// 暂不支持SQL缓存依赖检测
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public override void Validate(AppControl control)
        {
            if (control.DataSource == null) return;
            if (control.Control is AppGridTree) return;    //appGridTree不处理
            AppGrid grid = control.Control as AppGrid;
            if (grid != null)
            {
                if (grid.Row != null && grid.Row.AppGridCells.Count > 0)
                {
                    if (grid.Row.AppGridCells[0].CellType != AppGridCellType.None)
                    {
                        //appGridE不处理
                        return;
                    }
                }
            }

            Results.AddRange(ValidateSql(control.DataSource));
        }

        /// <summary>
        /// 验证SQL能否正确执行
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private List<Result> ValidateSql(DataSource ds)
        {
            List<Result> list = new List<Result>();

            if (!Regex.IsMatch(ds.Sql, "(select|from|where)", RegexOptions.IgnoreCase))
            {
                //可能是存储过程，则type必须为SP或StoredProcedure
                if ((ds.Type.EqualIgnoreCase("sp") || ds.Type.EqualIgnoreCase("StoredProcedure")) == false)
                {
                    list.Add(new Result("DataSource的Type配置错误", "ERP3.0后SQL若配置为存储过程，则type必须为SP或StoredProcedure", Level.Error, GetType()));
                }
            }

            //SELECT、FROM、WHERE大小写
            if (!CommonValidation.CheckCase(ds.Sql, ds.PageMode))
            {
                list.Add(new Result("SQL关键字大小写检查", string.Format("SQL语句中不存在大写的SELECT、FROM、WHERE\n{0}", ds.Sql), Level.Error, GetType()));
            }

            try
            {
                //替换变量
                string sql = Regex.Replace(ds.Sql, @"([=|in|<>]+\s*)\[[^a-z]*\]", "$1(null)", RegexOptions.IgnoreCase);
                if (NoAliasSql(sql) || NoAliasSqlCustom(sql))
                {
                    list.Add(new Result("SQL中的Select字段检查", "无别名", Level.Error, GetType()));
                }

                if (CommonValidation.HasSqlKeywords(sql))
                {
                    //存在sql关键字
                    list.Add(new Result("SQL中特定关键字检查", string.Format("存在特定关键字option|COMPUTE\n{0}", ds.Sql), Level.Error, GetType()));
                }
            }
            catch (Exception e)
            {
                list.Add(new Result("执行错误", "SQL语法检查" + e.StackTrace, Level.Warn, GetType()));
            }

            return list;
        }

        private bool NoAliasSql(string sql)
        {
            Sqlparser.SqlText.Text = sql;
            int iRet = -1;
            try
            {
                iRet = Sqlparser.Parse();
            }
            catch (Exception)
            {
                //这个东西有bug
            }
            
            //前提是SQL可以正确被解析
            if (iRet == 0)
            {
                foreach (var stmt in Sqlparser.SqlStatements)
                {
                    foreach (var field in stmt.Fields)
                    {
                        if (field.FieldType != TLzFieldType.lftAttr && field.FieldAlias == "")
                        {
                            var match = Regex.Match(field.FieldDesc, @"^([^=\s]+)\s*=.*", RegexOptions.IgnoreCase);
                            if (!match.Success)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            return false;
        }

        private static bool NoAliasSqlCustom(string sql)
        {
            if (string.IsNullOrEmpty(sql))
                return false;

            string temp = CommonValidation.GetFilter(sql);
            using (var connection = new SqlConnection(DbAccessManager.Connectstring))
            {
                connection.Open();

                //重新创建
                try
                {
                    var createCommand = new SqlCommand(temp, connection);
                    using (var sqlReader = createCommand.ExecuteReader())
                    {
                        for (int index = 0; index < sqlReader.FieldCount; index++)
                        {
                            var name = sqlReader.GetName(index);
                            if (string.IsNullOrEmpty(name))
                                return true;
                        }
                    }
                }
                catch (SqlException)
                {
                }
            }
            return false;
        }
    }
}