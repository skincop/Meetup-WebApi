using MediatR;
using Meetups.Application.Common.Exceptions;
using Meetups.Application.Interfaces;
using Meetups.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Meetups.Commands.UpdateMeetup
{
    internal class UpdateMeetupCommandHandler : IRequestHandler<UpdateMeetupCommand>
    {
        private readonly IMeetupsDbContext _dbContext;

        public UpdateMeetupCommandHandler(IMeetupsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateMeetupCommand request, CancellationToken cancellationToken)
        {
            var meetup = await _dbContext.Meetups.FirstOrDefaultAsync(meetup => 
                                meetup.Id == request.Id, cancellationToken);

            if (meetup == null || meetup.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }

            meetup.Title = request.Title;
            meetup.Details = request.Details;
            meetup.StartsAt = request.StartsAt;
            meetup.Place = request.Place;
            meetup.Speaker = request.Speaker;
            meetup.EditAt = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
