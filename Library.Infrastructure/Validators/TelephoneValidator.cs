using FluentValidation;
using Library.Core.Dtos;

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
