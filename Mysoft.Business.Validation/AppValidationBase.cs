using Mysoft.Business.Controls;
using Mysoft.Business.Validation.Entity;
using System.Collections;
using System.Collections.Generic;

namespace Mysoft.Business.Validation
{
    public abstract class AppValidationBase : IAppValidation
    {
        protected AppValidationBase()
        {
            Results = new List<Result>();
        }

        public List<Result> Results { get; protected set; }

        public abstract void Validate(AppControl control);

        public virtual IEnumerable GetResults()
        {
            return Results;
        }

        public virtual void Dispose()
        {
            
        }
    }
}