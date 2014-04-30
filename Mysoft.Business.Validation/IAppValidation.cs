using Mysoft.Business.Controls;
using System.Collections;

namespace Mysoft.Business.Validation
{
    public interface IAppValidation
    {
        /// <summary>
        /// 执行控件校验
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        IEnumerable ValidateControl(AppControl control);
    }
}