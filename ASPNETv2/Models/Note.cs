namespace ASPNETv2.Models
{
    public class Note : BaseEntity.BaseEntity
    {
        public Guid NoteId { get; set; }
        public DateTime? Date { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Profile? Profile { get; set; }
        public Guid? ProfileId { get; set; }
        public string Username { get; set; }
    }
}