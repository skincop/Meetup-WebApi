using AutoMapper;
using Meetups.Application.Common.Mappings;
using Meetups.Application.Meetups.Queries.GetMeetupList;
using Meetups.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Users.Queries.ValidateUser
{
    public class UserValidateDto : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get;set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserValidateDto>()
               .ForMember(dto => dto.Id,
                   opt => opt.MapFrom(user => user.Id))
               .ForMember(dto => dto.UserName,
                   opt => opt.MapFrom(user => user.UserName))
               .ForMember(dto => dto.Password,
                   opt => opt.MapFrom(user => user.Password));
        }
    }
}
