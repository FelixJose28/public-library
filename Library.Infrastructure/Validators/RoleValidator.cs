using FluentValidation;
using Library.Core.Dtos;

namespace Library.Infrastructure.Validators
{
    public class RoleValidator : AbstractValidator<RoleDto>
    {
        public RoleValidator()
        {
            Include(new BaseValidator());

            RuleFor(x => x.RoleName)
                .MaximumLength(400)
                .NotEmpty();
        }
    }
}
