using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UAInnovate.Data;
using UAInnovate.Models;

namespace UAInnovate.Pages.OfficeSupplyRequests
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private UAInnovate.Models.UserModels? CurrentUserModel;

        public CreateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UAInnovate.Models.OfficeSupplyRequests OfficeSupplyRequests { get; set; } = default!;

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
            OfficeSupplyRequests.Date = DateTime.UtcNow;
            OfficeSupplyRequests.User = CurrentUserModel;
            OfficeSupplyRequests.OfficeLocation = CurrentUserModel?.WorkLocation;
            OfficeSupplyRequests.Status = StatusTypes.InProgress;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var inventoryItem = await _context.Inventory
            .FirstOrDefaultAsync(i => i.ItemName == OfficeSupplyRequests.ItemName);

            if (inventoryItem != null)
            {
                switch (OfficeSupplyRequests.CurrStock)
                {
                    case CurrStockTypes.Low:
                        inventoryItem.CurrentAmount = (int)Math.Round((double)inventoryItem.AvgAmount! * 0.5);
                        break;
                    case CurrStockTypes.High:
                        inventoryItem.CurrentAmount = (int)Math.Round((double)inventoryItem.AvgAmount! * 1.5);
                        break;
                    case CurrStockTypes.Medium:
                        inventoryItem.CurrentAmount = inventoryItem.AvgAmount;
                        break;
                    case CurrStockTypes.None:
                        inventoryItem.CurrentAmount = 0;
                        break;
                    default:
                        inventoryItem.CurrentAmount = inventoryItem.AvgAmount;
                        break;
                }
            }



            _context.OfficeSupplyRequests.Add(OfficeSupplyRequests);
            if (inventoryItem != null)
            {
                _context.Inventory.Update(inventoryItem);
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
