using AutoMapper;
using MediatR;
using Meetups.Application.Common.Exceptions;
using Meetups.Application.Interfaces;
using Meetups.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Application.Users.Queries.ValidateUser
{
    public class ValidateUserQueryHandler : IRequestHandler<ValidateUserQuery, UserValidateDto>
    {
        private readonly IMeetupsDbContext _dbContext;
        private readonly IMapper _mapper;

        public ValidateUserQueryHandler(IMeetupsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserValidateDto> Handle(ValidateUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user =>
                            user.UserName == request.UserName
                            && user.Password == request.Password,
                            cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserName);
            }

            var userValidateDto = _mapper.Map<UserValidateDto>(user);
            return userValidateDto;
        }
    }
}
