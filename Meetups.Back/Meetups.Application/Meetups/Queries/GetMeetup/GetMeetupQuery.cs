using MediatR;
using Meetups.Application.Meetups.Queries.GetMeetupList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Meetups.Queries.GetMeetup
{
    public class GetMeetupQuery : IRequest<MeetupLookupDto>
    {
        public Guid Id { get; set; }
    }
}
