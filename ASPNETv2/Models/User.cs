using ASPNETv2.Models.Enum;
using System.Text.Json.Serialization;

namespace ASPNETv2.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public Guid? ProfileId { get; set; }
        public Profile? Profile { get; set; }
        [JsonIgnore]
        public string? PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}
