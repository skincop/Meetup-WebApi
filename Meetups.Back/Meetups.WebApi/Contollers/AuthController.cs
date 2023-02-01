using AutoMapper;
using Azure.Core;
using Meetups.Application.Common.Exceptions;
using Meetups.Application.Meetups.Queries.GetMeetupList;
using Meetups.Application.Users.Command.RegisterUser;
using Meetups.Application.Users.Queries.ValidateUser;
using Meetups.Domain;
using Meetups.WebApi.JwtAuth;
using Meetups.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Meetups.WebApi.Contollers
{
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthController(IMapper mapper, ITokenService tokenService)
        {
            _mapper = mapper;
            _tokenService = tokenService;
        }
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<string>> Auth([FromBody] AuthenticationUserDto authenticationUserDto)
        {

            var query = _mapper.Map<ValidateUserQuery>(authenticationUserDto);
            var userDto = await Mediator.Send(query);

            var token = _tokenService.CreateToken(userDto.Id);
            return Ok(token);
        }
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] RegistrationUserDto registrationUserDto)
        {

            var query = _mapper.Map<RegisterUserCommand>(registrationUserDto);
            query.UserId = UserId;
            var userGuid = await Mediator.Send(query);
            return Ok();
        }
    }
}
