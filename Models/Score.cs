using System.ComponentModel.DataAnnotations;

namespace ProjektZawody.Models
{
    public class Score //klasa zawierająca definicję obiektu score
    {

        //każdy score przypisany jest do danego id player
        [Required]
        public int PlayerId { get; set; }

        public Player Player { get; set; }

        //każdy score przypisany jest do danego id competition
        [Required]
        public int CompetitionId { get; set; }

        public Competition Competition { get; set; }

        [Display(Name = "Wynik")]
        //przechowuje wartość zdobytych punktów
        public int Points { get; set; }

    }
}
