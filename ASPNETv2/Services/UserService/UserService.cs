using ASPNETv2.Models;
using ASPNETv2.Models.DTOs;
using ASPNETv2.Repository.UserRepository;

namespace ASPNETv2.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public EmailNameDTO GetNameByEmail(string email)
        {
            Profile profile = _userRepository.GetUserByEmail(email).Profile;
            EmailNameDTO result = new EmailNameDTO();
            result.Email = email;
            result.FirstName = profile.FirstName;
            result.LastName = profile.LastName;
            return result;
        }

        Task<EmailNameDTO> IUserService.GetNameByEmailAsync(string username)
        {
            throw new NotImplementedException();
        }
        /*
        public async Task <EmailNameDTO> GetNameByEmailAsync (string email)
        {
           Profile profile = await _userRepository.GetUserByEmailAsync(email).Profile;
           EmailNameDTO result = new EmailNameDTO();
           result.Email = email;
           result.FirstName = profile.FirstName;
           result.LastName = profile.LastName;
           return result;
        }
        */
    }
}
