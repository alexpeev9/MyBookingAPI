using BookingApi.Data;
using BookingApi.Data.Exceptions;
using BookingAPI.Models.DtoModels.FacilityDto;
using BookingAPI.Models.Models;
using BookingAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingAPI.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly ApplicationDbContext _appDbContext;


        public FacilityService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<FacilityModel> GetAll()
        {
                var facilities = _appDbContext.Facilities
                    .Include(x => x.HotelFacilities)
                    .ThenInclude(x => x.Hotel)
                    .Select(x => new FacilityModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Info = x.Info,
                        Hotels = x.HotelFacilities.Select(z => z.Hotel.Name).ToList(),
                    }).ToList();

                return facilities;
        }

        public FacilityModel GetById(int id)
        {
            var facilities = _appDbContext.Facilities
                .Include(x => x.HotelFacilities)
                .ThenInclude(x => x.Hotel)
                .Select(x => new FacilityModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Info = x.Info,
                    Hotels = x.HotelFacilities.Select(z => z.Hotel.Name).ToList()
                }).Where( x => x.Id == id).SingleOrDefault();

            return facilities;
        }
        
        public Facility Create(Facility facility)
        {
            var facilities = _appDbContext.Facilities
                .Include(x => x.HotelFacilities)
                .ThenInclude(x => x.Hotel)
                .Select(x => new FacilityCreateModel()
                {
                    Name = x.Name,
                    Info = x.Info,
                }).Where(x => x.Name == facility.Name).SingleOrDefault();
            _appDbContext.Facilities.Add(facility);
            _appDbContext.SaveChanges();
            return facility;
        }

        public void Update(Facility facilityParm)
        {
            var facility = _appDbContext.Facilities.Find(facilityParm.Id);
            facility.Name = facilityParm.Name;
            facility.Info = facilityParm.Info;
            _appDbContext.Facilities.Update(facility);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var facility = _appDbContext.Facilities.Find(id);
            if (facility != null)
            {
                _appDbContext.Facilities.Remove(facility);
                _appDbContext.SaveChanges();
            }
        }
    }
}
