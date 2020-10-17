namespace DataStructure.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Facility : Model  // Air Conditioner, Swimming Pool, Gym, Nice View 
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
        
        // MARK:- Many-to-Many Relationships
        public ICollection<GuestHouseFacility> GuestHouseFacility { get; set; }
    }
}
