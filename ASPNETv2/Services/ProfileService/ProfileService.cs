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
        public List<GroupJoinInDTO> GetGroupListByUsername(string username)
        {
            Profile profile = _profileRepository.GetGroupsByUser(username);
            List<GroupJoinInDTO> result = new List<GroupJoinInDTO>();
            foreach (var group in profile.Groups)
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
        public async Task <Profile> GetProfileByUsername(string username)
        {
            Profile profile = await _profileRepository.GetProfileByUsername(username);
            return profile;
        }
        public async Task<Profile> CreateOnUserRegistration(User user)
        {
            Profile newProfile = new Profile();
            newProfile.ProfileId = user.UserId;
            newProfile.UserId = user.UserId;
            newProfile.Username = user.UserName;
            newProfile.User = user;
            newProfile.Notes = new List<Note>();
            await Task.Run(() => _profileRepository.Create(newProfile));
            await _profileRepository.SaveAsync();
            return newProfile;
        }
        public async Task<List<ProfileDTO>> GetProfileList()
        {
            List <Profile> queryResult = await _profileRepository.GetProfileList();
            List<ProfileDTO> convertedResult = new List<ProfileDTO>();
            foreach(var profile in queryResult)
            {
                ProfileDTO profileDTO = new ProfileDTO();
                profileDTO.Username = profile.Username;
                profileDTO.FirstName = profile.FirstName;
                profileDTO.LastName = profile.LastName;
                profileDTO.Address = profile.Address;
                profileDTO.ProfileId = profile.ProfileId;
                profileDTO.UserId = profile.UserId;
                //profileDTO.NoteIds = profile.NoteIds;
                //profileDTO.GroupIds = profile.GroupIds;
                convertedResult.Add(profileDTO);
            }
            return convertedResult;
        }
        public async Task LinkToUser(Profile profile, User user)
        {
            profile.ProfileId = user.UserId;
            _profileRepository.Update(profile);
            await _profileRepository.SaveAsync();
        }

        public async Task UpdateProfile(ModifyProfileDTO newProfile)
        {
            Profile profileToUpdate = await _profileRepository.GetProfileByUsername(newProfile.Username);
            if (newProfile.FirstName != null)
            {
                profileToUpdate.FirstName = newProfile.FirstName;
            }
            if (newProfile.LastName != null)
            {
                profileToUpdate.LastName = newProfile.LastName;
            }
            if (newProfile.Address != null)
            {
                profileToUpdate.Address = newProfile.Address;
            }
            _profileRepository.Update(profileToUpdate);
            await _profileRepository.SaveAsync();
        }
        public async Task LinkNote(Profile profile, Note note)
        {
            if(profile.Notes == null)
                profile.Notes = new List<Note>();
            profile.Notes.Add(note);
            _profileRepository.Update(profile);
            await _profileRepository.SaveAsync();
        }
    }
}