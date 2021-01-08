using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookingAPI.Models.Models
{
    public class LocationType : BaseModel
    {
        // One to many
        [JsonIgnore]
        public ICollection<Hotel> Hotels { get; set; }
    }
}
