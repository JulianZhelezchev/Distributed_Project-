using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
   public class Trip : BaseEntity
    {
       
        public string MeetPlace { get; set; }
        public string FinalDestination { get; set; }
        public DateTime Date { get; set; }
        public int DistanceKms { get; set; }
        public double TripPrice { get; set; }
        public string Details { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
