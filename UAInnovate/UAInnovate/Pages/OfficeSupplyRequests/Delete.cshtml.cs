using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UAInnovate.Data;
using UAInnovate.Models;

namespace UAInnovate.Pages.OfficeSupplyRequests
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UAInnovate.Models.OfficeSupplyRequests OfficeSupplyRequests { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officesupplyrequests = await _context.OfficeSupplyRequests.FirstOrDefaultAsync(m => m.Id == id);

            if (officesupplyrequests == null)
            {
                return NotFound();
            }
            else
            {
                OfficeSupplyRequests = officesupplyrequests;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officesupplyrequests = await _context.OfficeSupplyRequests.FindAsync(id);
            if (officesupplyrequests != null)
            {
                OfficeSupplyRequests = officesupplyrequests;
                _context.OfficeSupplyRequests.Remove(OfficeSupplyRequests);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
