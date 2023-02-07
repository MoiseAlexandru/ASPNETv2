using ASPNETv2.Models;
using ASPNETv2.Models.DTOs;
using ASPNETv2.Models.Enum;
using ASPNETv2.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ASPNETv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetNameByEmail(string email)
        {
            var result = _userService.GetNameByEmail(email);
            return Ok(result);
        }
        [HttpPost("create-custom-user")]
        public async Task <IActionResult> CreateCustomUser(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };
            await _userService.Create(userToCreate);
            return Ok();
        }

        [HttpPost("create-default-user")]
        public async Task <IActionResult> CreateDefaultUser(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Role = Role.User,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };
            await _userService.Create(userToCreate);
            return Ok();
        }

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Role = Role.Admin,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };
            await _userService.Create(userToCreate);
            return Ok();
        }
        [HttpGet("get-user-list")]
        public async Task <IActionResult> GetUserList()
        {
            var users = await _userService.GetUserListAsync();
            return Ok(users);
        }
        [HttpDelete("delete-user")]
        public async Task <IActionResult> DeleteUser(string username)
        {
            User user = await _userService.GetUserByUsername(username);
            await _userService.DeleteUser(user);
            return Ok(user);
        }
    }
}
