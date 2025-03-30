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

namespace UAInnovate.Pages.Suggestions
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
        public UAInnovate.Models.Suggestions Suggestions { get; set; } = default!;

        [BindProperty]
        public bool IsAnonymous { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.

        public async Task OnGetAstnc()
        {
            var identityId = _userManager.GetUserId(User);

            // Query the database to fetch the corresponding UserModel
            CurrentUserModel = await _context.UserModels.FindAsync(identityId);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            Suggestions.User = CurrentUserModel;
            var officeLocation = await _context.Office.FirstOrDefaultAsync(l => l.OfficeName == CurrentUserModel.WorkLocation);
            //Suggestions.OfficeLocation = CurrentUserModel?.WorkLocation;
            Suggestions.OfficeLocation = officeLocation;
            Suggestions.Date = DateTime.UtcNow;
            Suggestions.Status = StatusTypes.InProgress;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Suggestions.Add(Suggestions);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
