using System.ComponentModel.DataAnnotations;

namespace ProjektZawody.Models
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Age { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
