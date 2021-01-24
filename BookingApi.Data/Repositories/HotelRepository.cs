namespace BookingApi.Data.Repositories
{
    using BookingApi.Data.Repositories.Interfaces;
    using BookingAPI.Models.DtoModels.HotelDto;
    using BookingAPI.Models.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public HotelRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<HotelModel> GetAll => _appDbContext.Hotels
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

        public HotelModel GetById(int id) => _appDbContext.Hotels
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
        public DbSet<Hotel> Hotels => _appDbContext.Hotels;
        public User FindUser(int id) => _appDbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        public LocationType FindLocation(int id) => _appDbContext.LocationTypes.Where(x => x.Id == id).FirstOrDefault();
        public void Save() => _appDbContext.SaveChanges();
    }
}
