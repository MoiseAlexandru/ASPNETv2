using ASPNETv2.Models;
using ASPNETv2.Repository.GenericRepository;

namespace ASPNETv2.Repository.UserRepository
{
    public interface IUserRepository : IGenericRepository <User>
    {
        Task <List<User> > GetUserListAsync();
        Task <List<User> > GetAllWithIncludeAsync();
        User GetUserByEmail(string email);
        Task <User> GetUserByEmailAsync(string email);
        Task <User> GetUserByUsername(string username);
        User FindByUsername(string username);
    }
}
