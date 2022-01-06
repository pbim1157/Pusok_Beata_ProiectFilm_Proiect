using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pusok_Beata_ProiectFilm.Models
{
    public class GenFilm
    {
        public int ID { get; set; }
        public int FilmID { get; set; }
        public Film Film { get; set; }
        public int GenID { get; set; }
        public Gen Gen { get; set; }
    }
}

