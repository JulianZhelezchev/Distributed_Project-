using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    
    
        public class UnitOfWork : IDisposable
        {
            private SharedTripSystemDBContext context = new SharedTripSystemDBContext();
            private GenericRepository<Driver> driverRepository;
            private GenericRepository<Traveller> travellerRepository;
            private GenericRepository<Trip> tripRepository;


            public GenericRepository<Driver> DriverRepository
            {
                get
                {

                    if (this.driverRepository == null)
                    {
                        this.driverRepository = new GenericRepository<Driver>(context);
                    }
                    return driverRepository;
                }
            }

            public GenericRepository<Traveller> TravellerRepository
            {
                get
                {

                    if (this.travellerRepository == null)
                    {
                        this.travellerRepository = new GenericRepository<Traveller>(context);
                    }
                    return travellerRepository;
                }
            }
            public GenericRepository<Trip> TripRepository
            {
                get
                {

                    if (this.tripRepository == null)
                    {
                        this.tripRepository = new GenericRepository<Trip>(context);
                    }
                    return tripRepository;
                }
            }

            public void Save()
            {
                context.SaveChanges();
            }

            private bool disposed = false;

            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        context.Dispose();
                    }
                }
                this.disposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }


