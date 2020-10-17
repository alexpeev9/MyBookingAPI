namespace DataStructure.Models
{
    using System.ComponentModel.DataAnnotations;
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
