using FluentValidation;
using Library.Core.Dtos;

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
