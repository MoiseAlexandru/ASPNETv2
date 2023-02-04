using ASPNETv2.Models;

namespace ASPNETv2.Helper.JwtToken
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken(string token);
    }
}
