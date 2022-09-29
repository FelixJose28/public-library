using FluentValidation;
using Library.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Validators
{
    public class AlertValidator : AbstractValidator<AlertDto>
    {
        public AlertValidator()
        {
            Include(new BaseValidator());

            RuleFor(x => x.Info)
                .MaximumLength(400)
                .NotEmpty();

            RuleFor(x => x.Title)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(x => x.UserId)
                .NotNull();
        }
    }
}
