using FluentValidation;
using Library.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Validators
{
    public class BaseValidator : AbstractValidator<BaseEntityDto>
    {
        public BaseValidator()
        {
            RuleFor(x => x.RegisteredBy)
                .NotEmpty()
                .MaximumLength(45);

            RuleFor(x => x.RegistrationDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.ModificationDate)
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.ModifiedBy)
                .MaximumLength(45);

            RuleFor(x => x.RegistrationStatus)
                .NotEmpty();
        }
    }
}
