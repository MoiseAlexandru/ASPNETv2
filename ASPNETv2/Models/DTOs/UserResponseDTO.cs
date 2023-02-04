namespace ASPNETv2.Models.DTOs
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public UserResponseDTO(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            UserName = user.UserName;
            Token = token;
        }
    }
}
