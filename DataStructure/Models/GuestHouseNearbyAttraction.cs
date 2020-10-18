namespace DataStructure.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("houseattraction")]
    public class GuestHouseNearbyAttraction
    {
        [Required(ErrorMessage = "The field cannot be empty")]
        public int GuestHouseId { get; set; }
        public GuestHouse GuestHouse { get; set; }

        [Required(ErrorMessage = "The field cannot be empty")]
        public int NearbyAttractionId { get; set; }
        public NearbyAttraction NearbyAttraction { get; set; }
    }
}
