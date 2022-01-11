using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pusok_Beata_ProiectFilm.Models
{
    public class FilmData
    {
        public IEnumerable<Film> Filme { get; set; }
        public IEnumerable<Gen> Genuri { get; set; }
        public IEnumerable<GenFilm> GenuriFilm { get; set; }
    }
}
