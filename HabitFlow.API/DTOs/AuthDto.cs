using System.ComponentModel.DataAnnotations;

namespace HabitFlow.API.DTOs
{
    
        public class LoginDto
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class RegisterDto
        {
            [Required]
            [MinLength(3, ErrorMessage ="Минимум 3 символа")]
            public string Username { get; set; }
            [Required]
            [EmailAddress(ErrorMessage ="Неверный формат email")]
            public string Email { get; set; }
            [Required]
            [MinLength(6, ErrorMessage = "Минимум 6 символов")]
            public string Password { get; set; }
        }
    
}
