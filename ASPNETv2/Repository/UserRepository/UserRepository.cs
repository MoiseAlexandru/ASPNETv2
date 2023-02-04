using ASPNETv2.Data;
using ASPNETv2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETv2.Repository.UserRepository
{
    public class UserRepository : GenericRepository.GenericRepository <User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }
        public List<User> GetAllWithInclude()
        {
            return _table.Include(user => user.Profile).ToList();
        }

        public async Task<List<User>> GetAllWithIncludeAsync()
        {
            return await _table.Include(user => user.Profile).ToListAsync();
        }

    }
}
