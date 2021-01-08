namespace BookingAPI.Models.AuthenticationDto
{
    public class UpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
    }
}
