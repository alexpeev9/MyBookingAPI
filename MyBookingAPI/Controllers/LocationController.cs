namespace MyBookingAPI.Controllers
{
    using AutoMapper;
    using DataAccess.Interfaces;
    using DataAccess.RepositoryWrapper;
    using DataStructure.DtoModels;
    using DataStructure.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILocationRepository _repositorylocation;
        private readonly IMapper _mapper;
        public LocationController(IRepositoryWrapper repository, ILocationRepository locationRepository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "LocationById")]
        public IActionResult GetLocationById(int id)
        {
                var location = _repository.Location.GetLocationById(id);
                var locationResult = _mapper.Map<LocationDto>(location);
                return Ok(locationResult);
        }

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            var locations = _repository.Location.GetAllLocations();
            var locationResult = _mapper.Map <IEnumerable<LocationDto>>(locations);
            return Ok(locationResult);
        }
        [HttpPost]
        public IActionResult CreateLocation([FromBody]LocationForCreationDto location)
        {
            var locationEntity = _mapper.Map<Location>(location);
            _repository.Location.CreateLocation(locationEntity);
            _repository.Save();
            var createdLocation = _mapper.Map<LocationDto>(locationEntity);
            return CreatedAtRoute("LocationById", new { id = createdLocation.ID }, createdLocation);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateLocation(int id, [FromBody]LocationForUpdateDto location)
        {
           
            var locationEntity = _repository.Location.GetLocationById(id);
            location.ID = locationEntity.ID;
            _mapper.Map(location, locationEntity);
            _repository.Location.UpdateLocation(locationEntity);
            _repository.Save();
            return Ok(location);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation (int id)
        {
           var location = _repository.Location.GetLocationById(id);
           _repository.Location.DeleteLocation(location);
           _repository.Save();
           return NoContent();  
        }
    }
}