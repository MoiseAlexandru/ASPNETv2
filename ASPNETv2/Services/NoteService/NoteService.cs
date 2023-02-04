using ASPNETv2.Models.DTOs;
using ASPNETv2.Repository.NoteRepostitory;

namespace ASPNETv2.Services.NoteService
{
    public class NoteService : INoteService
    {
        public INoteRepository _noteRepository;
        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public NoteDTO GetQuickNote(Guid noteId)
        {
            var resultQuery = _noteRepository.GetQuickNote(noteId);
            NoteDTO result = new NoteDTO();
            result.Title = resultQuery.Title;
            result.Description = resultQuery.Description;
            result.Username = resultQuery.Profile.Username;
            return result;
        }
    }
}
