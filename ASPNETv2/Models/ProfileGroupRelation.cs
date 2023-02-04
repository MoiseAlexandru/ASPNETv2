namespace ASPNETv2.Models
{
    public class ProfileGroupRelation
    {
        public Guid ProfileId { get; set; }
        public Profile? Profile { get; set; }
        public Guid GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
