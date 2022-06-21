using FluentValidation;
using Library.Core.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
