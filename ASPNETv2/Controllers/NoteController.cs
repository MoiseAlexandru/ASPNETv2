using ASPNETv2.Services.NoteService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        [HttpGet]
        public IActionResult GetQuickNote(Guid id)
        {
            var result = _noteService.GetQuickNote(id);
            return Ok(result);
        }
    }
}
