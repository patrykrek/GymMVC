using Gym.Models;

namespace Gym.DTO
{
    public class GetReservationDTO
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public string UserId { get; set; }
        public int TrainingId { get; set; }

    }
}
