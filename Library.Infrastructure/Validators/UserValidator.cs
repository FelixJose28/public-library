using FluentValidation;
using Library.Core.DTOs;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Validators
{
    public class UserValidator:AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            Include(new BaseValidator());

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x=>x.Password)
                .NotEmpty()
                .Equal(x => x.ConfirmPassword)
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .Matches(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");

            RuleFor(x => x.FirstName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.SecondName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.FirstSurname)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.SecondSurname)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.Province)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.MunicipalDistrict)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Municipality)
                .MaximumLength(100);

            RuleFor(x => x.Street)
                .MaximumLength(100);

            RuleFor(x => x.HouseNumber)
                .MaximumLength(5)
                .Matches(@"^[0-9]*$");

            RuleFor(x => x.RoleId)
                .NotNull();
        }
    }
}