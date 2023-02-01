using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Meetups.Commands.CreateMeetup
{
    public  class CreateMeetupCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime StartsAt { get; set; }
        public string Place { get; set; }
        public string Speaker { get; set; }
    }
}
