using MediatR;
using Meetups.Domain;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Meetups.WebApi.Contollers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();

        internal Guid UserId => User.Identity.IsAuthenticated ? Guid.Parse(User.FindFirst("userId").Value) : Guid.Empty;

    }
}
