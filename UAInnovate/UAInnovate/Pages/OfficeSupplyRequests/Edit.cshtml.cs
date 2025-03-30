using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UAInnovate.Data;
using UAInnovate.Models;

namespace UAInnovate.Pages.OfficeSupplyRequests
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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
            OfficeSupplyRequests = officesupplyrequests;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("OfficeSupplyRequests.Username");
            ModelState.Remove("OfficeSupplyRequests.OfficeLocation");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OfficeSupplyRequests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeSupplyRequestsExists(OfficeSupplyRequests.Id))
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

        private bool OfficeSupplyRequestsExists(int id)
        {
            return _context.OfficeSupplyRequests.Any(e => e.Id == id);
        }
    }
}
