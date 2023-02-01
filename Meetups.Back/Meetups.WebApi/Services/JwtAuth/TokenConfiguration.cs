using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Meetups.WebApi.JwtAuth
{
    public static class TokenConfiguration
    {
        public const string Issuer = "Meetup_WebApi";
        public const string Audience = "Meetup_WebApi";
        public const string SecretKey = "123131232131223213213131";

        public static SymmetricSecurityKey GetKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConfiguration.SecretKey));
        }

    }
}
