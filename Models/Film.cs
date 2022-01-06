using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Pusok_Beata_ProiectFilm.Models
{
    public class Film
    {
        public int ID { get; set; }

        [Display(Name = "Titlu Film")]
        public string Titlu { get; set; }
        public string Regizor { get; set; }

        public string AnProductie { get; set; }
        public int ProducatorID { get; set; }
        public Producator Producator { get; set; }//navigation property
        public ICollection<GenFilm> GenuriFilm { get; set; }
    }
}
