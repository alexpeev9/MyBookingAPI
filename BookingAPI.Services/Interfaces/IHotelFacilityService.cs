namespace BookingAPI.Services.Interfaces
{
    using BookingAPI.Models.Models;
    using System.Collections.Generic;
    public interface IHotelFacilityService
    {
        List<HotelFacility> GetAll();
        HotelFacility Create(HotelFacility hotel);
        void Delete(int hotelId, int facilityId);
    }
}
