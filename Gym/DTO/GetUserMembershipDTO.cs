using Gym.Models;

namespace Gym.DTO
{
    public class GetUserMembershipDTO
    {
        public int Id { get; set; }
        public string? userId { get; set; }
        public int MembershipId { get; set; }
    }
}
