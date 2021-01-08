namespace BookingAPI.Services
{
    using BookingApi.Data;
    using BookingAPI.Models.Models;
    using BookingAPI.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class HotelFacilityService : IHotelFacilityService
    {
        private readonly ApplicationDbContext _appDbContext;
        public HotelFacilityService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<HotelFacility> GetAll()
        {
            var facilities = _appDbContext.HotelFacilities.ToList();
            return facilities;
        }
        public HotelFacility Create(HotelFacility hotelfacility)
        {
            _appDbContext.HotelFacilities.Add(hotelfacility);
            _appDbContext.SaveChanges();
            return hotelfacility;
        }
        public void Delete(int hotelId,int facilityId)
        {
            var hotelFacility = _appDbContext.HotelFacilities.Where(x=>x.HotelId == hotelId && x.FacilityId == facilityId).SingleOrDefault();

            if (hotelFacility != null)
            {
                _appDbContext.HotelFacilities.Remove(hotelFacility);
                _appDbContext.SaveChanges();
            }
        }
    }
}
