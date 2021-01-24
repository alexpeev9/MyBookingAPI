namespace BookingApi.Data.Repositories.Interfaces
{
    using BookingAPI.Models.DtoModels.HotelFacilityDto;
    using BookingAPI.Models.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    public interface IHotelFacilityRepository
    {
        List<HotelFacilityModel> GetAll { get; }
        DbSet<HotelFacility> HotelFacilities { get; }
        Hotel FindHotel(int id);
        Facility FindFacility(int id);
        User FindUser(int id);
        HotelFacility FindHotelFacility(int hotelId, int facilityId);
        Hotel FindHotelFacilityForUser(int userId);
        void Save();
    }
}
