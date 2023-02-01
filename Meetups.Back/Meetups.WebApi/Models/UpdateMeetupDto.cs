using AutoMapper;
using Meetups.Application.Common.Mappings;
using Meetups.Application.Meetups.Commands.CreateMeetup;
using Meetups.Application.Meetups.Commands.UpdateMeetup;

namespace Meetups.WebApi.Models
{
    public class UpdateMeetupDto : IMapWith<UpdateMeetupCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime StartsAt { get; set; }
        public string Place { get; set; }
        public string Speaker { get; set; }

        public void Mapping(Profile profile)
        {
                profile.CreateMap<UpdateMeetupDto, UpdateMeetupCommand>()
                .ForMember(meetupCommand => meetupCommand.Id,
                    opt => opt.MapFrom(dto => dto.Id))
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
