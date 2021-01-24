using System;
using System.Collections.Generic;
using System.Text;

namespace BookingAPI.Models.DtoModels.HotelFacilityDto
{
    public class HotelFacilityModel
    {
        public int HotelId { get; set; }
        public string Hotel { get; set; }
        public string User { get; set; }
        public int FacilityId { get; set; }
        public string Facility { get; set; }
    }
}
