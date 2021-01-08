namespace BookingAPI.Controllers
{
    using AutoMapper;
    using BookingApi.Data;
    using BookingApi.Data.Exceptions;
    using BookingAPI.Models.DtoModels.HotelFacilityDto;
    using BookingAPI.Models.Models;
    using BookingAPI.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    [ApiController]
    [Route("[controller]")]
    public class HotelFacilityController : ControllerBase
    {
        private readonly IHotelFacilityService _hotelFacilityService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _appDbContext;

        public HotelFacilityController(IHotelFacilityService hotelFacilityService, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _hotelFacilityService = hotelFacilityService;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var hotelfacilities = _hotelFacilityService.GetAll();
            var model = _mapper.Map<IList<HotelFacility>>(hotelfacilities);
            return Ok(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateFacility([FromBody] HotelFacilityCreateModel model)
        {
            var currentUser = User.Identity;
            var currentUserId = int.Parse(User.Identity.Name);
            var currentUserDb = _appDbContext.Users.FirstOrDefault(x => x.Id == currentUserId);
            var hotelfacilityCheck = _appDbContext.HotelFacilities.Include(x => x.Hotel)
                                                             .ThenInclude(x => x.User)
                                                             .FirstOrDefault(x => x.Hotel.User == currentUserDb);

            if (currentUser != hotelfacilityCheck.Hotel.User && !User.IsInRole("Admin"))
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
            var currentUserId = int.Parse(User.Identity.Name);
            var hotelfacility = _appDbContext.HotelFacilities.Include(x => x.Hotel)
                                                             .ThenInclude(x=>x.User)
                                                             .FirstOrDefault(x => x.Hotel.User.Id == currentUserId);

            if (currentUserId != hotelfacility.Hotel.User.Id && !User.IsInRole("Admin"))
                return Forbid();

            _hotelFacilityService.Delete(id, hotelId);
            return Ok();
        }
    }
}
