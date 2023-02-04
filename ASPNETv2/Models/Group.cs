namespace ASPNETv2.Models
{
    public class Group : BaseEntity.BaseEntity
    {
        public Guid GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? Description { get; set; }
        public ICollection <Profile>? Profiles { get; set; }
    }
}
