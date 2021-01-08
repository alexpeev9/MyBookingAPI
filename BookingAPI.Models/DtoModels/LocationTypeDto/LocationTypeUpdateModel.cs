namespace BookingAPI.Models.DtoModels.LocationTypeDto
{
    using BookingAPI.Models.Models;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class LocationTypeUpdateModel
    {
        public string Name { get; set; }
        public string Info { get; set; }

        [JsonIgnore]
        public ICollection<Hotel> Hotels { get; set; }
    }
}
