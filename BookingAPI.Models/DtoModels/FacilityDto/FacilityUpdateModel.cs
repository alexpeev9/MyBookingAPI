namespace BookingAPI.Models.DtoModels.FacilityDto
{
    using BookingAPI.Models.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    public class FacilityUpdateModel
    {
        public string Name { get; set; }

        public string Info { get; set; }

        [JsonIgnore]
        public ICollection<Hotel> FacilityHotels { get; set; }
    }
}
