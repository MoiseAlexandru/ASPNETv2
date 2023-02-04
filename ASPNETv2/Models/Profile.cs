namespace ASPNETv2.Models
{
    public class Profile : BaseEntity.BaseEntity
    {
        public Guid ProfileId { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Group>? Groups { get; set; }
        public ICollection<Note>? Notes { get; set; }
        public ICollection<ProfileGroupRelation>? ProfileGroupRelations { get; set; }
    }
}
