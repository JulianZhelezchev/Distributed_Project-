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
    public class TravellerManagementService
    {
        private SharedTripSystemDBContext ctx = new SharedTripSystemDBContext();

        public List<TravellerDTO> Get()
        {
            List<TravellerDTO> travellersDto = new List<TravellerDTO>();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (Traveller item in unitOfWork.TravellerRepository.Get())
                //  foreach (var item in ctx.Travellers.ToList())
                {
                    travellersDto.Add(new TravellerDTO
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Age = item.Age,
                        DesiredPrice = item.DesiredPrice,
                        PhoneNumber = item.PhoneNumber,
                        StartDestination = item.StartDestination,
                        EndDestination = item.EndDestination



                    });
                }
                return travellersDto;
            }
        }
        public TravellerDTO GetById(int id)
        {
            TravellerDTO TravellerDTO = new TravellerDTO();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {

                Traveller traveller = unitOfWork.TravellerRepository.GetByID(id);

              //  Traveller traveller = ctx.Travellers.Find(id);
                if (traveller != null)
                {
                    TravellerDTO.Id = traveller.Id;
                    TravellerDTO.FirstName = traveller.FirstName;
                    TravellerDTO.LastName = traveller.LastName;
                    TravellerDTO.Age = traveller.Age;
                    TravellerDTO.DesiredPrice = traveller.DesiredPrice;
                    TravellerDTO.PhoneNumber = traveller.PhoneNumber;
                    TravellerDTO.StartDestination = traveller.StartDestination;
                    TravellerDTO.EndDestination = traveller.EndDestination;



                }

                return TravellerDTO;
            }
        }
            public bool Save(TravellerDTO TravellerDTO)
            {
                Traveller Travellers = new Traveller

                {

                    FirstName = TravellerDTO.FirstName,
                    LastName = TravellerDTO.LastName,
                    Age = TravellerDTO.Age,
                    DesiredPrice = TravellerDTO.DesiredPrice,
                    PhoneNumber = TravellerDTO.PhoneNumber,
                    StartDestination = TravellerDTO.StartDestination,
                    EndDestination = TravellerDTO.EndDestination,


                };

              try { 
                 using (UnitOfWork unit = new UnitOfWork())
                 {
                    unit.TravellerRepository.Insert(Travellers);
                    unit.Save();
                }
                
                   // ctx.Travellers.Add(Travellers);
                  //  ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        public List<TravellerDTO> Get(string Search)
        {
            List<TravellerDTO> travellersDto = new List<TravellerDTO>();
            Search = Search.ToLower();
            foreach (var item in ctx.Travellers.ToList())
            {
                if (item.Id != 0 && item.StartDestination != null && Search == item.StartDestination.ToLower())
                    //   foreach (var item in unitOfWork.TravellerRepository.Get(x => x.FirstName.Contains(search)))
                    travellersDto.Add(new TravellerDTO
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Age = item.Age,
                        DesiredPrice = item.DesiredPrice,
                        PhoneNumber = item.PhoneNumber,
                        StartDestination = item.StartDestination,
                        EndDestination = item.EndDestination,


                    });
            }
            return travellersDto;

        }
        // updates the records of the table 
        public bool Edit(TravellerDTO travellerDTO)
        {
            Traveller Edited = null;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Edited = unitOfWork.TravellerRepository.GetByID(travellerDTO.Id);
            }
            if (Edited != null)
            {
                Edited.Id = travellerDTO.Id;
                Edited.FirstName = travellerDTO.FirstName;
                Edited.LastName = travellerDTO.LastName;
                Edited.Age = travellerDTO.Age;
                Edited.DesiredPrice = travellerDTO.DesiredPrice;
                Edited.PhoneNumber = travellerDTO.PhoneNumber;
                Edited.StartDestination = travellerDTO.StartDestination;
                Edited.EndDestination = travellerDTO.EndDestination;

            }
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.TravellerRepository.Update(Edited);
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
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Traveller traveller = unitOfWork.TravellerRepository.GetByID(id);
                    unitOfWork.TravellerRepository.Delete(traveller);
                    unitOfWork.Save();
                }

                Traveller Traveller = ctx.Travellers.Find(id);
                    //ctx.Travellers.Remove(Traveller);
                    //ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }



