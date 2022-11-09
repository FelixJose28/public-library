using FluentValidation;
using Library.Core.Dtos;

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
