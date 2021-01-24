namespace BookingApi.Data.Repositories
{
    using BookingApi.Data.Repositories.Interfaces;
    using BookingAPI.Models.DtoModels.LocationTypeDto;
    using BookingAPI.Models.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class LocationTypeRepository : ILocationTypeRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public LocationTypeRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<LocationTypeModel> GetAllLocations => _appDbContext.LocationTypes.
            Select(x => new LocationTypeModel()
            {
                Id = x.Id,
                Name = x.Name,
                Info = x.Info,
                Hotels = x.Hotels.Select(z => z.Name).ToList(),
            }).ToList();

        public LocationTypeModel GetLocationById(int Id) => _appDbContext.LocationTypes
                .Include(x => x.Hotels)
                .Select(x => new LocationTypeModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Info = x.Info,
                    Hotels = x.Hotels.Select(z => z.Name).ToList(),
                }).Where(x => x.Id == Id).SingleOrDefault();
        public DbSet<LocationType> Locations => _appDbContext.LocationTypes;
        public void Save() => _appDbContext.SaveChanges();
    }
}
