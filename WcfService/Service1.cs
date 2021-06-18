using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        private TravellerManagementService travellerManagementService = new TravellerManagementService();

        private DriverManagementService driverManagementService = new DriverManagementService();

        private TripManagementService tripManagementService = new TripManagementService();

       public List<TravellerDTO> GetTravellers()
       {
           return travellerManagementService.Get();
       }
        public List<DriverDTO> GetDrivers()
        {
            return driverManagementService.Get();
        }
        
        public List<TripDTO> GetTrips()
        {
            return tripManagementService.Get();
        }

        public string PostTraveller(TravellerDTO TravellerDto)
        {
            if (!travellerManagementService.Save(TravellerDto))
            {
                return "Traveller is Saved!";

            }
            else
            {
                return "Traveller isn't Saved!";
            }
        }

        public string PutDriver(DriverDTO driverDTOs)
        {
            if (!driverManagementService.Edit(driverDTOs))
            {
                return "Driver is not updated!";
            }
            else
            {
                return "Driver successfully updated!";
            }
        }
        public string PostDriver(DriverDTO driverDTOs)
        {
            if (!driverManagementService.Save(driverDTOs))
            {
                return "Driver is not saved!";
            }
            else
            {
                return "Driver successfully saved!";
            }
        }
        public string PostTrip(TripDTO tripDTOs)
        {
            if (!tripManagementService.Save(tripDTOs))
            {
                return "Trip is not saved!";
            }
            else
            {
                return "Trip successfully saved!";
            }
        }

        public string DeleteTraveller(int id)
        {
            if (!travellerManagementService.Delete(id))
            {
                return "Traveller is Deleted!";

            }
            else
            {
                return "Traveller isn't Deleted!";
            }
        }
        public string DeleteDriver(int id)
        {
            if (!driverManagementService.Delete(id))
            {
                return "Driver is not deleted!";
            }
            else
            {
                return "Driver successfully deleted!";
            }
        }
        public string DeleteTrip(int id)
        {
            if (!tripManagementService.Delete(id))
            {
                return "Trip is not deleted!";
            }
            else
            {
                return "Trip successfully deleted!";
            }
        } 

        public TravellerDTO GetTravellerById(int id)
        {
            return travellerManagementService.GetById(id);
        }

        public DriverDTO GetDriverById(int id)
        {
            return driverManagementService.GetById(id);
        }

        public TripDTO GetTripById(int id)
        {
            return tripManagementService.GetById(id);
        }

        public List<DriverDTO> GetDriversBySearch(string Search)
        {
            return driverManagementService.Get(Search); 
        }

        public List<TravellerDTO> GetTravellerBySearch(string Search)
        {
            return travellerManagementService.Get(Search);
        }

        public List<TripDTO> GetTripsBySearch(string Search)
        {
            return tripManagementService.Get(Search);
        }

        public string PutTraveller(TravellerDTO travellerDTOs)
        {
            if (!travellerManagementService.Edit(travellerDTOs))
            {
                return "Traveller is not updated!";
            }
            else
            {
                return "Traveller successfully updated!";
            }
        }

        public string PutTrip(TripDTO tripDTOs)
        {
            if (!tripManagementService.Edit(tripDTOs))
            {
                return "Trip is not updated!";
            }
            else
            {
                return "Trip successfully updated!";
            }
        }
    }







}
