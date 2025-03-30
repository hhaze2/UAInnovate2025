using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UAInnovate.Data;
using UAInnovate.Models;

namespace UAInnovate.Pages.Suggestions
{
    public class DetailsModel : PageModel
    {
        private readonly UAInnovate.Data.ApplicationDbContext _context;

        public DetailsModel(UAInnovate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public UAInnovate.Models.Suggestions Suggestions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suggestions = await _context.Suggestions.FirstOrDefaultAsync(m => m.Id == id);
            if (suggestions == null)
            {
                return NotFound();
            }
            else
            {
                Suggestions = suggestions;
            }
            return Page();
        }
    }
}
