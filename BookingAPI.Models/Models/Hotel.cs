namespace BookingAPI.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Hotel : BaseModel
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal PricePerNight { get; set; }

        public string Address  { get; set; }

        public int LocationTypeId { get; set; }
        // One to many
        public virtual LocationType LocationType { get; set; }
        
        // One to many
        public virtual User User { get; set; }

        // Many to many
        public ICollection<HotelFacility> HotelFacilities { get; set; }       
        //public ICollection<Facility> Facility { get; set; }

    }
}