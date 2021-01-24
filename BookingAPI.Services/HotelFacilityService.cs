namespace BookingAPI.Services
{
    using BookingApi.Data;
    using BookingApi.Data.Exceptions;
    using BookingApi.Data.Repositories.Interfaces;
    using BookingAPI.Models.DtoModels.HotelFacilityDto;
    using BookingAPI.Models.Models;
    using BookingAPI.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class HotelFacilityService : IHotelFacilityService
    {
        private readonly IHotelFacilityRepository _hotelFacilityRepository;
        public HotelFacilityService(IHotelFacilityRepository hotelFacilityRepository)
        {
            _hotelFacilityRepository = hotelFacilityRepository;
        }
        public List<HotelFacilityModel> GetAll() => _hotelFacilityRepository.GetAll;

        public HotelFacility Create(HotelFacility hotelfacility)
        {
            if (hotelfacility.HotelId == 0)
                throw new AppException("HotelId is required");

            if (hotelfacility.FacilityId == 0)
                throw new AppException("FacilityId is required");

            Hotel hotelChecker = _hotelFacilityRepository.FindHotel(hotelfacility.HotelId);
            Facility facilityChecker = _hotelFacilityRepository.FindFacility(hotelfacility.FacilityId);
            
            if (hotelChecker == null)
                throw new AppException("Hotel is not Existing! Add existing HotelId");

            if (facilityChecker == null)
                throw new AppException("Facility is not Existing! Add existing FacilityId");

            _hotelFacilityRepository.HotelFacilities.Add(hotelfacility);
            _hotelFacilityRepository.Save();
            return hotelfacility;
        }
        public void Delete(int hotelId,int facilityId)
        {
            HotelFacility hotelFacility = _hotelFacilityRepository.FindHotelFacility(hotelId, facilityId);

            if (hotelFacility != null)
            {
                _hotelFacilityRepository.HotelFacilities.Remove(hotelFacility);
                _hotelFacilityRepository.Save();
            }
        }
        public User FindUser(int id) => _hotelFacilityRepository.FindUser(id);
        public Hotel FindHotel(int id) => _hotelFacilityRepository.FindHotel(id);
        public Hotel FindHotelFacilityForUser(int userId) => _hotelFacilityRepository.FindHotelFacilityForUser(userId);

    }
}
