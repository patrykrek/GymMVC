namespace Gym.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
