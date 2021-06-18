using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class TravellersVM
    {

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double DesiredPrice { get; set; }
        public long PhoneNumber { get; set; }
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }



        public TravellersVM(TravellerDTO TravellerDTO)
        {
            Id = TravellerDTO.Id;
            FirstName = TravellerDTO.FirstName;
            LastName = TravellerDTO.LastName;
            Age = TravellerDTO.Age;
            DesiredPrice = TravellerDTO.DesiredPrice;
            PhoneNumber = TravellerDTO.PhoneNumber;
            StartDestination = TravellerDTO.StartDestination;
            EndDestination = TravellerDTO.EndDestination;
        }

        public TravellersVM()
        {
        }
    }
}