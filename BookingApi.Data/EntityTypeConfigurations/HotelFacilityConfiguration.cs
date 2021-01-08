namespace BookingApi.Data.EntityTypeConfigurations
{
    using BookingAPI.Models.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class HotelFacilityConfiguration : IEntityTypeConfiguration<HotelFacility>
    {
        public void Configure(EntityTypeBuilder<HotelFacility> builder)
        {
            builder.HasKey(tcm => new { tcm.HotelId, tcm.FacilityId });

            builder.HasOne(tcm => tcm.Facility)
                .WithMany(t => t.HotelFacilities)
                .HasForeignKey(tcm => tcm.FacilityId);

            builder.HasOne(tcm => tcm.Hotel)
                .WithMany(tc => tc.HotelFacilities)
                .HasForeignKey(tcm => tcm.HotelId);
        }
    }
}