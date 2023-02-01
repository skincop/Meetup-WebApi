using AutoMapper;
using Meetups.Application.Common.Mappings;
using Meetups.Application.Meetups.Commands.CreateMeetup;

namespace Meetups.WebApi.Models
{
    public class CreateMeetupDto : IMapWith<CreateMeetupCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime StartsAt { get; set; }
        public string Place { get; set; }
        public string Speaker { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMeetupDto, CreateMeetupCommand>()
                .ForMember(meetupCommand => meetupCommand.Title,
                    opt => opt.MapFrom(dto => dto.Title))
                .ForMember(meetupCommand => meetupCommand.Details,
                    opt => opt.MapFrom(dto => dto.Details))
                .ForMember(meetupCommand => meetupCommand.StartsAt,
                    opt => opt.MapFrom(dto => dto.StartsAt))
                .ForMember(meetupCommand => meetupCommand.Place,
                    opt => opt.MapFrom(dto => dto.Place))
                .ForMember(meetupCommand => meetupCommand.Speaker,
                    opt => opt.MapFrom(dto => dto.Speaker));
        }
    }
}
