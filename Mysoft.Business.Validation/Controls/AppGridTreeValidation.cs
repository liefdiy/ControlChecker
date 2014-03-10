using Mysoft.Business.Controls;
using Mysoft.Business.Validation.Entity;
using System;

namespace Mysoft.Business.Validation.Controls
{
    public class AppGridTreeValidation : AppValidationBase
    {
        public override void Validate(AppControl control)
        {
            AppGridTree grid = control.Control as AppGridTree;
            if (grid == null) return;  //不是grid

            ValidateColumns(grid, control.DataSource);
        }

        /// <summary>
        /// 检测表格中数据列的列名是否包含在SQL中
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        private void ValidateColumns(AppGridTree grid, DataSource ds)
        {
            if (string.IsNullOrEmpty(ds.Sql)) return;

            //检查数据列是否在SQL语句中
            int begin = ds.Sql.IndexOf("select", StringComparison.OrdinalIgnoreCase);
            int end = ds.Sql.IndexOf("from", StringComparison.OrdinalIgnoreCase);

            if (string.IsNullOrEmpty(ds.Sql))
            {
                Results.Add(new Result("SQL检查", "未配置SQL", Level.Warn, GetType()));
                return;
            }

            if (end < begin || end < 0) return;
            if (ds.Sql.IndexOf("*", begin, end - begin, StringComparison.OrdinalIgnoreCase) < 0)
            {
                //如果没有*
                if (grid.Row == null || grid.Row.Cells == null) return;

                foreach (var appGridCell in grid.Row.Cells)
                {
                    if (ds.Sql.IndexOf(appGridCell.Field, StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        Results.Add(new Result("数据列检查", string.Format("SQL中未包含{0}", appGridCell.Field), Level.Error, GetType()));
                    }
                }
            }
        }
    }
}