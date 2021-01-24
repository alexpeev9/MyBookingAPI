using System.Collections.Generic;

namespace BookingAPI.Models.AuthenticationDto
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public IList<string> Hotels { get; set; }
    }
}
