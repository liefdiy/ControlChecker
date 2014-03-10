using Mysoft.Business.Controls;
using Mysoft.Business.Validation.Entity;

namespace Mysoft.Business.Validation.Controls
{
    public class AppViewListValidation : AppValidationBase
    {
        public override void Validate(AppControl control)
        {
            if (control.View == null) return;

            for (int i = 0; i < control.View.AppFindViewItems.Count; i++)
            {
                var view = control.View.AppFindViewItems[i];

                if (string.IsNullOrEmpty(view.XmlUrl))
                {
                    //默认视图为当前页
                    if (i > 0)
                    {
                        Results.Add(new Result("视图配置检查", view.Title + "视图地址未配置", Level.Error, GetType()));
                    }
                }
                else
                {
                    if (view.SubPage == null)
                    {
                        Results.Add(new Result("视图配置检查", string.Format("未找到{0}视图配置：{1}，或配置文件反序列化失败", view.Title, view.XmlUrl), Level.Warn, GetType()));
                    }
                }
            }
        }
    }
}