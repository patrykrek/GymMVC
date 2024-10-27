using System.ComponentModel.DataAnnotations;

namespace Gym.DTO
{
    public class AddTrainingDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Trainer ID is required")]
        [Range(0,int.MaxValue, ErrorMessage = "Value  can't be less than 0")]
        public int TrainerId { get; set; }
    }
}
