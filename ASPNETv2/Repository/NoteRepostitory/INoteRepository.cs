using ASPNETv2.Models;
using ASPNETv2.Repository.GenericRepository;

namespace ASPNETv2.Repository.NoteRepostitory
{
    public interface INoteRepository : IGenericRepository<Note>
    {
        List<Note> GetAllWithInclude();
        Task<List<Note>> GetAllWithIncludeAsync();
    }
}
