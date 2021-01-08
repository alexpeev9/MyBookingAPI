namespace BookingAPI.Models.AuthenticationDto
{
    using System.ComponentModel.DataAnnotations;
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

    }
}
