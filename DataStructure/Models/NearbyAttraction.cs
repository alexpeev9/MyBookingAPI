namespace DataStructure.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("nearbyattraction")]
    public class NearbyAttraction : Model
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 40 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string ImageUrl { get; set; }

        // MARK:- Many-to-Many Relationships
        public ICollection<GuestHouseNearbyAttraction> GuestHouseNearbyAttraction { get; set; }
    }
}
