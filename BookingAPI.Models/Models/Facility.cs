using System.Collections.Generic;

namespace BookingAPI.Models.Models
{
    public class Facility : BaseModel
    {
        // Many to many
        public ICollection<HotelFacility> HotelFacilities { get; set; }
    }
}
