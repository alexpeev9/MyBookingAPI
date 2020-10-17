namespace DataStructure.Models
{
    using System.ComponentModel.DataAnnotations;
    public class GuestHouseAmenitie
    {
        [Required(ErrorMessage = "The field cannot be empty")]
        public int GuestHouseId { get; set; }
        public GuestHouse GuestHouse { get; set; }

        [Required(ErrorMessage = "The field cannot be empty")]
        public int AmenitieId { get; set; }
        public Amenitie Amenitie { get; set; }
    }
}
