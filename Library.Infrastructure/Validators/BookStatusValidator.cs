using FluentValidation;
using Library.Core.Dtos;

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
