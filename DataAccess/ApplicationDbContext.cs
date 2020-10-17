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
        public DbSet<Amenitie> Amenities { get; set; }
        public DbSet<GuestHouseAmenitie> GuestHouseAmenities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=BookingDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // many to many for GuestHouse and Amenitie
            modelBuilder.Entity<GuestHouseAmenitie>()
                .HasKey(t => new { t.GuestHouseId, t.AmenitieId });

            modelBuilder.Entity<GuestHouseAmenitie>()
                .HasOne(pt => pt.GuestHouse)
                .WithMany(p => p.GuestHouseAmenities)
                .HasForeignKey(pt => pt.GuestHouseId);

            modelBuilder.Entity<GuestHouseAmenitie>()
                .HasOne(pt => pt.Amenitie)
                .WithMany(t => t.GuestHouseAmenities)
                .HasForeignKey(pt => pt.AmenitieId);
        }
    }
}