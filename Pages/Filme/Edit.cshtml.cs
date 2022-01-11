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

namespace Pusok_Beata_ProiectFilm.Pages.Filme
{
    public class EditModel : FilmCategoriesPageModel
    {
        private readonly Pusok_Beata_ProiectFilm.Data.Pusok_Beata_ProiectFilmContext _context;

        public EditModel(Pusok_Beata_ProiectFilm.Data.Pusok_Beata_ProiectFilmContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Film Film { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Film = await _context.Film.Include(b => b.Producator).Include(b => b.GenuriFilm).ThenInclude(b => b.Gen).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Film == null)
            {
                return NotFound();
            }

            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData
            PopulateAssignedCategoryData(_context, Film);
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id,string[] selectedGenuri)
        {
            if (id == null)
            {
                return NotFound();
            }
            var filmToUpdate = await _context.Film.Include(i => i.Producator).Include(i => i.GenuriFilm).ThenInclude(i => i.Gen).FirstOrDefaultAsync(s => s.ID == id);
            if(filmToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Film>(filmToUpdate,"Film",i => i.Titlu, i => i.Regizor,i => i.AnProductie, i => i.Producator))
            {
                UpdateFilmGenuri(_context, selectedGenuri, filmToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateFilmGenuri pentru a aplica informatiile din checkboxuri la entitatea Filme care
            //este editata
            UpdateFilmGenuri(_context, selectedGenuri, filmToUpdate);
            PopulateAssignedCategoryData(_context, filmToUpdate);
            return Page();


            _context.Attach(Film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(Film.ID))
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

        private bool FilmExists(int id)
        {
            return _context.Film.Any(e => e.ID == id);
        }
    }
}
