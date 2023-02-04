using System.ComponentModel.DataAnnotations;

namespace ASPNETv2.Models.DTOs
{
    public class UserRequestDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
