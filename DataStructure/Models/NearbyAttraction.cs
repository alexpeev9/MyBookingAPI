namespace DataStructure.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class NearbyAttraction : Model
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        // MARK:- Many-to-Many Relationships
        public ICollection<GuestHouseNearbyAttraction> GuestHouseNearbyAttraction { get; set; }
    }
}
