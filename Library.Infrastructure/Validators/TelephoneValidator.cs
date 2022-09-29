using FluentValidation;
using Library.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Validators
{
    public class TelephoneValidator : AbstractValidator<TelephoneDto>
    {
        public TelephoneValidator()
        {
            Include(new BaseValidator());

            RuleFor(x => x.PhoneNumber)
                    .MaximumLength(25)
                    .NotEmpty()
                    .Matches(@"^[0-9]*$");

            RuleFor(x => x.UserId)
                .NotNull();
        }
    }
}
