using FluentValidation;
using Library.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            Include(new BaseValidator());

            RuleFor(x => x.FirstName)
                    .MaximumLength(50)
                    .NotEmpty();

            RuleFor(x => x.SecondName)
                .MaximumLength(50);

            RuleFor(x => x.FirstSurname)
                    .MaximumLength(50);
            
            RuleFor(x => x.SecondSurname)
                    .MaximumLength(50);
        }
    }
}
