using ASPNETv2.Models;
using ASPNETv2.Repository.GenericRepository;

namespace ASPNETv2.Repository.GroupRepository
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        List<Group> GetAllWithInclude();
        Task<List<Group>> GetAllWithIncludeAsync();
    }
}
