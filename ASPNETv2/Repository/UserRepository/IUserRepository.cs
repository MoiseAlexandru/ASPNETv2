using ASPNETv2.Models;
using ASPNETv2.Repository.GenericRepository;

namespace ASPNETv2.Repository.UserRepository
{
    public interface IUserRepository : IGenericRepository <User>
    {
        List<User> GetAllWithInclude();
        Task <List<User> > GetAllWithIncludeAsync();
        User GetUserByEmail(string email);
        Task <User> GetUserByEmailAsync(string email);
    }
}
