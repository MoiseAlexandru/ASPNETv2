using ASPNETv2.Helper.JwtUtils;
using ASPNETv2.Models;
using ASPNETv2.Models.DTOs;
using ASPNETv2.Repository.UserRepository;
using System.Text.Json.Serialization;
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
            if (user == null || user.Role != model.Role || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }


        public async Task Create(User newUser)
        {
            var alreadyUser = _userRepository.GetUserByUsername(newUser.UserName);
            if (alreadyUser == null)
            {
                await _userRepository.CreateAsync(newUser);
                await _userRepository.SaveAsync();
            }
        }


        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }

        
        public async Task DeleteUser(User userToDelete)
        {
            await Task.Run(() => _userRepository.Delete(userToDelete));
            await _userRepository.SaveAsync();
        }
        public UserDTO convertUserToDTO(User user)
        {
            UserDTO returnedUser = new UserDTO();
            returnedUser.UserId = user.UserId;
            returnedUser.UserName = user.UserName;
            returnedUser.Email = user.Email;
            returnedUser.ProfileId = user.ProfileId;
            returnedUser.Role = user.Role;
            return returnedUser;
        }
        public async Task<List<UserDTO>> GetUserListAsync()
        {
            List<User> userList = await _userRepository.GetUserListAsync();
            List<UserDTO> convertedList = new List<UserDTO>();
            foreach (var user in userList)
            {
                convertedList.Add(convertUserToDTO(user));
            }
            return convertedList;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUsername(username);
        }
        public async Task<UserDTO> GetUserByUsernameDTO(string username)
        {
            User user = await _userRepository.GetUserByUsername(username);
            UserDTO returnedUser = new UserDTO();
            returnedUser = convertUserToDTO(user);
            return returnedUser;
        }
        public async Task LinkToProfile(User user, Profile profile)
        {
            user.ProfileId = user.UserId;
            _userRepository.Update(user);
            await _userRepository.SaveAsync();
        }
    }
}