using Meetups.WebApi.JwtAuth;

namespace Meetups.WebApi
{
    public static class ServicesExtensions
    {
        public static void ConfigureJWT(this IServiceCollection services)
        {
            services.AddAuthentication("OAuth")
               .AddJwtBearer("OAuth", config =>
               {
                   config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                   {
                       ValidIssuer = TokenConfiguration.Issuer,
                       ValidAudience = TokenConfiguration.Audience,
                       IssuerSigningKey = TokenConfiguration.GetKey()
                   };
               });
        }


    }
}
