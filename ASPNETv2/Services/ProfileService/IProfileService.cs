using ASPNETv2.Models;
using ASPNETv2.Models.DTOs;

namespace ASPNETv2.Services.ProfileService
{
    public interface IProfileService
    {
        List <GroupJoinInDTO> GetGroupListByUsername(string username);
        Task CreateOnUserRegistration(User user);
        Task<List<Profile>> GetProfileList();
    }
}
