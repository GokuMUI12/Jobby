using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
