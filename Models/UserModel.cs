
using System.ComponentModel.DataAnnotations;

namespace ProjektZawody.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Pole jest obowiązkowe")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Pole jest obowiązkowe")]

        public string Password { get; set; }
        public string Role { get; set; }    
    }
}
