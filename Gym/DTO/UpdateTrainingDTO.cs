using System.ComponentModel.DataAnnotations;

namespace Gym.DTO
{
    public class UpdateTrainingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }

        [Range(0,int.MaxValue, ErrorMessage = "Value can't be less than 0 ")]
        public int TrainerId { get; set; }
    }
}
