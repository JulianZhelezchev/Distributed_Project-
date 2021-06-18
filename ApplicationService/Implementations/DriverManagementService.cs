using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class DriverManagementService
    {
        private SharedTripSystemDBContext ctx = new SharedTripSystemDBContext();
        // functions returning all records in the list
        public List<DriverDTO> Get()
        {
            List<DriverDTO> driversDto = new List<DriverDTO>();

         //   foreach (var item in ctx.Drivers.ToList())
         using (UnitOfWork unitOfWork = new UnitOfWork())
                foreach (var item in unitOfWork.DriverRepository.Get())
                {
                driversDto.Add(new DriverDTO 
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age,
                    TripPrice = item.TripPrice,
                    PhoneNumber = item.PhoneNumber,
                    VehicleType = item.VehicleType,
                    VehicleBrand = item.VehicleBrand


                });
            }
            return driversDto;

        }

        public DriverDTO GetById(int id)
        {
            DriverDTO driverDTO = new DriverDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {


                //   Driver driver = ctx.Drivers.Find(id);
                Driver driver = unitOfWork.DriverRepository.GetByID(id);
                if (driver != null)
                {
                    driverDTO.Id = driver.Id;
                    driverDTO.FirstName = driver.FirstName;
                    driverDTO.LastName = driver.LastName;
                    driverDTO.Age = driver.Age;
                    driverDTO.TripPrice = driver.TripPrice;
                    driverDTO.PhoneNumber = driver.PhoneNumber;
                    driverDTO.VehicleType = driver.VehicleType;
                    driverDTO.VehicleBrand = driver.VehicleBrand;


                }

                return driverDTO;
            }


        }

    

        public List<DriverDTO> Get(string Search)
        {
            List<DriverDTO> driversDto = new List<DriverDTO>();
            Search = Search.ToLower();
            foreach (var item in ctx.Drivers.ToList())
            {
                if (item.Id!=0 && item.FirstName!=null && Search == item.FirstName.ToLower())
                    //   foreach (var item in unitOfWork.DriverRepository.Get(x => x.FirstName.Contains(search)))
                    driversDto.Add(new DriverDTO
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age,
                    TripPrice = item.TripPrice,
                    PhoneNumber = item.PhoneNumber,
                    VehicleType = item.VehicleType,
                    VehicleBrand = item.VehicleBrand


                });
            }
            return driversDto;

        }
  
            public bool Save(DriverDTO driverDTO)
        {
            Driver drivers = new Driver

            {
                FirstName = driverDTO.FirstName,
                LastName = driverDTO.LastName,
                Age = driverDTO.Age,
                TripPrice = driverDTO.TripPrice,
                PhoneNumber = driverDTO.PhoneNumber,
                VehicleType = driverDTO.VehicleType,
                VehicleBrand = driverDTO.VehicleBrand


            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.DriverRepository.Insert(drivers);
                    unitOfWork.Save();
               //    ctx.Drivers.Add(drivers);
               //     ctx.SaveChanges();
                  return true;
                }
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
                    Driver driver = unitOfWork.DriverRepository.GetByID(id);
                    unitOfWork.DriverRepository.Delete(driver);
                    unitOfWork.Save();
                    // Driver driver = ctx.Drivers.Find(id);
                    // ctx.Drivers.Remove(driver);
                    //  ctx.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }   // updates the records of the table 
           public bool Edit(DriverDTO driverDTO)
           {
               Driver Edited = null;
               using (UnitOfWork unitOfWork = new UnitOfWork())
               {
                Edited = unitOfWork.DriverRepository.GetByID(driverDTO.Id);
               }
            if (Edited != null)
            {
                Edited.Id = driverDTO.Id;
                Edited.FirstName = driverDTO.FirstName;
                Edited.LastName = driverDTO.LastName;
                Edited.Age = driverDTO.Age;
                Edited.TripPrice = driverDTO.TripPrice;
                Edited.PhoneNumber = driverDTO.PhoneNumber;
                Edited.VehicleType = driverDTO.VehicleType;
                Edited.VehicleBrand = driverDTO.VehicleBrand;

            }
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.DriverRepository.Update(Edited);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
           }
             /*
            public  bool Update (DriverDTO driverDTO)
        
            Driver drivers = new Driver

            {
                Id= driverDTO.Id,
                FirstName = driverDTO.FirstName,
                LastName = driverDTO.LastName,
                Age = driverDTO.Age,
                TripPrice = driverDTO.TripPrice,
                PhoneNumber = driverDTO.PhoneNumber,
                VehicleType = driverDTO.VehicleType,
                VehicleBrand = driverDTO.VehicleBrand


            };

            try
            {
                ctx.Drivers.Attach(drivers);
                ctx.Entry(drivers).State = EntityState.Modified; 
                ctx.SaveChanges();
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



    

