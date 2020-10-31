namespace MyBookingAPI.Controllers
{
    using AutoMapper;
    using DataAccess.Interfaces;
    using DataAccess.RepositoryWrapper;
    using DataServices.LocationService;
    using DataStructure.DtoModels;
    using DataStructure.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "LocationById")]
        public IActionResult GetLocationById(int id)
        {
            var locations =  _locationService.GetLocationById(id);
            return Ok(locations);
        }      

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            var locations =  _locationService.GetAllLocations();
            return Ok(locations);
        }

        [HttpPost]
        public IActionResult CreateLocation([FromBody]LocationForCreationDto location)
        {
            var createdLocation =_locationService.CreateLocation(location);
            return CreatedAtRoute("LocationById", new { id = createdLocation.ID }, createdLocation);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateLocation(int id,[FromBody]LocationForUpdateDto location)
        {
            var updatedLocation = _locationService.UpdateLocation(id, location);
            return Ok(updatedLocation);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation (int id)
        {
           _locationService.DeleteLocation(id);
           return NoContent();  
        }
    }
}