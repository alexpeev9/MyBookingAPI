namespace DataAccess
{
    using DataStructure.Models;
    using Microsoft.EntityFrameworkCore;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<GuestHouse> GuestHouses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<GuestHouseFacility> GuestHouseFacilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // many to many for GuestHouse and Amenitie
            modelBuilder.Entity<GuestHouseFacility>()
                .HasKey(t => new { t.GuestHouseId, t.FacilityId });

            modelBuilder.Entity<GuestHouseFacility>()
                .HasOne(pt => pt.GuestHouse)
                .WithMany(p => p.GuestHouseFacility)
                .HasForeignKey(pt => pt.GuestHouseId);

            modelBuilder.Entity<GuestHouseFacility>()
                .HasOne(pt => pt.Facility)
                .WithMany(t => t.GuestHouseFacility)
                .HasForeignKey(pt => pt.FacilityId);
        }
    }
}