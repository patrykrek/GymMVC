using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class UserRole
    {
        [Required(ErrorMessage = "User email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string[] Roles { get; set; }
    }
}
