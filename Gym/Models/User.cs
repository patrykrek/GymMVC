using Microsoft.AspNetCore.Identity;

namespace Gym.Models
{
    public class User : IdentityUser
    {
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<UserMembership> UserMemberships { get; set; }
    }
}
