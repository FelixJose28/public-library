using FluentValidation;
using Library.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Validators
{
    public class RegisterBookValidator : AbstractValidator<RegisterBookDto>
    {
        public RegisterBookValidator()
        {
            Include(new BaseValidator());

        RuleFor(x => x.BookStatusId)
                .NotNull();

            RuleFor(x => x.BookId)
                .NotNull();
        }
    }
}
