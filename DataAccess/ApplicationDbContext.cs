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
        public DbSet<Type> Types { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<NearbyAttraction> NearbyAttractions { get; set; }
        public DbSet<GuestHouseFacility> GuestHouseFacilities { get; set; }
        public DbSet<GuestHouseNearbyAttraction> GuestHouseNearbyAttractions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Many to Many for GuestHouse and Facility
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

            //  Many to Many for GuestHouse and NearbyAttraction
            modelBuilder.Entity<GuestHouseNearbyAttraction>()
              .HasKey(t => new { t.GuestHouseId, t.NearbyAttractionId });

            modelBuilder.Entity<GuestHouseNearbyAttraction>()
                .HasOne(pt => pt.GuestHouse)
                .WithMany(p => p.GuestHouseNearbyAttraction)
                .HasForeignKey(pt => pt.GuestHouseId);

            modelBuilder.Entity<GuestHouseNearbyAttraction>()
                .HasOne(pt => pt.NearbyAttraction)
                .WithMany(t => t.GuestHouseNearbyAttraction)
                .HasForeignKey(pt => pt.NearbyAttractionId);
        }
    }
}