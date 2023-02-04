using ASPNETv2.Models.DTOs;

namespace ASPNETv2.Services.UserService
{
    public interface IUserService
    {
        EmailNameDTO GetNameByEmail(string username);
        Task<EmailNameDTO> GetNameByEmailAsync(string username);
        UserResponseDTO Authenticate(UserRequestDTO model);
        UserRequestDTO GetById(Guid id);
        Task Create(UserRequestDTO newUser);
    }
}
