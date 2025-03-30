using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UAInnovate.Data;
using UAInnovate.Models;
using Microsoft.AspNetCore.Identity;

namespace UAInnovate.Pages.MaintenanceRequests
{
    public class CreateModel : PageModel
    {
        private readonly UAInnovate.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private UAInnovate.Models.UserModels? CurrentUserModel; 
        public CreateModel(UAInnovate.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UAInnovate.Models.MaintenanceRequests MaintenanceRequests { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.

        public async Task OnGetAstnc()
        {
            var identityId = _userManager.GetUserId(User);

            // Query the database to fetch the corresponding UserModel
            CurrentUserModel = await _context.UserModels.FindAsync(identityId);

            // Example: You now have the corresponding UserModel for the logged-in user
            if (CurrentUserModel == null)
            {
                // Handle case where user model isn't found in the database
            }

        }
        public async Task<IActionResult> OnPostAsync()
        {
            MaintenanceRequests.Date = DateTime.UtcNow;
            MaintenanceRequests.User = CurrentUserModel;
            MaintenanceRequests.OfficeLocation = CurrentUserModel?.WorkLocation;
            MaintenanceRequests.Status = StatusTypes.InProgress;
            
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
