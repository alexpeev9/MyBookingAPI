namespace DataStructure.Models
{
    using System.Collections.Generic;
    public class Amenitie : Model
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        
        // MARK:- Many-to-Many Relationships
        public ICollection<GuestHouseAmenitie> GuestHouseAmenities { get; set; }
    }
}
