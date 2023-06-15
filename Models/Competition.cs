using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using ProjektZawody.Data.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjektZawody.Models
{
    public class Competition //klasa zawierająca definicję obiektu competition
    {
        //[Key]
        public int Id { get; set; }

        //atrybut nazwa jest obowiązkowym polem
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string Name { get; set; }

        [Display(Name = "Minimaly Wiek")]
        //atrybut minage jest obowiązkowym polem
        [Required(ErrorMessage = "Pole obowiązkowe")]
        [Range(1,100)]
        public int MinAge { get; set; }

        [Display(Name = "Maksymalny wiek")]
        [Range(1,100)]
        //atrybut maxage jest obowiązkowym polem
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int MaxAge { get; set; }
        [Display(Name = "Status")]

        //status zawodow
        public CompetitionStatus CompetitionStatus { get; set; }

        //przechowuje liste wyników 
        public List<Score> Scores { get; set; } = new List<Score>();


    }
}
