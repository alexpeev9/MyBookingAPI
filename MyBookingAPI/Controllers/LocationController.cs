using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataAccess.RepositoryWrapper;
using DataStructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBookingAPI.Controllers
{
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
        public IActionResult CreateOwner(Location location)
        {
            _repository.Location.CreateLocation(location);
            _repository.Save();
            return CreatedAtRoute("LocationById", new { location.ID }, location);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateLocation(int id)
        {
            var location = _repository.Location.GetLocationById(id);
            _repository.Location.UpdateLocation(location);
            _repository.Save();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(int id)
        {
           var location = _repository.Location.GetLocationById(id);
           _repository.Location.DeleteLocation(location);
           _repository.Save();
           return NoContent();  
        }
    }
}