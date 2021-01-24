namespace BookingApi.Data.Repositories
{
    using BookingApi.Data.Repositories.Interfaces;
    using BookingAPI.Models.DtoModels.FacilityDto;
    using BookingAPI.Models.DtoModels.HotelFacilityDto;
    using BookingAPI.Models.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    public class HotelFacilityRepository : IHotelFacilityRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public HotelFacilityRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<HotelFacilityModel> GetAll => _appDbContext.HotelFacilities
               .Include(x => x.Facility)
               .Include(x => x.Hotel)
               .ThenInclude(x => x.User)
               .Select(x => new HotelFacilityModel()
               {
                   HotelId = x.HotelId,
                   Hotel = x.Hotel.Name,
                   User = x.Hotel.User.Username,
                   FacilityId = x.FacilityId,
                   Facility = x.Facility.Name,
               }).ToList();
        public DbSet<HotelFacility> HotelFacilities => _appDbContext.HotelFacilities;
        public Hotel FindHotel(int id) => _appDbContext.Hotels.Include(x=>x.User).SingleOrDefault(x => x.Id == id);
        public Facility FindFacility(int id) => _appDbContext.Facilities.SingleOrDefault(x => x.Id == id);
        public User FindUser(int id) => _appDbContext.Users.SingleOrDefault(x => x.Id == id);
        public HotelFacility FindHotelFacility(int facilityId, int hotelId) => _appDbContext.HotelFacilities.Where(x => x.HotelId == hotelId && x.FacilityId == facilityId).SingleOrDefault();
        public Hotel FindHotelFacilityForUser(int userId) => _appDbContext.Hotels.Include(x => x.User)
                                                             .SingleOrDefault(x => x.User.Id == userId);
        public void Save() => _appDbContext.SaveChanges();
    }
}
