namespace BookingAPI.Services
{
    using BookingApi.Data;
    using BookingAPI.Models.DtoModels.LocationTypeDto;
    using BookingAPI.Models.Models;
    using BookingAPI.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class LocationTypeService : ILocationTypeService
    {
        private readonly ApplicationDbContext _appDbContext;

        public LocationTypeService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<LocationTypeModel> GetAll()
        {
            return _appDbContext.LocationTypes.Select(x => new LocationTypeModel()
            {
                Id = x.Id,
                Name = x.Name,
                Info = x.Info,
                Hotels = x.Hotels.Select(z => z.Name).ToList(),
            }).ToList();
        }

        public LocationTypeModel GetById(int Id)
        {
            return _appDbContext.LocationTypes
                .Include(x => x.Hotels)
                .Select(x => new LocationTypeModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Info = x.Info,
                    Hotels = x.Hotels.Select(z => z.Name).ToList(),
                }).Where( x=>x.Id == Id).SingleOrDefault();
        }
        public LocationType Create(LocationType location)
        {
                _appDbContext.LocationTypes.Add(location);
                _appDbContext.SaveChanges();
                return location;
        }
        public void Update(LocationType locationParam)
        {
            var location = _appDbContext.LocationTypes.Find(locationParam.Id);
            location.Name = locationParam.Name;
            location.Info = locationParam.Info;
            _appDbContext.LocationTypes.Update(location);
            _appDbContext.SaveChanges();          
        }
        public void Delete(int ID)
        {
            var locationType = _appDbContext.LocationTypes.Find(ID);
            if (locationType != null)
            {
                _appDbContext.LocationTypes.Remove(locationType);
                _appDbContext.SaveChanges();
            }
        }
    }
}