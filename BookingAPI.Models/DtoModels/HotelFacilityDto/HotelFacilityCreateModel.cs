namespace BookingAPI.Models.DtoModels.HotelFacilityDto
{
    using BookingAPI.Models.Models;
    using System.Text.Json.Serialization;
    public class HotelFacilityCreateModel
    {
        public int HotelId { get; set; }
        [JsonIgnore]
        public Hotel Hotel { get; set; }
        public int FacilityId { get; set; }
        [JsonIgnore]
        public Facility Facility { get; set; }
    }
}
