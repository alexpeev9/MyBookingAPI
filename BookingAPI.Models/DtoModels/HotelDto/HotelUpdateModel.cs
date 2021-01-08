using BookingAPI.Models.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookingAPI.Models.DtoModels.HotelDto
{
    public class HotelUpdateModel
    {
        public string Name { get; set; }
        public decimal PricePerNight { get; set; }
        public string Address { get; set; }
        // One to many
        public int LocationTypeId { get; set; }
        //public virtual LocationType LocationType { get; set; }

        // One to many
        [JsonIgnore]
        public virtual User User { get; set; }

        // Many to many
        [JsonIgnore]
        public ICollection<HotelFacility> HotelFacilities { get; set; }
    }
}
