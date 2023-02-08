using ASPNETv2.Models;
using ASPNETv2.Models.DTOs;
using ASPNETv2.Services.NoteService;
using ASPNETv2.Services.ProfileService;
using ASPNETv2.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        private readonly IProfileService _profileService;
        public NoteController(INoteService noteService, IProfileService profileService)
        {
            _noteService = noteService;
            _profileService = profileService;
        }
        [HttpGet("get-note-by-id")]
        public IActionResult GetQuickNote(Guid id)
        {
            var result = _noteService.GetQuickNote(id);
            return Ok(result);
        }
        [HttpGet("get-all-notes")]
        public async Task <IActionResult> GetAllNotes()
        {
            var result = await _noteService.GetAllNotes();
            return Ok(result);
        }
        
        [HttpDelete("delete-note")]
        public async Task <IActionResult> DeleteNoteById(Guid id)
        {
            var note = await _noteService.FindNoteByIdAsync(id);
            await _noteService.DeleteNote(note);
            return Ok(note);
        }
        [HttpPost("create-note")]
        public async Task <IActionResult> CreateNote(NoteDTO noteDTO)
        {
            Profile owner = await _profileService.GetProfileByUsername(noteDTO.Username);
            Note note = new Note
            {
                NoteId = noteDTO.NoteId,
                Date = DateTime.Now,
                Title = noteDTO.Title,
                Description = noteDTO.Description,
                Username = noteDTO.Username,
                ProfileId = owner.UserId
            };
            await _noteService.CreateNote(note);
            await _profileService.LinkNote(owner, note);
            return Ok();
        }
        [HttpPatch("modify-note")]
        public async Task <IActionResult> ModifyNote(NoteDTO noteDTO)
        {
            Note toModify = await _noteService.FindNoteByIdAsync(noteDTO.NoteId);
            await _noteService.ModifyNote(toModify, noteDTO);
            return Ok();
        }
    }
}
