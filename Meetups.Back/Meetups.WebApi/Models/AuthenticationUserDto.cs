using AutoMapper;
using Meetups.Application.Common.Mappings;
using Meetups.Application.Meetups.Commands.CreateMeetup;
using Meetups.Application.Users.Queries.ValidateUser;
using Meetups.Domain;

namespace Meetups.WebApi.Models
{
    public class AuthenticationUserDto : IMapWith<ValidateUserQuery>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AuthenticationUserDto, ValidateUserQuery>()
                .ForMember(validateQuery => validateQuery.UserName,
                    opt => opt.MapFrom(dto => dto.UserName))
                .ForMember(validateQuery => validateQuery.Password,
                    opt => opt.MapFrom(dto => dto.Password));

        }
    }
}
