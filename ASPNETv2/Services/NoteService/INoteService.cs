using ASPNETv2.Models;
using ASPNETv2.Models.DTOs;

namespace ASPNETv2.Services.NoteService
{
    public interface INoteService
    {
        NoteDTO GetQuickNote(Guid noteId);
        Task <Note> FindNoteByIdAsync(Guid noteId);
        Task DeleteNote(Note note);
        Task CreateNote(Note note);
        Task <List <NoteDTO>> GetAllNotes();
        Task ModifyNote(Note note, NoteDTO noteDTO);
    }
}
