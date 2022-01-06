using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pusok_Beata_ProiectFilm.Data;
using Pusok_Beata_ProiectFilm.Models;

namespace Pusok_Beata_ProiectFilm.Pages.Producatori
{
    public class EditModel : PageModel
    {
        private readonly Pusok_Beata_ProiectFilm.Data.Pusok_Beata_ProiectFilmContext _context;

        public EditModel(Pusok_Beata_ProiectFilm.Data.Pusok_Beata_ProiectFilmContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producator Producator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producator = await _context.Producator.FirstOrDefaultAsync(m => m.ID == id);

            if (Producator == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Producator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducatorExists(Producator.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProducatorExists(int id)
        {
            return _context.Producator.Any(e => e.ID == id);
        }
    }
}
