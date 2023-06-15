using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjektZawody.Data.ViewModels
{
    public class AddScoresViewModel
    {
        [Display(Name ="Imię")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Wynik")]
        public int Points { get; set; }

        [Required]
        public int PlayerId { get; set; }
        
        [Required]
        public int CompetitionId { get; set; }

        public string CompetitionName { get; set;}
    }
}
