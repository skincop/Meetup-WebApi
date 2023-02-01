using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Meetups.Queries.GetMeetupList
{
    public class MeetupListVm
    {
        public IList<MeetupLookupDto> Meetups { get; set; }
    }
}
