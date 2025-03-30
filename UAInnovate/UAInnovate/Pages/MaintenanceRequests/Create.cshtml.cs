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
using Microsoft.EntityFrameworkCore;

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

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}

        [BindProperty]
        public UAInnovate.Models.MaintenanceRequests MaintenanceRequests { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.

        public async Task OnGetAsync()
        {
            var identityId = _userManager.GetUserId(User);

            var isAdmin = false;
            var isUser = false;
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var username = user.Email;
                var userModel = await _context.UserModels.FirstAsync(u => u.Username == username);
                if (userModel.permissons.Contains("Admin"))
                {
                    isAdmin = true;
                }
                if (userModel.permissons.Contains("User"))
                {
                    isUser = true;
                }
                CurrentUserModel = userModel;
            }

            // Query the database to fetch the corresponding UserModel
            //CurrentUserModel = await _context.UserModels.FindAsync(identityId);
            else
            {
                CurrentUserModel = null;
            }

            // Example: You now have the corresponding UserModel for the logged-in user
            if (CurrentUserModel == null)
            {
                // Handle case where user model isn't found in the database
            }

        }
        public async Task<IActionResult> OnPostAsync()
        {
            var isAdmin = false;
            var isUser = false;
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var username = user.Email;
                var userModel = await _context.UserModels.FirstAsync(u => u.Username == username);
                if (userModel.permissons.Contains("Admin"))
                {
                    isAdmin = true;
                }
                if (userModel.permissons.Contains("User"))
                {
                    isUser = true;
                }
                CurrentUserModel = userModel;
            }
            else
            {
                return Page();
            }
            MaintenanceRequests.Date = DateTime.UtcNow;
            MaintenanceRequests.Username = CurrentUserModel.Username;
            //var officeLocation = await _context.Office.FirstOrDefaultAsync(l => l.OfficeName == CurrentUserModel.WorkLocation);
            //MaintenanceRequests.OfficeLocation = officeLocation;
            MaintenanceRequests.OfficeLocation = CurrentUserModel.WorkLocation;
            MaintenanceRequests.Status = StatusTypes.InProgress;

            ModelState.Remove("MaintenanceRequests.Username");
            ModelState.Remove("MaintenanceRequests.OfficeLocation");
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MaintenanceRequests.Add(MaintenanceRequests);
            await _context.SaveChangesAsync();

            if (isAdmin)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return RedirectToPage("./Create");
            }

            

        }
    }
}
