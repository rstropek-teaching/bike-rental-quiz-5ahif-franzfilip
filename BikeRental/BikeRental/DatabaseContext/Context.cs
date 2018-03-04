using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BikeRental.Model.Model;

namespace BikeRental.DatabaseContext
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=tcp:posecsharphomeworkserver.database.windows.net,1433;" +
                "Initial Catalog=homeworkdatabase;" +
                "Persist Security Info=False;" +
                "User ID=Dejavu;" +
                "Password=Passwort123;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;" +
            "");
            
        }
    }
}
