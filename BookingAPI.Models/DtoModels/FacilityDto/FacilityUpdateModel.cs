namespace BookingAPI.Models.DtoModels.FacilityDto
{
    using BookingAPI.Models.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    public class FacilityUpdateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Info { get; set; }

        [JsonIgnore]
        public ICollection<Hotel> FacilityHotels { get; set; }
    }
}
