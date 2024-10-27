using System.ComponentModel.DataAnnotations;

namespace Gym.DTO
{
    public class UpdateMembershipDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(0,1000, ErrorMessage = "Value can't be less than 0")]
        public decimal PricePerMonth { get; set; }
    }
}
