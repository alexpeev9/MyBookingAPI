namespace BookingAPI.Controllers
{
    using AutoMapper;
    using BookingApi.Data;
    using BookingApi.Data.Exceptions;
    using BookingAPI.Models.DtoModels.HotelDto;
    using BookingAPI.Models.Models;
    using BookingAPI.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelsController(IHotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var hotels = _hotelService.GetAll();
            var model = _mapper.Map<IList<HotelModel>>(hotels);
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var hotels = _hotelService.GetById(id);
            var model = _mapper.Map<HotelModel>(hotels);
            return Ok(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateHotel([FromBody] HotelCreateModel model)
        {
            // map model to entity
            var hotel = _mapper.Map<Hotel>(model);
            var currentUserId = int.Parse(User.Identity.Name);

            try
            {
                // create user
                _hotelService.Create(hotel, currentUserId);
                return Ok($"You have created successfully a hotel. \n Name: {hotel.Name} ");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] HotelUpdateModel model)
        {
            var hotelChecker = _hotelService.FindHotel(id);
            var currentUserId = int.Parse(User.Identity.Name);
            if (currentUserId != hotelChecker.User.Id && !User.IsInRole("Admin"))
                return Forbid();

            var hotel = _mapper.Map<Hotel>(model);
            hotel.Id = id;
            try
            {
                // update facility 
                _hotelService.Update(hotel);
                return Ok("Successfully updated");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hotel = _hotelService.FindHotel(id);
            var currentUserId = int.Parse(User.Identity.Name);
            if (currentUserId != hotel.User.Id && !User.IsInRole("Admin"))
                return Forbid();

            _hotelService.Delete(id);
            return Ok();
        }
    }
}
