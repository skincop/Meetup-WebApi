using Meetups.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meetups.Domain;
using AutoMapper;

namespace Meetups.Application.Meetups.Queries.GetMeetupList
{
    public class MeetupLookupDto : IMapWith<Meetup>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime StartsAt { get; set; }
        public string Place { get; set; }
        public string Speaker { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Meetup, MeetupLookupDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(meetup => meetup.Id))
                .ForMember(dto => dto.Title,
                    opt => opt.MapFrom(meetup => meetup.Title))
                .ForMember(dto => dto.Details,
                    opt => opt.MapFrom(meetup => meetup.Details))
                .ForMember(dto => dto.StartsAt,
                    opt => opt.MapFrom(meetup => meetup.StartsAt))
                .ForMember(dto => dto.Place,
                    opt => opt.MapFrom(meetup => meetup.Place))
                 .ForMember(dto => dto.Speaker,
                    opt => opt.MapFrom(meetup => meetup.Speaker));

        }
    }
}
