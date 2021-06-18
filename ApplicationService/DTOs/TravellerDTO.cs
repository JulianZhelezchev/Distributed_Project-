using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class TravellerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double DesiredPrice { get; set; }
        public long PhoneNumber { get; set; }
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }
    }
}
