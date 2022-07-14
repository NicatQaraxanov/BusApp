using System.Collections.Generic;

namespace Bus.Models
{
    public class Ride : Entity
    {
        public string Type { get; set; }
        public Driver Driver { get; set; }
        public int DriverId { get; set; }
        public virtual List<RideStudent> RideStudents { get; set; }
    }
}
