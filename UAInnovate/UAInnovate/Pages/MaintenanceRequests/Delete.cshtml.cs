using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UAInnovate.Data;
using UAInnovate.Models;

namespace UAInnovate.Pages.MaintenanceRequests
{
    public class DeleteModel : PageModel
    {
        private readonly UAInnovate.Data.ApplicationDbContext _context;

        public DeleteModel(UAInnovate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UAInnovate.Models.MaintenanceRequests MaintenanceRequests { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenancerequests = await _context.MaintenanceRequests.FirstOrDefaultAsync(m => m.Id == id);

            if (maintenancerequests == null)
            {
                return NotFound();
            }
            else
            {
                MaintenanceRequests = maintenancerequests;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenancerequests = await _context.MaintenanceRequests.FindAsync(id);
            if (maintenancerequests != null)
            {
                MaintenanceRequests = maintenancerequests;
                _context.MaintenanceRequests.Remove(MaintenanceRequests);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
