using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pusok_Beata_ProiectFilm.Data;
using Pusok_Beata_ProiectFilm.Models;

namespace Pusok_Beata_ProiectFilm.Pages.Filme
{
    public class CreateModel : FilmCategoriesPageModel
    {
        private readonly Pusok_Beata_ProiectFilm.Data.Pusok_Beata_ProiectFilmContext _context;

        public CreateModel(Pusok_Beata_ProiectFilm.Data.Pusok_Beata_ProiectFilmContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");

            var film = new Film();
            film.GenuriFilm = new List<GenFilm>();
            PopulateAssignedCategoryData(_context, film);

            return Page();
        }

        [BindProperty]
        public Film Film { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedGenuri)
        {
            var newFilm = new Film();
            if (selectedGenuri != null)
            {
                newFilm.GenuriFilm = new List<GenFilm>();
                foreach (var cat in selectedGenuri)
                {
                    var catToAdd = new GenFilm
                    {
                        GenID = int.Parse(cat)
                    };
                    newFilm.GenuriFilm.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Film>(newFilm, "Film", i => i.Titlu, i => i.Regizor, i => i.AnProductie, i => i.ProducatorID))
            {
                _context.Film.Add(newFilm);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newFilm);
            return Page();
        

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Film.Add(Film);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
