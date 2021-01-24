namespace BookingAPI.Controllers
{
    using AutoMapper;
    using BookingApi.Data.Exceptions;
    using BookingAPI.Models.DtoModels.HotelFacilityDto;
    using BookingAPI.Models.Models;
    using BookingAPI.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [ApiController]
    [Route("[controller]")]
    public class HotelFacilitiesController : ControllerBase
    {
        private readonly IHotelFacilityService _hotelFacilityService;
        private readonly IMapper _mapper;

        public HotelFacilitiesController(IHotelFacilityService hotelFacilityService, IMapper mapper)
        {
            _hotelFacilityService = hotelFacilityService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var hotelfacilities = _hotelFacilityService.GetAll();
            var model = _mapper.Map<IList<HotelFacilityModel>>(hotelfacilities);
            return Ok(model);
        }


        [Authorize]
        [HttpPost]
        public IActionResult CreateFacility([FromBody] HotelFacilityCreateModel model)
        {
            int currentUserId = int.Parse(User.Identity.Name);
            Hotel hotel = _hotelFacilityService.FindHotel(model.HotelId);

            if (currentUserId != hotel.User.Id && !User.IsInRole("Admin"))
                return Forbid();

            // map model to entity
            var hotelfacility = _mapper.Map<HotelFacility>(model);
         
            try
            {
                // create user
                _hotelFacilityService.Create(hotelfacility);
                return Ok($"You have created successfully mapped them. \n {hotelfacility.HotelId} -  {hotelfacility.FacilityId} ");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}/{hotelId}")]
        public IActionResult Delete(int id,int hotelId)
        {
            int currentUserId = int.Parse(User.Identity.Name);
            Hotel hotelfacility = _hotelFacilityService.FindHotel(hotelId);

            if (currentUserId != hotelfacility.User.Id && !User.IsInRole("Admin"))
                return Forbid();

            _hotelFacilityService.Delete(id, hotelId);
            return Ok();
        }
    }
}
