using BookingAPI.Models.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAPI.Models.DtoModels.HotelDto
{
    public class HotelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerNight { get; set; }

        public string Address { get; set; }

        // One to many
        public virtual LocationType LocationType { get; set; }

        // One to many
        public virtual User User { get; set; }

        // Many to many
        public IList<string> Facilities { get; set; }
    }
}
