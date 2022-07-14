using System.Collections.Generic;

namespace Bus.Models
{
    public class Driver : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string License { get; set; }
        public Car Car { get; set; }
        public virtual List<Ride> Rides { get; set; }
        public override string ToString()
        {
            return $"{this.LastName} {this.FirstName}";
        }
    }
}
