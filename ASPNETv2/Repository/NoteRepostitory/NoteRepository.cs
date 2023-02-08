using ASPNETv2.Data;
using ASPNETv2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETv2.Repository.NoteRepostitory
{
    public class NoteRepository : GenericRepository.GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(DatabaseContext context) : base(context) { }
        public List<Note> GetAllWithInclude()
        {
            return _table.Include(note => note.Profile).ToList();
        }

        public async Task<List<Note>> GetAllWithIncludeAsync()
        {
            return await _table.Include(note => note.Profile).ToListAsync();
        }
        public Note GetQuickNote(Guid noteId)
        {
            return _table.Include(note => note.Profile).FirstOrDefault(note => note.NoteId == noteId);
        }
        public async Task <Note> FindNoteByIdAsync(Guid id)
        {
            return await _table.FirstOrDefaultAsync(note => note.NoteId == id);
        }
        public async Task <List <Note>> GetAllNotes()
        {
            return await _table.ToListAsync();
        }
    }
}
