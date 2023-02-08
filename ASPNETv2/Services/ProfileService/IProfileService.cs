using ASPNETv2.Models;
using ASPNETv2.Models.DTOs;

namespace ASPNETv2.Services.ProfileService
{
    public interface IProfileService
    {
        List <GroupJoinInDTO> GetGroupListByUsername(string username);
        Task <Profile> CreateOnUserRegistration(User user);
        Task<List<ProfileDTO>> GetProfileList();
        Task LinkToUser(Profile profile, User user);
        Task UpdateProfile(ModifyProfileDTO newProfile);
        Task <Profile> GetProfileByUsername(string username);
        Task LinkNote(Profile profile, Note note);
    }
}
