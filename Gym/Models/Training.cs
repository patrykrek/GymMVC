namespace Gym.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
