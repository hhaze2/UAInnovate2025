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
using static UAInnovate.Const;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace UAInnovate.Pages.UserModels
{
    public class EditModel : PageModel
    {
        private readonly UAInnovate.Data.ApplicationDbContext _context;
        public bool isAdmin;
        public bool isUser;
        public string officeName;

        public EditModel(UAInnovate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UAInnovate.Models.UserModels UserModels { get; set; } = default!;

        public IList<UAInnovate.Models.Office> Offices { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usermodels =  await _context.UserModels.FirstOrDefaultAsync(m => m.Id == id);
            if (usermodels == null)
            {
                return NotFound();
            }

            //var adminKey = (await _context.Roles.FirstAsync(role => role.Name == Const.Role.Admin)).Id;
            //var userKey = (await _context.Roles.FirstAsync(role => role.Name == Const.Role.User)).Id;

            if (usermodels.permissons.Contains("User")){
                isUser = true;
            }
            else
            {
                isUser = false;
            }
            if (usermodels.permissons.Contains("Admin"))
            {
                isAdmin = true;
            }
            else
            {
                isAdmin = false;
            }

            //isAdmin = await _context.UserRoles.AnyAsync(claim => claim.UserId == usermodels.ForeignId && claim.RoleId == adminKey);
            //isUser = await _context.UserRoles.AnyAsync(claim => claim.UserId == usermodels.ForeignId && claim.RoleId == userKey);
            Offices = await _context.Office.ToListAsync();

            UserModels = usermodels;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id, bool isAdmin, bool isUser, string officeName)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(UserModels).State = EntityState.Modified;
            var userModel = await _context.UserModels.FirstAsync(u => u.Id == id);

            try
            {
                var perms = new List<string>();
                if (isAdmin)
                {
                    perms.Add("Admin");
                }
                if (isUser)
                {
                    perms.Add("User");
                }
                userModel.permissons = perms;
                userModel.WorkLocation = officeName;
                

                //_context.Attach(UserModels).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelsExists(UserModels.Id))
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

        private bool UserModelsExists(int id)
        {
            return _context.UserModels.Any(e => e.Id == id);
        }
    }
}
