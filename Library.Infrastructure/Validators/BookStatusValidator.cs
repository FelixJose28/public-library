using FluentValidation;
using Library.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Validators
{
    public class BookStatusValidator : AbstractValidator<BookStatusDto>
    {
        public BookStatusValidator()
        {
            Include(new BaseValidator());

            RuleFor(x => x.Name)
                .MaximumLength(50);

            RuleFor(x => x.Info)
                    .MaximumLength(400);
        }
    }
}
