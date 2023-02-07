using ASPNETv2.Models;
using ASPNETv2.Models.DTOs;
using ASPNETv2.Repository.ProfileRepository;

namespace ASPNETv2.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        public IProfileRepository _profileRepository;
        public ProfileService(IProfileRepository profileRepository)
        { 
            _profileRepository = profileRepository;
        }
        public List <GroupJoinInDTO> GetGroupListByUsername(string username)
        {
            Profile profile = _profileRepository.GetGroupsByUser(username);
            List<GroupJoinInDTO> result = new List<GroupJoinInDTO> ();
            foreach(var group in profile.Groups)
            {
                GroupJoinInDTO currentEntrance = new GroupJoinInDTO();
                currentEntrance.Username = profile.Username;
                currentEntrance.FirstName = profile.FirstName;
                currentEntrance.LastName = profile.LastName;
                currentEntrance.GroupName = group.GroupName;
                result.Append(currentEntrance);
            }
            return result;
        }
        public async Task <Profile> CreateOnUserRegistration(User user)
        {
            Profile newProfile = new Profile();
            newProfile.Id = Guid.NewGuid();
            newProfile.Username = user.UserName;
            newProfile.User = user;
            newProfile.UserId = user.UserId;
            await Task.Run(() => _profileRepository.Create(newProfile));
            await _profileRepository.SaveAsync();
            return newProfile;
        }
        public async Task<List<Profile>> GetProfileList()
        {
            return await _profileRepository.GetProfileList();
        }
        public async Task LinkToUser(Profile profile, User user)
        {
            profile.UserId = user.Id;
            _profileRepository.Update(profile);
            await _profileRepository.SaveAsync();
        }
    }
}
