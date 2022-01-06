using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pusok_Beata_ProiectFilm.Models;

namespace Pusok_Beata_ProiectFilm.Data
{
    public class Pusok_Beata_ProiectFilmContext : DbContext
    {
        public Pusok_Beata_ProiectFilmContext (DbContextOptions<Pusok_Beata_ProiectFilmContext> options)
            : base(options)
        {
        }

        public DbSet<Pusok_Beata_ProiectFilm.Models.Film> Film { get; set; }

        public DbSet<Pusok_Beata_ProiectFilm.Models.Producator> Producator { get; set; }

        public DbSet<Pusok_Beata_ProiectFilm.Models.Gen> Gen { get; set; }
    }
}
