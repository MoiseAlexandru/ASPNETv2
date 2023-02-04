
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
        [HttpGet]
        public IActionResult GetGroupsByUsername(string username)
        {
            var result = _profileService.GetGroupListByUsername(username);
            return Ok(result);
        }
    }
}
