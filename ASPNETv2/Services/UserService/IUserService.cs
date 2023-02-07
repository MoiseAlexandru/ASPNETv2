using ASPNETv2.Models;
using ASPNETv2.Models.DTOs;

namespace ASPNETv2.Services.UserService
{
    public interface IUserService
    {
        EmailNameDTO GetNameByEmail(string username);
        Task<EmailNameDTO> GetNameByEmailAsync(string username);
        UserResponseDTO Authenticate(UserRequestDTO model);
        User GetById(Guid id);
        Task Create(User newUser);
        Task <List<User>> GetUserListAsync();
        Task DeleteUser(User userToDelete);
        Task <User> GetUserByUsername(string username);
        Task LinkToProfile(User user, Profile profile);
    }
}
