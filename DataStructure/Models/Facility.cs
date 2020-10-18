namespace DataStructure.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("facility")]
    public class Facility : Model  // Air Conditioner, Swimming Pool, Gym, Nice View 
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 40 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Icon is required")]
        public string Icon { get; set; }
        
        // MARK:- Many-to-Many Relationships
        public ICollection<GuestHouseFacility> GuestHouseFacility { get; set; }
    }
}
