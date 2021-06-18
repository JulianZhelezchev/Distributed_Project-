using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class TripDTO
    {
        public int Id { get; set; }
        public string MeetPlace { get; set; }
        public string FinalDestination { get; set; }
        public DateTime Date { get; set; }
        public int DistanceKms { get; set; }
        public double TripPrice { get; set; }
        public string Details { get; set; }
       
    }
}
