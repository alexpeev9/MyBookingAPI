namespace BookingAPI.Controllers
{
    using AutoMapper;
    using BookingApi.Data.Exceptions;
    using BookingAPI.Models.DtoModels.FacilityDto;
    using BookingAPI.Models.Models;
    using BookingAPI.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [ApiController]
    [Route("[controller]")]
    public class FacilitiesController : ControllerBase
    {
        private readonly IFacilityService _facilityService;
        private readonly IMapper _mapper;

        public FacilitiesController(IFacilityService facilityService, IMapper mapper)
        {
            _facilityService = facilityService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var facilities = _facilityService.GetAll();
            var model = _mapper.Map<IList<FacilityModel>>(facilities);
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var facility = _facilityService.GetById(id);
            var model = _mapper.Map<FacilityModel>(facility);
            return Ok(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateFacility([FromBody] FacilityCreateModel model)
        {
            // map model to entity
            var facility = _mapper.Map<Facility>(model);

            try
            {
                // create user
                _facilityService.Create(facility);
                return Ok($"You have created successfully a facility. \n Name: {facility.Name} \n Info: {facility.Info} ");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] FacilityUpdateModel model)
        {
            var facility = _mapper.Map<Facility>(model);
            facility.Id = id;

            try
            {
                // update facility 
                _facilityService.Update(facility);
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
            _facilityService.Delete(id);
            return Ok();
        }
    }
}