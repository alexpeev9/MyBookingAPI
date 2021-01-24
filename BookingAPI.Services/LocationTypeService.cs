namespace BookingAPI.Services
{
    using BookingApi.Data.Exceptions;
    using BookingApi.Data.Repositories.Interfaces;
    using BookingAPI.Models.DtoModels.LocationTypeDto;
    using BookingAPI.Models.Models;
    using BookingAPI.Services.Interfaces;
    using System.Collections.Generic;

    public class LocationTypeService : ILocationTypeService
    {
        private readonly ILocationTypeRepository _locationTypeRepository;

        public LocationTypeService( ILocationTypeRepository locationTypeRepository )
        {
            _locationTypeRepository = locationTypeRepository;
        }
        public List<LocationTypeModel> GetAll() => _locationTypeRepository.GetAllLocations;

        public LocationTypeModel GetById(int Id) => _locationTypeRepository.GetLocationById(Id);
        public LocationType Create(LocationType location)
        {
            if (string.IsNullOrWhiteSpace(location.Name))
                throw new AppException("Name is required");

            if (string.IsNullOrWhiteSpace(location.Info))
                throw new AppException("Info is required");

                _locationTypeRepository.Locations.Add(location);
                _locationTypeRepository.Save();
                return location;
        }
        public void Update(LocationType locationParam)
        {
            var location = _locationTypeRepository.Locations.Find(locationParam.Id);
            if (!string.IsNullOrWhiteSpace(locationParam.Name))
                location.Name = locationParam.Name;

            if (!string.IsNullOrWhiteSpace(locationParam.Info))
                location.Info = locationParam.Info;

            _locationTypeRepository.Locations.Update(location);
            _locationTypeRepository.Save();
        }
        public void Delete(int ID)
        {
            var locationType = _locationTypeRepository.Locations.Find(ID);
            if (locationType == null)
                throw new AppException("This Id doesn't exist");

                _locationTypeRepository.Locations.Remove(locationType);
                _locationTypeRepository.Save();

        }
    }
}