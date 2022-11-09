using FluentValidation;
using Library.Core.Dtos;

namespace Library.Infrastructure.Validators
{
    public class PublisherValidator : AbstractValidator<PublisherDto>
    {
        public PublisherValidator()
        {
            Include(new BaseValidator());

            RuleFor(x => x.Info)
                .MaximumLength(400)
                .NotEmpty();

            RuleFor(x => x.Name)
                .MaximumLength(50)
                .NotEmpty();
        }
    }
}
