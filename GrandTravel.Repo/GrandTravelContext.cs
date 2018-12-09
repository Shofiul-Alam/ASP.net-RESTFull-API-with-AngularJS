using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTravel.Entity;

namespace GrandTravel.Repo
{
    internal class GrandTravelContext : DbContext
    {

        //This line isnt used anywhere, its just used to trick the .net compiler into including the
        //EntityFramework.SqlServer dll into the web project, as now the compiler can detect a reference to that dll
        //and will include it in the bin directory, if you dont include this, an error will occur
        // this also allows us to not have to reference EntityFramework in our web project
        System.Data.Entity.SqlServer.Utilities.TaskExtensions.CultureAwaiter _fakeVariable;
        public GrandTravelContext() : base("GrandTravelDBConnectionString")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<TravelProvider> TravelProviders { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLineItem> OrderLineItems { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<PackagesPhotoGallery> packagesPhotoGallery { get; set; }


    }

}
