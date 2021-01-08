namespace BookingAPI.Controllers
{
    using AutoMapper;
    using BookingApi.Data.Exceptions;
    using BookingAPI.Models.DtoModels.LocationTypeDto;
    using BookingAPI.Models.Models;
    using BookingAPI.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [ApiController]
    [Route("[controller]")]
    public class LocationTypeController : ControllerBase
    {
        private readonly ILocationTypeService _locationTypeService;
        private readonly IMapper _mapper;
        
        public LocationTypeController(ILocationTypeService locationTypeService, IMapper mapper)
        {
            _locationTypeService = locationTypeService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var locations = _locationTypeService.GetAll();
            var model = _mapper.Map<IList<LocationTypeModel>>(locations);
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var locationType = _locationTypeService.GetById(id);
            var model = _mapper.Map<LocationTypeModel>(locationType);
            return Ok(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateFacility([FromBody] LocationTypeCreateModel model)
        {
            // map model to entity
            var locationType = _mapper.Map<LocationType>(model);

            try
            {
                // create user
                _locationTypeService.Create(locationType);
                return Ok($"You have created successfully a facility. \n Name: {locationType.Name} \n Info: {locationType.Info} \n {locationType}");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LocationTypeUpdateModel model)
        {
            var locationType = _mapper.Map<LocationType>(model);
            locationType.Id = id;

            try
            {
                // update facility 
                _locationTypeService.Update(locationType);
                return Ok("Successfully updated");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _locationTypeService.Delete(id);
            return Ok();
        }
    }
}