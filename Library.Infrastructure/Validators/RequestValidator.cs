using FluentValidation;
using Library.Core.Dtos;
using System;

namespace Library.Infrastructure.Validators
{
    public class RequestValidator : AbstractValidator<RequestDto>
    {
        public RequestValidator()
        {
            Include(new BaseValidator());

            RuleFor(x => x.RequestDate)
                    .NotEmpty()
                    .LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.DeliverDate)
                    .GreaterThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.UserId)
                    .NotNull();

            RuleFor(x => x.RegisterBookId)
                    .NotNull();
        }
    }
}
