namespace BookingAPI.Models.DtoModels.LocationTypeDto
{
    using BookingAPI.Models.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class LocationTypeCreateModel
    {
        public string Name { get; set; }
        public string Info { get; set; }
        
        [JsonIgnore]
        public ICollection<Hotel> Hotels { get; set; }
    }
}
