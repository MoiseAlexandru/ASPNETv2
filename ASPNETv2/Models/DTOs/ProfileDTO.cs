namespace ASPNETv2.Models.DTOs
{
    public class ProfileDTO
    {
        public Guid ProfileId { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }
        //public List<string>? GroupIds { get; set; } 
        //public List<string>? NoteIds { get; set; }
    }
}
