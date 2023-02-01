using AutoMapper;
using MediatR;
using Meetups.Application.Common.Exceptions;
using Meetups.Application.Interfaces;
using Meetups.Application.Meetups.Queries.GetMeetupList;
using Meetups.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Meetups.Queries.GetMeetup
{
    public class GetMeetupQueryHandler : IRequestHandler<GetMeetupQuery, MeetupLookupDto>
    {
        private readonly IMeetupsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeetupQueryHandler(IMeetupsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<MeetupLookupDto> Handle(GetMeetupQuery request, CancellationToken cancellationToken)
        {
            var meetup = await _dbContext.Meetups
                .FirstOrDefaultAsync(meetup => meetup.Id == request.Id, cancellationToken);

            if (meetup == null)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }
            var vm = _mapper.Map<MeetupLookupDto>(meetup);
            return vm;
        }
    }
}
