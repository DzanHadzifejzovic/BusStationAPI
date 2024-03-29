using System.ComponentModel.DataAnnotations;

namespace BusStation_API.Core.Application.DTOs.Authentication
{
    public class RegisterModel
    {
      
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
