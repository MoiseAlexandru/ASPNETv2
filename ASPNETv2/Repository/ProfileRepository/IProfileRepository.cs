using ASPNETv2.Models;
using ASPNETv2.Models.DTOs;
using ASPNETv2.Repository.GenericRepository;

namespace ASPNETv2.Repository.ProfileRepository
{
    public interface IProfileRepository : IGenericRepository <Profile>
    {
        List<Profile> GetAllWithInclude();
        Task <List<Profile>> GetAllWithIncludeAsync();
        List<Profile> GetAllWithJoin();
        Task <List<Profile>> GetAllWithJoinAsync();
        Profile GetGroupsByUser(string username);
        Task <Profile> GetGroupsByUserAsync(string username);
        Task<List<Profile>> GetProfileList();
        Task<Profile> GetProfileByUsername(string username);
    }
}
