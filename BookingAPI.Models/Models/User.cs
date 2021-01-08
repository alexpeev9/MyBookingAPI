namespace BookingAPI.Models.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]

        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        [JsonIgnore]
        public virtual Role Role { get; set; }
        [JsonIgnore]
        public ICollection<Hotel> Hotels { get; set; }

    }
}
