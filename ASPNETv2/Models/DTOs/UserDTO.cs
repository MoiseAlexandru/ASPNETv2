using ASPNETv2.Models.Enum;
using System.Text.Json.Serialization;

namespace ASPNETv2.Models.DTOs
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string UserName { get; set; }
        public Guid? ProfileId { get; set; }
        [JsonIgnore]
        public string? PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}
