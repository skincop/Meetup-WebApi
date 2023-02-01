using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Users.Command.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(registerUserCommand =>
                registerUserCommand.UserName).NotEmpty().MaximumLength(20);
            RuleFor(registerUserCommand =>
                registerUserCommand.Password).NotEmpty().MaximumLength(30);
            RuleFor(registerUserCommand =>
                registerUserCommand.Email).NotEmpty().MaximumLength(50);
        }
    }
}
