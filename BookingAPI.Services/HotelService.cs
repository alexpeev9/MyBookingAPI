namespace BookingAPI.Services
{
    using BookingApi.Data;
    using BookingAPI.Models.DtoModels.HotelDto;
    using BookingAPI.Models.Models;
    using BookingAPI.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    public class HotelService : IHotelService
    {
        private readonly ApplicationDbContext _appDbContext;
        public HotelService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<HotelModel> GetAll()
        {
            var facilities = _appDbContext.Hotels
                .Include(x => x.User)
                .Include(x => x.LocationType)
                .Include(x => x.HotelFacilities)
                .ThenInclude(x => x.Facility)
                .Select(x => new HotelModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    PricePerNight = x.PricePerNight,
                    User = x.User,
                    LocationType = x.LocationType,
                    Facilities = x.HotelFacilities.Select(z => z.Facility.Name).ToList(),
                }).ToList();

            return facilities;
        }
        public HotelModel GetById(int id)
        {
            var facilities = _appDbContext.Hotels
                .Include(x => x.HotelFacilities)
                .ThenInclude(x => x.Hotel)
                .Select(x => new HotelModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    PricePerNight = x.PricePerNight,
                    User = x.User,
                    LocationType = x.LocationType,
                    Facilities = x.HotelFacilities.Select(z => z.Facility.Name).ToList()
                }).Where(x => x.Id == id).SingleOrDefault();

            return facilities;
        }
        public Hotel Create(Hotel hotel, int userId)
        {
            var user = _appDbContext.Users.Where(x => x.Id == userId).FirstOrDefault();
            hotel.User = user;
            hotel.LocationType = _appDbContext.LocationTypes.Where(x => x.Id == hotel.LocationTypeId).FirstOrDefault();

            var facilities = _appDbContext.Hotels
                                                .Include(x => x.LocationType)
                                                .ThenInclude( x => x.Hotels)
                                                .Include(x => x.HotelFacilities)
                                                .ThenInclude(x => x.Hotel)
                                                .Where(x => x.Name == hotel.Name).SingleOrDefault();

            _appDbContext.Hotels.Add(hotel);
            _appDbContext.SaveChanges();
            return hotel;
        }

        public void Update(Hotel hotelParam)
        {
            var hotel = _appDbContext.Hotels.Find(hotelParam.Id);
            
            // za vsqko edno
            hotel.Name = hotelParam.Name;
            hotel.Info = hotel.Info;
            hotel.PricePerNight = hotel.PricePerNight;
            hotel.Address = hotelParam.Address;
            hotel.LocationTypeId = hotelParam.LocationTypeId;

            _appDbContext.Hotels.Update(hotel);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var hotel = _appDbContext.Hotels.Find(id);

            if (hotel != null)
            {
                _appDbContext.Hotels.Remove(hotel);
                _appDbContext.SaveChanges();
            }
        }
    }
}
