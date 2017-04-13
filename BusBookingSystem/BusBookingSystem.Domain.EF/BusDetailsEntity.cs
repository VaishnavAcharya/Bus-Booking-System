namespace BusBookingSystem.Domain.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using BusBookingSystem.Domain.Models; 

    public partial class BusDetailsEntity : DbContext
    {
        public BusDetailsEntity()
            : base("name=BusDetailsEntity")
        {
        }
        public DbSet<BusType> BusTypes { get; set; }
        public DbSet<BusCompanyName> BusCompanyNames { get; set; }
        public DbSet<BusDetails> BusDetails { get; set; }
        public DbSet<Location> Locations { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
