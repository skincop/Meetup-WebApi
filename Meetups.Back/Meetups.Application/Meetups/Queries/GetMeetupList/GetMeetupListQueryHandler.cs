using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Meetups.Application.Interfaces;
using Meetups.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Meetups.Queries.GetMeetupList
{
    public class GetMeetupListQueryHandler : IRequestHandler<GetMeetupListQuery, MeetupListVm>
    {
        private readonly IMeetupsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeetupListQueryHandler(IMeetupsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<MeetupListVm> Handle(GetMeetupListQuery request, CancellationToken cancellationToken)
        {

            var meetupList = await _dbContext.Meetups
                .ProjectTo<MeetupLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MeetupListVm { Meetups = meetupList };
        }
    }
}
