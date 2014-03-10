using System;
using Mysoft.Business.Controls;
using System.Collections;

namespace Mysoft.Business.Validation
{
    public interface IAppValidation : IDisposable
    {
        void Validate(AppControl control);

        IEnumerable GetResults();
    }
}