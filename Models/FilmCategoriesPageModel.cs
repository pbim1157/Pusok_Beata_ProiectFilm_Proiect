using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pusok_Beata_ProiectFilm.Data;

namespace Pusok_Beata_ProiectFilm.Models
{
    public class FilmCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Pusok_Beata_ProiectFilmContext context,Film film)
        {
            var allGenuri = context.Gen;
            var filmGenuri = new HashSet<int>(film.GenuriFilm.Select(c => c.GenID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allGenuri)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    GenID = cat.ID,
                    Nume = cat.NumeGen,
                    Assigned = filmGenuri.Contains(cat.ID)
                });
            }
        }
        public void UpdateFilmGenuri(Pusok_Beata_ProiectFilmContext context, string[] selectedGenuri, Film filmToUpdate)
        {
            if (selectedGenuri == null)
            {
                filmToUpdate.GenuriFilm = new List<GenFilm>();
                return;
            }
            var selectedGenuriHS = new HashSet<string>(selectedGenuri);
            var filmGenuri = new HashSet<int>(filmToUpdate.GenuriFilm.Select(c => c.Gen.ID));
            foreach (var cat in context.Gen)
            {
                if (selectedGenuriHS.Contains(cat.ID.ToString()))
                {
                    if (!filmGenuri.Contains(cat.ID))
                    {
                        filmToUpdate.GenuriFilm.Add(
                            new GenFilm
                            {
                                FilmID = filmToUpdate.ID,
                                GenID = cat.ID
                            });
                    }
                }
                else
                {
                    if (filmGenuri.Contains(cat.ID))
                    {
                        GenFilm courseToRemove = filmToUpdate.GenuriFilm.SingleOrDefault(i => i.GenID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
