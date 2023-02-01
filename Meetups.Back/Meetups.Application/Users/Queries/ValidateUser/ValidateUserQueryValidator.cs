using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Users.Queries.ValidateUser
{
    public class ValidateUserQueryValidator : AbstractValidator<ValidateUserQuery>
    {
        public ValidateUserQueryValidator()
        {
            RuleFor(validateUserQuery =>
               validateUserQuery.UserName).NotEmpty().MaximumLength(20);
            RuleFor(validateUserQuery =>
                validateUserQuery.Password).NotEmpty().MaximumLength(30);
        }
    }
}
