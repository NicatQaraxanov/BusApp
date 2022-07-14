using System.Collections.Generic;

namespace Bus.Models
{
    public class Group : Entity
    {

        public string Title { get; set; }
        public virtual List<Student> Students { get; set; }

    }

}
