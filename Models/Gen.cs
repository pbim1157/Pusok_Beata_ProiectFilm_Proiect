using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pusok_Beata_ProiectFilm.Models
{
    public class Gen
    {
        public int ID { get; set; }
        public string NumeGen { get; set; }
        public ICollection<GenFilm> GenuriFilm { get; set; }
    }
}
