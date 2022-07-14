namespace Bus.Models
{
    public class RideStudent : Entity
    {
        public Ride Ride { get; set; }
        public int RideId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public string Status { get; set; } = "onway";
    }
}
