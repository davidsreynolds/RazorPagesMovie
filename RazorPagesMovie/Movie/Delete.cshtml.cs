﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Movie
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        public DeleteModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RazorPagesMovie.Models.Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FindAsync(id);

            if (Movie != null)
            {
                _context.Movie.Remove(Movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnDeleteAsync(int? id)
        {
            if (id == null)
            {
                Movie = await _context.Movie.FirstOrDefaultAsync();
            }
            else
            {
                Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);
            }

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
