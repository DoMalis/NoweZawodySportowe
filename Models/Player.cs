using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static System.Formats.Asn1.AsnWriter;

namespace ProjektZawody.Models
{
    public class Player //klasa zawierająca definicję obiektu player
    {
        //atrybut id bedzie przydzielany automatycznie
        //[Key]
        public int Id { get; set; }

        //atrybut imię jest obowiązkowym polem
        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string FirstName { get; set; }

        //atrybut nazwisko jest obowiązkowym polem
        [Required(ErrorMessage = "Pole obowiązkowe")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        //atrybut wiek jest obowiązkowym polem, przyjmuje wartości o 0 do 100
        [Display(Name = "Wiek")]
        [Range(1,100)]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int Age { get; set; }

        //przechowuję listę zdobytych punktów
        public List<Score> Scores { get; set; } = new List<Score>();


    }
}
 