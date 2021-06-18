using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationService.Implementations
{
    public class TripManagementService
    {
        private SharedTripSystemDBContext ctx = new SharedTripSystemDBContext();

        public List<TripDTO> Get()
        {
            List<TripDTO> tripsDto = new List<TripDTO>();

            // foreach (var item in ctx.Trips.ToList())
            // {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (Trip item in unitOfWork.TripRepository.Get())
                {
                    tripsDto.Add(new TripDTO
                    {

                        Id = item.Id,
                        MeetPlace = item.MeetPlace,
                        FinalDestination = item.FinalDestination,
                        Date = item.Date,
                        DistanceKms = item.DistanceKms,
                        TripPrice = item.TripPrice,
                        Details = item.Details


                    });
                }
                return tripsDto;
            }
        }
        public TripDTO GetById(int id)
        {
            TripDTO TripDTO = new TripDTO();
            // Trip trip = ctx.Trips.Find(id);
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {

                Trip trip = unitOfWork.TripRepository.GetByID(id);
                if (trip != null)
                {
                    TripDTO.Id = trip.Id;
                    TripDTO.MeetPlace = trip.MeetPlace;
                    TripDTO.FinalDestination = trip.FinalDestination;
                    TripDTO.Date = trip.Date;
                    TripDTO.DistanceKms = trip.DistanceKms;
                    TripDTO.TripPrice = trip.TripPrice;
                    TripDTO.Details = trip.Details;




                }

                return TripDTO;
            }

        }
        public List<TripDTO> Get(string Search)
        {
            List<TripDTO> tripsDto = new List<TripDTO>();
            Search = Search.ToLower();
            foreach (var item in ctx.Trips.ToList())
            {
                if (item.Id != 0 && item.FinalDestination != null && Search == item.FinalDestination.ToLower())
                    //   foreach (var item in unitOfWork.TripRepository.Get(x => x.FinalDestination.Contains(search)))
                    tripsDto.Add(new TripDTO
                    {
                       Id = item.Id,
                       MeetPlace = item.MeetPlace,
                       FinalDestination = item.FinalDestination,
                       Date = item.Date,
                       DistanceKms = item.DistanceKms,
                       TripPrice = item.TripPrice,
                       Details = item.Details


            });
            }
            return tripsDto;

        }
        public bool Save(TripDTO tripDTO)
        {
            Trip Trips = new Trip

            {

                
                MeetPlace = tripDTO.MeetPlace,
                FinalDestination = tripDTO.FinalDestination,
                Date = tripDTO.Date,
                DistanceKms = tripDTO.DistanceKms,
                TripPrice = tripDTO.TripPrice,
                Details = tripDTO.Details
            };

            try
            {
                
                    using (UnitOfWork unit = new UnitOfWork())
                    {
                        unit.TripRepository.Insert(Trips);
                        unit.Save();
                    }
                 //   ctx.Trips.Add(Trips);
               // ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // updates the records of the table 
        public bool Edit(TripDTO tripDTO)
        {
            Trip Edited = null;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Edited = unitOfWork.TripRepository.GetByID(tripDTO.Id);
            }
            if (Edited != null)
            {
                
               
                Edited.Id = tripDTO.Id;
                Edited.MeetPlace = tripDTO.MeetPlace;
                Edited.FinalDestination = tripDTO.FinalDestination;
                Edited.Date = tripDTO.Date;
                Edited.DistanceKms = tripDTO.DistanceKms;
                Edited.TripPrice = tripDTO.TripPrice;
                Edited.Details = tripDTO.Details;

            }
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.TripRepository.Update(Edited);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
           {
               try
               {
                using (UnitOfWork unit = new UnitOfWork())
                {
                    Trip trip = unit.TripRepository.GetByID(id);
                    unit.TripRepository.Delete(trip);
                    unit.Save();
                }
                    //Trip trip = ctx.Trips.Find(id);
                   //ctx.Trips.Remove(trip);
                   //ctx.SaveChanges();
                   return true;
               }
               catch
               {
                   return false;
               }
           }

     /*   public bool Edit(DriverDTO driverDTO)
        {
            try
            {
                using (UnitOfWork unit = new UnitOfWork())
                {
                    DriverDTO driverDTO = unit.DriverRepository.GetByID(driverDTO.Id);
                    user.FirstName = userDTO.FirstName;
                    user.LastName = userDTO.LastName;
                    user.Email = userDTO.Email;
                    user.Password = userDTO.Password;
                    user.Age = userDTO.Age;
                    user.Gender = userDTO.Gender;

                    unit.UserRepository.Update(user);
                    unit.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        */

    }
}