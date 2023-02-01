using AutoMapper;
using Meetups.Application.Common.Mappings;
using Meetups.Application.Meetups.Commands.UpdateMeetup;
using Meetups.Application.Users.Command.RegisterUser;
using Meetups.Application.Users.Queries.ValidateUser;
using Meetups.Domain;

namespace Meetups.WebApi.Models
{
    public class RegistrationUserDto : IMapWith<RegisterUserCommand>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegistrationUserDto, RegisterUserCommand>()
            .ForMember(registerCommand => registerCommand.UserName,
                opt => opt.MapFrom(dto => dto.UserName))
            .ForMember(registerCommand => registerCommand.Password,
                opt => opt.MapFrom(dto => dto.Password))
            .ForMember(registerCommand => registerCommand.Email,
                opt => opt.MapFrom(dto => dto.Email));
        }
    }
}
