using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProjektZawody.Models
{
    public class NewUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [Display(Name = "Rola uzytkownika")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        public string Role { get; set; }

        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        [Display(Name = "Powierdż hasło")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
