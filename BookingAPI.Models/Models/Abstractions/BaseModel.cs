namespace BookingAPI.Models.Models
{
    using System.ComponentModel.DataAnnotations;
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
