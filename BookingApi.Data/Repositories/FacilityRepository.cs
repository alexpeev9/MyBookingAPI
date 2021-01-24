namespace BookingApi.Data.Repositories
{
    using BookingApi.Data.Repositories.Interfaces;
    using BookingAPI.Models.DtoModels.FacilityDto;
    using BookingAPI.Models.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class FacilityRepository : IFacilityRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public FacilityRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<FacilityModel> GetAll => _appDbContext.Facilities
                .Include(x => x.HotelFacilities)
                .ThenInclude(x => x.Hotel)
                .Select(x => new FacilityModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Info = x.Info,
                    Hotels = x.HotelFacilities.Select(z => z.Hotel.Name).ToList(),
                }).ToList();
        public FacilityModel GetById(int id) => _appDbContext.Facilities
                .Include(x => x.HotelFacilities)
                .ThenInclude(x => x.Hotel)
                .Select(x => new FacilityModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Info = x.Info,
                    Hotels = x.HotelFacilities.Select(z => z.Hotel.Name).ToList()
                }).Where(x => x.Id == id).SingleOrDefault();
        public DbSet<Facility> Facilities => _appDbContext.Facilities;
        public void Save() => _appDbContext.SaveChanges();
    }
}
