using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()   //Password kısıtlamalrını nası lgetireceğim. Tamam password alıyoruz ancak bunu veritabvanında passwordHashliyoruz
        {
            RuleFor(u => u.Password).MinimumLength(6).MaximumLength(20);
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).Must(ContainUppercase).WithMessage("Password must contain at least one uppercase letter and one digit.");
            RuleFor(u => u.Password).Must(ContainDigit).WithMessage("Password must contain at least one uppercase letter and one digit.");
        }

        private bool ContainUppercase(string password)
        {
            return password.Any(char.IsUpper);
        }

        private bool ContainDigit(string password)
        {
            return password.Any(char.IsDigit);
        }
    }
}
