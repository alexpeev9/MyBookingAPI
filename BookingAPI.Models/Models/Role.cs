namespace BookingAPI.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Role : BaseModel
    {

        [InverseProperty("Role")]
        public ICollection<User> Users { get; set; }
    }
}
