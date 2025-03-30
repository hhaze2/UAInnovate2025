using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UAInnovate.Data;
using UAInnovate.Models;
using Microsoft.EntityFrameworkCore;

namespace UAInnovate.Pages.Inventory
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
        public UAInnovate.Models.Inventory Inventory { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var username = user.Email;
                var userModel = await _context.UserModels.FirstAsync(u => u.Username == username);
                //if (userModel.permissons.Contains("Admin"))
                //{
                //    isAdmin = true;
                //}
                //if (userModel.permissons.Contains("User"))
                //{
                //    isUser = true;
                //}
                CurrentUserModel = userModel;
            }

            else
            {
                return Page();
            }

            //var officeLocation = await _context.Office.FirstOrDefaultAsync(l => l.OfficeName == CurrentUserModel.WorkLocation);
            //MaintenanceRequests.OfficeLocation = officeLocation;
            Inventory.OfficeLocation = CurrentUserModel.WorkLocation;

            ModelState.Remove("Inventory.OfficeLocation");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inventory.Add(Inventory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
