using ASPNETv2.Models;
using ASPNETv2.Repository.GenericRepository;

namespace ASPNETv2.Repository.ProfileRepository
{
    public interface IProfileRepository : IGenericRepository <Profile>
    {
        List<Profile> GetAllWithInclude();
        List<Profile> GetAllWithJoin();
    }
}
