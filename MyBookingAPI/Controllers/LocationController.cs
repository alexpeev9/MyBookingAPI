namespace MyBookingAPI.Controllers
{
    using DataAccess.RepositoryWrapper;
    using DataStructure.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public LocationController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllLocations()
        {
                var locations = _repository.Location.GetAllLocations();
                return Ok(locations);
        }
        [HttpPost]
        public IActionResult CreateLocation(Location location)
        {
            _repository.Location.CreateLocation(location);
            _repository.Save();
            return CreatedAtRoute(new { location.ID }, location);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateLocation(int id, Location location)
        {
            var oldlocation = _repository.Location.GetLocationById(id);
            location.ID = oldlocation.ID;
            _repository.Location.DeleteLocation(oldlocation);
            _repository.Location.CreateLocation(location);
            _repository.Save();
            return NoContent();
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