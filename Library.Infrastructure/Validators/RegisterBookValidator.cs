using FluentValidation;
using Library.Core.Dtos;

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
