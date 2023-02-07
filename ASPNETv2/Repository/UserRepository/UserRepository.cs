using ASPNETv2.Data;
using ASPNETv2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETv2.Repository.UserRepository
{
    public class UserRepository : GenericRepository.GenericRepository <User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }
        public List<User> GetFullUserList()
        {
            return _table.Include(user => user.Profile).ToList();
        }

        public async Task <List <User> > GetUserListAsync()
        {
            var result = await (from user in _table
                           select user).ToListAsync();
            return result;
        }

        public User FindByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.UserName == username);
        }

        public async Task<List<User>> GetAllWithIncludeAsync()
        {
            return await _table.Include(user => user.Profile).ToListAsync();
        }
        public User GetUserByEmail(string email)
        { 
            return _table.Include(user => user.Profile).FirstOrDefault(user => user.Email == email);
        }
        public async Task <User> GetUserByEmailAsync(string email)
        {
            return await _table.Include(user => user.Profile).FirstOrDefaultAsync(user => user.Email == email);
        }
        public async Task <User> GetUserByUsername(string username)
        {
            return await _table.FirstOrDefaultAsync(user => user.UserName == username);
        }
    }
}
