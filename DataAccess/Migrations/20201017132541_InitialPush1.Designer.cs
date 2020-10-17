﻿// <auto-generated />
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201017132541_InitialPush1")]
    partial class InitialPush1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataStructure.Models.Amenitie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("DataStructure.Models.GuestHouse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsHot")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPremium")
                        .HasColumnType("bit");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LocationId");

                    b.ToTable("GuestHouses");
                });

            modelBuilder.Entity("DataStructure.Models.GuestHouseAmenitie", b =>
                {
                    b.Property<int>("GuestHouseId")
                        .HasColumnType("int");

                    b.Property<int>("AmenitieId")
                        .HasColumnType("int");

                    b.HasKey("GuestHouseId", "AmenitieId");

                    b.HasIndex("AmenitieId");

                    b.ToTable("GuestHouseAmenities");
                });

            modelBuilder.Entity("DataStructure.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DataStructure.Models.GuestHouse", b =>
                {
                    b.HasOne("DataStructure.Models.Location", "Location")
                        .WithMany("GuestHouses")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataStructure.Models.GuestHouseAmenitie", b =>
                {
                    b.HasOne("DataStructure.Models.Amenitie", "Amenitie")
                        .WithMany("GuestHouseAmenities")
                        .HasForeignKey("AmenitieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataStructure.Models.GuestHouse", "GuestHouse")
                        .WithMany("GuestHouseAmenities")
                        .HasForeignKey("GuestHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
