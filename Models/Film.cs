using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit;


namespace Pusok_Beata_ProiectFilm.Models
{
    public class Film
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Titlu Film")]
        public string Titlu { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$ Numele autorului trebuie sa fie de forma 'Prenume Nume"), Required, StringLength(50, MinimumLength = 3)]

        public string Regizor { get; set; }

        public string AnProductie { get; set; }
        public int ProducatorID { get; set; }
        public Producator Producator { get; set; }//navigation property
        public ICollection<GenFilm> GenuriFilm { get; set; }
    }

}
