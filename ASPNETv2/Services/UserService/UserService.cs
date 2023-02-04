using ASPNETv2.Helper.JwtUtils;
using ASPNETv2.Models;
using ASPNETv2.Models.DTOs;
using ASPNETv2.Repository.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ASPNETv2.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public IJwtUtils _jwtUtils;
        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
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

        // Autentificare
        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user = _userRepository.FindByUsername(model.UserName);
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }


        public async Task Create(User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }

        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }

    }
}
