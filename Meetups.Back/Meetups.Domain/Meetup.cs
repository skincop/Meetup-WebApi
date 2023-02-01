using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Domain
{
    public class Meetup
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Speaker { get; set; }
        public DateTime StartsAt { get; set; }
        public string Place { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditAt { get; set; }

        public User User { get; set; }

    }
}
