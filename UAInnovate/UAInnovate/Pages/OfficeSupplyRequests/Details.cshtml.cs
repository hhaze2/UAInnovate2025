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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
