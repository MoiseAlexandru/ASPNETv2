using ASPNETv2.Models;
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
        public async Task DeleteNote(Note note)
        {
            await Task.Run(() => _noteRepository.Delete(note));
            await _noteRepository.SaveAsync();
        }
        public async Task <Note> FindNoteByIdAsync(Guid noteId)
        {
            return await _noteRepository.FindNoteByIdAsync(noteId);
        }
        public async Task CreateNote(Note note)
        {
            await _noteRepository.CreateAsync(note);
        }
        public async Task <List <NoteDTO> > GetAllNotes()
        {
            List<Note> notes = await _noteRepository.GetAllNotes();
            List<NoteDTO> converted = new List<NoteDTO>();
            foreach(var note in notes)
            {
                NoteDTO currentNote = new NoteDTO();
                currentNote.NoteId = note.NoteId;
                currentNote.Username = note.Username;
                currentNote.Description = note.Description;
                currentNote.Title = note.Title;
                currentNote.ProfileId = note.ProfileId;
                converted.Add(currentNote);
            }
            return converted;
        }
        public async Task ModifyNote(Note note, NoteDTO noteDTO)
        {
            note.Title = noteDTO.Title;
            note.Description = noteDTO.Description;
            _noteRepository.Update(note);
            await _noteRepository.SaveAsync();
        }
    }
}
