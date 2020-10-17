namespace DataStructure.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Location : Model // Sea,Mountain,Country,City
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public ICollection<GuestHouse> GuestHouses { get; set; }
    }
}
