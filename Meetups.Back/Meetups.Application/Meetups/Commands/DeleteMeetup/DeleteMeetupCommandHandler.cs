using MediatR;
using Meetups.Application.Common.Exceptions;
using Meetups.Application.Interfaces;
using Meetups.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Meetups.Commands.DeleteMeetup
{
    public class DeleteMeetupCommandHandler : IRequestHandler<DeleteMeetupCommand>
    {
        private readonly IMeetupsDbContext _dbContext;

        public DeleteMeetupCommandHandler(IMeetupsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteMeetupCommand request, CancellationToken cancellationToken)
        {
            var meetup = await _dbContext.Meetups.FindAsync(request.Id, cancellationToken);

            if (meetup == null || meetup.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }

            _dbContext.Meetups.Remove(meetup);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
