using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class TripsVM
    {
        public int Id { get; set; }
        [Required]
        public string MeetPlace { get; set; }
        [Required]
        public string FinalDestination { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int DistanceKms { get; set; }
        public double TripPrice { get; set; }
        public string Details { get; set; }
       

      

        public TripsVM(TripDTO TripDTO)
        {
            Id = TripDTO.Id;
            MeetPlace = TripDTO.MeetPlace;
            FinalDestination = TripDTO.FinalDestination;
            Date = TripDTO.Date;
            DistanceKms = TripDTO.DistanceKms;
            TripPrice = TripDTO.TripPrice;
            Details = TripDTO.Details;
        }

        public TripsVM()
        {
        }
    }
}
    
