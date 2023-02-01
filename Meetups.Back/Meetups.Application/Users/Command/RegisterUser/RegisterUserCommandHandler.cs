using MediatR;
using Meetups.Application.Interfaces;
using Meetups.Application.Meetups.Commands.CreateMeetup;
using Meetups.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Users.Command.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IMeetupsDbContext _dbContext;

        public RegisterUserCommandHandler(IMeetupsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id=request.UserId,
                UserName=request.UserName,
                Password=request.Password,
                Email=request.Email
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
