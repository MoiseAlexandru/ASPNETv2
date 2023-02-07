
using ASPNETv2.Services.ProfileService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpGet("get-group-list")]
        public IActionResult GetGroupsByUsername(string username)
        {
            var result = _profileService.GetGroupListByUsername(username);
            return Ok(result);
        }
        [HttpGet("get-profile-list")]
        public async Task <IActionResult> GetProfilesList()
        {
            var result = await _profileService.GetProfileList();
            return Ok(result);
        }
    }
}
