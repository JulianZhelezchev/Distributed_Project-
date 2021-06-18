using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class DriverDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double TripPrice { get; set; }
        public long PhoneNumber { get; set; }
        public string VehicleType { get; set; }
        public string VehicleBrand { get; set; }
    }
}
