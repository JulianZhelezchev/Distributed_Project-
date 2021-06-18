using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
  public  class SharedTripSystemDBContext : DbContext
    {
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}
