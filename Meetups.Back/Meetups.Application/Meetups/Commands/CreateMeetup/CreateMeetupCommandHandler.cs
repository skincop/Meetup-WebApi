using MediatR;
using Meetups.Application.Interfaces;
using Meetups.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupCommandHandler : IRequestHandler<CreateMeetupCommand, Guid>
    {
        private readonly IMeetupsDbContext _dbContext;

        public CreateMeetupCommandHandler(IMeetupsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateMeetupCommand request, CancellationToken cancellationToken)
        {
            var meetup = new Meetup
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                StartsAt = request.StartsAt,
                Place = request.Place,
                Id = Guid.NewGuid(),
                Speaker=request.Speaker,
                CreatedAt = DateTime.Now,
                EditAt = null
            };

            await _dbContext.Meetups.AddAsync(meetup, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return meetup.Id;
        }
    }
}
