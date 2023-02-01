using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Users.Queries.ValidateUser
{
    public class ValidateUserQuery : IRequest<UserValidateDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
