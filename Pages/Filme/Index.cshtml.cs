using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pusok_Beata_ProiectFilm.Data;
using Pusok_Beata_ProiectFilm.Models;

namespace Pusok_Beata_ProiectFilm.Pages.Filme
{
    public class IndexModel : PageModel
    {
        private readonly Pusok_Beata_ProiectFilm.Data.Pusok_Beata_ProiectFilmContext _context;

        public IndexModel(Pusok_Beata_ProiectFilm.Data.Pusok_Beata_ProiectFilmContext context)
        {
            _context = context;
        }

        public IList<Film> Film { get;set; }

        public async Task OnGetAsync()
        {
            Film = await _context.Film.Include(b => b.Producator).ToListAsync();
        }
    }
}
