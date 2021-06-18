using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
   public class Traveller : BaseEntity
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double DesiredPrice { get; set; }
        public long PhoneNumber { get; set; }
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
