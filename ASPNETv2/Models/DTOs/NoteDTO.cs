using System.ComponentModel.DataAnnotations;

namespace ASPNETv2.Models.DTOs
{
    public class NoteDTO
    {
        public Guid NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Username { get; set; }
        public Guid? ProfileId { get; set; }
    }
}
