using ASPNETv2.Data;
using ASPNETv2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETv2.Repository.ProfileRepository
{
    public class ProfileRepository : GenericRepository.GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(DatabaseContext context) : base(context) { }
        public List<Profile> GetAllWithInclude()
        {
            return _table.Include(profile => profile.User).Include(profile => profile.Groups).Include(profile => profile.Notes).ToList();
        }

        public async Task<List<Profile>> GetAllWithIncludeAsync()
        {
            return await _table.Include(profile => profile.User).Include(profile => profile.Groups).Include(profile => profile.Notes).ToListAsync();
        }

        // intre useri si profiluri de ex
        public List<Profile> GetAllWithJoin()
        {
            var result = _table.Join(_context.Profiles, profile => profile.ProfileId, user => user.ProfileId,
                (profile, user) => new { profile, user }).Select(obj => obj.profile);
            return result.ToList();
        }

        public async Task<List<Profile>> GetAllWithJoinAsync()
        {
            var result = _table.Join(_context.Profiles, profile => profile.ProfileId, user => user.ProfileId,
                (profile, user) => new { profile, user }).Select(obj => obj.profile);
            return await result.ToListAsync();
        }

        public Profile GetGroupsByUser(string username)
        {
            var result = _table.FirstOrDefault(profile => profile.Username.Equals(username));
            return result;
        }
        public async Task <Profile> GetGroupsByUserAsync(string username)
        {
            var result = _table.FirstOrDefaultAsync(profile => profile.Username.Equals(username));
            return await result;
        }
    }
}
