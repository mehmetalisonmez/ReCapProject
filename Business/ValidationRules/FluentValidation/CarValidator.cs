using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(5).MaximumLength(15);
            RuleFor(c => c.Description).MinimumLength(7);
            RuleFor(c => c.DailyPrice).GreaterThan(200);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();  
        }
    }
}
