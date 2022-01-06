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
    public class DetailsModel : PageModel
    {
        private readonly Pusok_Beata_ProiectFilm.Data.Pusok_Beata_ProiectFilmContext _context;

        public DetailsModel(Pusok_Beata_ProiectFilm.Data.Pusok_Beata_ProiectFilmContext context)
        {
            _context = context;
        }

        public Film Film { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Film = await _context.Film.FirstOrDefaultAsync(m => m.ID == id);

            if (Film == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
