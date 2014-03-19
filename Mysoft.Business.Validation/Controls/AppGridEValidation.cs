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
            if (grid.Row != null && grid.Row.AppGridCells.Count > 0)
            {
                if (!string.IsNullOrEmpty(grid.Row.AppGridCells[0].CellType))
                {
                    //appGridE

                    foreach (var cell in grid.Row.AppGridCells)
                    {
                        if (cell.Attribute == null) continue;
                        foreach (var attr in cell.Attribute.Attributes)
                        {
                            if (attr.Name.EqualIgnoreCase("sql"))
                            {
                                if (IsIncorrectSql(attr.Value))
                                {
                                    Results.Add(new Result("AppGridE", string.Format("[{0}]单元格的SQL有误：{1}", cell.Title, attr.Value), Level.Error, typeof(AppGridEValidation)));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}