using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupCommandValidator : AbstractValidator<CreateMeetupCommand>
    {
        public CreateMeetupCommandValidator()
        {
            RuleFor(createMeetupCommand =>
                createMeetupCommand.Title).NotEmpty().MaximumLength(100);
            RuleFor(createMeetupCommand =>
                createMeetupCommand.Details).NotEmpty().MaximumLength(300);
            RuleFor(createMeetupCommand =>
                createMeetupCommand.Place).NotEmpty().MaximumLength(45);
            RuleFor(createMeetupCommand =>
                createMeetupCommand.Speaker).NotEmpty().MaximumLength(30);
        }
    }
}
