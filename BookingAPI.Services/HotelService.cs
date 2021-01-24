namespace BookingAPI.Services
{
    using BookingApi.Data;
    using BookingApi.Data.Exceptions;
    using BookingApi.Data.Repositories.Interfaces;
    using BookingAPI.Models.DtoModels.HotelDto;
    using BookingAPI.Models.Models;
    using BookingAPI.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public List<HotelModel> GetAll() => _hotelRepository.GetAll;
        public HotelModel GetById(int id) => _hotelRepository.GetById(id);
        public Hotel Create(Hotel hotel, int userId)
        {

            if (string.IsNullOrWhiteSpace(hotel.Name))
                throw new AppException("Name is required");

            if (string.IsNullOrWhiteSpace(hotel.Info))
                throw new AppException("Info is required");

            if (string.IsNullOrWhiteSpace(hotel.Address))
                throw new AppException("Name is required");

            if (hotel.PricePerNight == 0m)
                throw new AppException("Price is required");

            if (hotel.LocationTypeId == 0)
                throw new AppException("LocationTypeId is required");

            hotel.User = _hotelRepository.FindUser(userId);
            hotel.LocationType = _hotelRepository.FindLocation(hotel.Id);

            _hotelRepository.Hotels.Add(hotel);
            _hotelRepository.Save();
            return hotel;
        }

        public void Update(Hotel hotelParam)
        {
            var hotel = _hotelRepository.Hotels
                                              .Include(x => x.LocationType)
                                              .Where(x => x.Id == hotelParam.Id).SingleOrDefault();

            if (!string.IsNullOrWhiteSpace(hotelParam.Name))
                hotel.Name = hotelParam.Name;

            if (!string.IsNullOrWhiteSpace(hotelParam.Info))
                hotel.Info = hotel.Info;

            if (hotelParam.PricePerNight == 0m)
                hotel.PricePerNight = hotel.PricePerNight;

            if (!string.IsNullOrWhiteSpace(hotelParam.Address))
                hotel.Address = hotelParam.Address;

            if (hotelParam.LocationTypeId != 0)
                hotel.LocationTypeId = hotelParam.LocationTypeId;

            _hotelRepository.Hotels.Update(hotel);
            _hotelRepository.Save();
        }

        public void Delete(int id)
        {
            var hotel = _hotelRepository.Hotels.Find(id);

            if (hotel != null)
            {
                _hotelRepository.Hotels.Remove(hotel);
                _hotelRepository.Save();
            }
        }
        public Hotel FindHotel(int id) => _hotelRepository.Hotels.Include(x => x.User).SingleOrDefault(x => x.Id == id);
    }
}
