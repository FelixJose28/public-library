using FluentValidation;
using Library.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Validators
{
    public class LiteraryGenderValidator : AbstractValidator<LiteraryGenderDto>
    {
        public LiteraryGenderValidator()
        {
            Include(new BaseValidator());

            RuleFor(x => x.Name)
                .MaximumLength(50);

            RuleFor(x => x.Info)
                    .MaximumLength(400);
        }
    }
}
