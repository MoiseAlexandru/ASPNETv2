using ASPNETv2.Models.DTOs;

namespace ASPNETv2.Services.ProfileService
{
    public interface IProfileService
    {
        List <GroupJoinInDTO> GetGroupListByUsername(string username);
    }
}
