namespace BookingAPI.Services.Interfaces
{
    using BookingAPI.Models.DtoModels.HotelFacilityDto;
    using BookingAPI.Models.Models;
    using System.Collections.Generic;
    public interface IHotelFacilityService
    {
        List<HotelFacilityModel> GetAll();
        HotelFacility Create(HotelFacility hotel);
        User FindUser(int id);
        Hotel FindHotel(int userId);
        Hotel FindHotelFacilityForUser(int userId);
        void Delete(int facilityId, int hotelId);
    }
}
