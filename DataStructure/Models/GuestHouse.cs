namespace DataStructure.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("guesthouse")]
    public class GuestHouse : Model
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 40 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Contact Number is required")]
        public long ContactNumber { get; set; }
        [Required(ErrorMessage = "Info is required")]
        [StringLength(150, ErrorMessage = "Info can't be longer than 150 characters")]
        public string Info { get; set; }
        [Required(ErrorMessage = "Premium Identification is required")]
        public bool IsPremium { get; set; }
        [Required(ErrorMessage = "IsHot Identification is required")]
        public bool IsHot { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string Address { get; set; }
        public int LocationId { get; set; }
        // MARK:- One-to-Many Relationships
        public virtual Location Location { get; set; }
        public virtual HouseType HouseType { get; set; }
        
        // MARK:- Many-to-Many Relationships
        public ICollection<GuestHouseFacility> GuestHouseFacility { get; set; }
        public ICollection<GuestHouseNearbyAttraction> GuestHouseNearbyAttraction { get; set; }
    }
}
