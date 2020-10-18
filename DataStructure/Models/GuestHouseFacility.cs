namespace DataStructure.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("housefacility")]
    public class GuestHouseFacility
    {
        [Required(ErrorMessage = "The field cannot be empty")]
        public int GuestHouseId { get; set; }
        public GuestHouse GuestHouse { get; set; }

        [Required(ErrorMessage = "The field cannot be empty")]
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}
