using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommandValidator : AbstractValidator<UpdateMeetupCommand>
    {
        public UpdateMeetupCommandValidator()
        {
            RuleFor(updateMeetupCommand =>
               updateMeetupCommand.Title).NotEmpty().MaximumLength(100);
            RuleFor(updateMeetupCommand =>
                updateMeetupCommand.Details).NotEmpty().MaximumLength(300);
            RuleFor(updateMeetupCommand =>
                updateMeetupCommand.Place).NotEmpty().MaximumLength(45);
            RuleFor(updateMeetupCommand =>
              updateMeetupCommand.Speaker).NotEmpty().MaximumLength(30);
        }
    }
}
