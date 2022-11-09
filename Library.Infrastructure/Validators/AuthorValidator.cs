using FluentValidation;
using Library.Core.Dtos;

namespace Library.Infrastructure.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            Include(new BaseValidator());

            RuleFor(x => x.FirstName)
                    .MaximumLength(50)
                    .NotEmpty();

            RuleFor(x => x.SecondName)
                .MaximumLength(50);

            RuleFor(x => x.FirstSurname)
                    .MaximumLength(50);

            RuleFor(x => x.SecondSurname)
                    .MaximumLength(50);
        }
    }
}
