using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UAInnovate.Data;
using UAInnovate.Models;

namespace UAInnovate.Pages.UserModels
{
    public class DeleteModel : PageModel
    {
        private readonly UAInnovate.Data.ApplicationDbContext _context;

        public DeleteModel(UAInnovate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UAInnovate.Models.UserModels UserModels { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usermodels = await _context.UserModels.FirstOrDefaultAsync(m => m.Id == id);

            if (usermodels == null)
            {
                return NotFound();
            }
            else
            {
                UserModels = usermodels;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usermodels = await _context.UserModels.FindAsync(id);
            if (usermodels != null)
            {
                UserModels = usermodels;
                _context.UserModels.Remove(UserModels);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
