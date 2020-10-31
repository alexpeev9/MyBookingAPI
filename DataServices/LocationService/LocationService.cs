namespace DataServices.LocationService
{
    using AutoMapper;
    using DataAccess.Interfaces;
    using DataAccess.RepositoryWrapper;
    using DataStructure.DtoModels;
    using DataStructure.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class LocationService : ILocationService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        public LocationService(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<Location> GetAllLocations()
        {
            return _repository.Location.GetAllLocations();
        }

        public Location GetLocationById(int ID)
        {
            return _repository.Location.GetLocationById(ID);
        }
        public LocationDto CreateLocation([FromBody]LocationForCreationDto location)
        {
            var locationEntity = _mapper.Map<Location>(location);
            _repository.Location.CreateLocation(locationEntity);
            _repository.Save();
            var createdLocation = _mapper.Map<LocationDto>(locationEntity);
            return createdLocation;
        }
        public LocationForUpdateDto UpdateLocation(int ID,[FromBody]LocationForUpdateDto location)
        {
            var locationEntity = _repository.Location.GetLocationById(ID);
            location.ID = locationEntity.ID;
            _mapper.Map(location, locationEntity);
            _repository.Location.UpdateLocation(locationEntity);
            _repository.Save();
            return location;
        }
        public void DeleteLocation(int ID)
        {
          var location = _repository.Location.GetLocationById(ID);
          _repository.Location.DeleteLocation(location);
          _repository.Save();
        }
    }
}