using System.ComponentModel.DataAnnotations;

namespace Gym.DTO
{
    public class AddMembershipDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price per month is required")]
        [Range(0,1000, ErrorMessage = "Value can't be less than 0")]
        public decimal PricePerMonth { get; set; }
    }
}
