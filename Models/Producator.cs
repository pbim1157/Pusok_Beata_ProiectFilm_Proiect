using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pusok_Beata_ProiectFilm.Models
{
    public class Producator
    {

        public int ID { get; set; }
        public string NumeProducator { get; set; }
        public ICollection<Film> Filme { get; set; } //navigation property
    }
}
