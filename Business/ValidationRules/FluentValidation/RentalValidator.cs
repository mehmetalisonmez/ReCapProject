using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.ReturnDate).GreaterThan(r => r.RentDate);
            RuleFor(r => r.ReturnDate).NotEmpty();
            RuleFor(r => r.ReturnDate).Must(IsReturnDateWithinSixtyDays).WithMessage("Return date must be within 60 days of rent date");
       
        }
        private bool IsReturnDateWithinSixtyDays(Rental rental, DateTime returnDate)  //kontrol et burayı api'de
        {
            DateTime maxReturnDate = rental.RentDate.AddDays(60);
            return returnDate <= maxReturnDate;
        }
    }
}