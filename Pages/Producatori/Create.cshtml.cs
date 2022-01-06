using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pusok_Beata_ProiectFilm.Data;
using Pusok_Beata_ProiectFilm.Models;

namespace Pusok_Beata_ProiectFilm.Pages.Producatori
{
    public class CreateModel : PageModel
    {
        private readonly Pusok_Beata_ProiectFilm.Data.Pusok_Beata_ProiectFilmContext _context;

        public CreateModel(Pusok_Beata_ProiectFilm.Data.Pusok_Beata_ProiectFilmContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Producator Producator { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Producator.Add(Producator);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
