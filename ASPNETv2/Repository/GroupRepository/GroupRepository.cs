using ASPNETv2.Data;
using ASPNETv2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETv2.Repository.GroupRepository
{
    public class GroupRepository : GenericRepository.GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(DatabaseContext context) : base(context) { }
        public List<Group> GetAllWithInclude()
        {
            return _table.Include(group => group.Profiles).ToList();
        }

        public async Task<List<Group>> GetAllWithIncludeAsync()
        {
            return await _table.Include(group => group.Profiles).ToListAsync();
        }
    }
}
