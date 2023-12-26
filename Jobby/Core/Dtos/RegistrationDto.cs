using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class RegistrationDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please Select a Role.")]
        public string Role { get; set; }
    }
}
