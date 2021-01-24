using BookingApi.Data;
using BookingApi.Data.Exceptions;
using BookingApi.Data.Repositories.Interfaces;
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
        private readonly IFacilityRepository _facilityRepository;

        public FacilityService(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public List<FacilityModel> GetAll() => _facilityRepository.GetAll;

        public FacilityModel GetById(int id) => _facilityRepository.GetById(id);
        
        public Facility Create(Facility facility)
        {
            if (string.IsNullOrWhiteSpace(facility.Name))
                throw new AppException("Name is required");

            if (string.IsNullOrWhiteSpace(facility.Info))
                throw new AppException("Info is required");

            var facilities = _facilityRepository.Facilities
                .Include(x => x.HotelFacilities)
                .ThenInclude(x => x.Hotel)
                .Select(x => new FacilityCreateModel()
                {
                    Name = x.Name,
                    Info = x.Info,
                }).Where(x => x.Name == facility.Name).SingleOrDefault();
            _facilityRepository.Facilities.Add(facility);
            _facilityRepository.Save();
            return facility;
        }

        public void Update(Facility facilityParm)
        {
            var facility = _facilityRepository.Facilities.Find(facilityParm.Id);

            if (!string.IsNullOrWhiteSpace(facilityParm.Name))
                facility.Name = facilityParm.Name;

            if (!string.IsNullOrWhiteSpace(facilityParm.Info))
                facility.Info = facilityParm.Info;

            _facilityRepository.Facilities.Update(facility);
            _facilityRepository.Save();
        }

        public void Delete(int id)
        {
            var facility = _facilityRepository.Facilities.Find(id);
            if (facility != null)
            {
                _facilityRepository.Facilities.Remove(facility);
                _facilityRepository.Save();
            }
        }
    }
}
