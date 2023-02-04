using ASPNETv2.Models.DTOs;

namespace ASPNETv2.Services.UserService
{
    public interface IUserService
    {
        EmailNameDTO GetNameByEmail(string username);
        Task<EmailNameDTO> GetNameByEmailAsync(string username);
    }
}
