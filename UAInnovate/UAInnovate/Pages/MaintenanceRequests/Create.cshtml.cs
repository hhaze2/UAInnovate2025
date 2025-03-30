﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UAInnovate.Data;
using UAInnovate.Models;

namespace UAInnovate.Pages.MaintenanceRequests
{
    public class CreateModel : PageModel
    {
        private readonly UAInnovate.Data.ApplicationDbContext _context;

        public CreateModel(UAInnovate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UAInnovate.Models.MaintenanceRequests MaintenanceRequests { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MaintenanceRequests.Add(MaintenanceRequests);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
