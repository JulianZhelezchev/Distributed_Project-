using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class DriversVM
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double TripPrice { get; set; }
        public long PhoneNumber { get; set; }
        public string VehicleType { get; set; }
        public string VehicleBrand { get; set; }




        public DriversVM(DriverDTO DriverDTO)
        {
            Id = DriverDTO.Id;
            FirstName = DriverDTO.FirstName;
            LastName = DriverDTO.LastName;
            Age = DriverDTO.Age;
            TripPrice = DriverDTO.TripPrice;
            PhoneNumber = DriverDTO.PhoneNumber;
            VehicleType = DriverDTO.VehicleType;
            VehicleBrand = DriverDTO.VehicleBrand;
        }

        public DriversVM()
        {
        }
    }
}