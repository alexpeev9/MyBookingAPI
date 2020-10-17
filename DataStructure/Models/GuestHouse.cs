namespace DataStructure.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class GuestHouse : Model
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsPremium { get; set; }
        [Required]
        public bool IsHot { get; set; }
        public int LocationId { get; set; }
        // MARK:- ONE-to-Many Relationships
        public virtual Location Location { get; set; }

        // MARK:- Many-to-Many Relationships
        public ICollection<GuestHouseAmenitie> GuestHouseAmenities { get; set; }
    }
}
