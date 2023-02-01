namespace Meetups.WebApi.JwtAuth
{
    public interface ITokenService
    {
        public string CreateToken(Guid id);
    }
}
