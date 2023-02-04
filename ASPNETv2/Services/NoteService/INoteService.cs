using ASPNETv2.Models.DTOs;

namespace ASPNETv2.Services.NoteService
{
    public interface INoteService
    {
        public NoteDTO GetQuickNote(Guid noteId);
    }
}
