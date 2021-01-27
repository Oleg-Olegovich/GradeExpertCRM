﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GradeExpertCRM.Models.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Calculation> Calculations { get; set; }
        public DbSet<DismantlingWork> DismantlingWorks { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }

        public AppDbContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            //Task.Run(async () => await Database.EnsureDeletedAsync());
            Task.Run(async () => await Database.EnsureCreatedAsync());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(App.ConnectionString);
        }
    }
}
