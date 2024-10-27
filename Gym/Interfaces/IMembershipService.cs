using Gym.DTO;
using Gym.Models;

namespace Gym.Interfaces
{
    public interface IMembershipService
    {
        Task<List<GetMembershipDTO>> DisplayMembershipAsync();
        Task<List<GetUserMembershipDTO>> DisplayUserMembershipAsync(string userId);
        Task<List<GetUserMembershipDTO>> DisplayEveryUserMembershipsAsync();
        Task<GetMembershipDTO> AddMembershipAsync(AddMembershipDTO membership);
        Task DeleteMembershipAsync(UpdateMembershipDTO membership);
        Task<UpdateMembershipDTO> GetMembershipForEditAsync(int id);
        Task EditMembershipAsync(UpdateMembershipDTO membership);
        Task BuyMembershipAsync(int membershipId, string userId);
    }
}
