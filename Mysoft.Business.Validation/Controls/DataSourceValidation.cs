namespace Mysoft.Business.Validation.Controls
{
    using Mysoft.Business.Controls;
    using Mysoft.Business.Validation;
    using Mysoft.Business.Validation.Db;
    using Mysoft.Business.Validation.Entity;
    using Mysoft.Common.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;

    public class DataSourceValidation : AppValidationBase
    {
        public override void Validate(AppControl control)
        {
            if ((control.DataSource != null) && !(control.Control is AppGridTree))
            {
                AppGrid grid = control.Control as AppGrid;
                if (((grid == null) || ((grid.Row == null) || (grid.Row.AppGridCells.Count <= 0))) || string.IsNullOrEmpty(grid.Row.AppGridCells[0].CellType))
                {
                    base.Results.AddRange(ValidateSql(control.DataSource));
                }
            }
        }

        private static bool NoAliasSqlCustom(string sql)
        {
            if (!string.IsNullOrEmpty(sql))
            {
                string temp = CommonValidation.GetFilter(sql);
                using (SqlConnection connection = new SqlConnection(DbAccessManager.Connectstring))
                {
                    connection.Open();
                    try
                    {
                        SqlCommand createCommand = new SqlCommand(temp, connection);
                        using (SqlDataReader sqlReader = createCommand.ExecuteReader())
                        {
                            for (int index = 0; index < sqlReader.FieldCount; index++)
                            {
                                if (string.IsNullOrEmpty(sqlReader.GetName(index)))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return false;
        }

        private List<Result> ValidateSql(DataSource ds)
        {
            List<Result> list = new List<Result>();
            if (!Regex.IsMatch(ds.Sql, "(select|from|where)", RegexOptions.IgnoreCase) && !(ds.Type.EqualIgnoreCase("sp") || ds.Type.EqualIgnoreCase("StoredProcedure")))
            {
                list.Add(new Result("DataSource的Type配置错误", "ERP3.0后SQL若配置为存储过程，则type必须为SP或StoredProcedure", Level.Error, base.GetType()));
            }

            int pagemode = Convert.ToInt32(ds.PageMode);
            if(pagemode > 2 || pagemode < 0)
            {
                list.Add(new Result("DataSource的pagemode属性值错误", "仅支持0,1,2", Level.Error, base.GetType()));
                return list;
            }

            if (!CommonValidation.CheckCase(ds.Sql, pagemode))
            {
                list.Add(new Result("SQL关键字大小写检查", string.Format("SQL语句中不存在大写的SELECT、FROM、WHERE。\n{0}", ds.Sql), Level.Error, base.GetType()));
            }

            try
            {
                if (IsIncorrectSql(ds.Sql))
                {
                    list.Add(new Result("SQL语句有误", "SQL语法错误", Level.Error, base.GetType()));
                    return list;
                }

                string sql = Regex.Replace(ds.Sql, @"([=|in|<>]+\s*)\[[^a-z]*\]", "$1(null)", RegexOptions.IgnoreCase);
                
                if (NoAliasSqlCustom(sql))
                {
                    list.Add(new Result("SQL中的Select字段检查", "无别名", Level.Error, base.GetType()));
                }

                if (CommonValidation.HasSqlKeywords(sql))
                {
                    list.Add(new Result("SQL中特定关键字检查", string.Format("存在特定关键字option|COMPUTE\n{0}", ds.Sql), Level.Error, base.GetType()));
                }

                ds.IsSqlPassed = true;
            }
            catch (SqlException sqlException)
            {
                list.Add(new Result("执行错误", "SQL语法检查" + sqlException.Message, Level.Error, base.GetType()));
            }
            catch (Exception e)
            {
                list.Add(new Result("执行错误", "SQL语法检查" + e.StackTrace, Level.Warn, base.GetType()));
            }
            return list;
        }
    }
}