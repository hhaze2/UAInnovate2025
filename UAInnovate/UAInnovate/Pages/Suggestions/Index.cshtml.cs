using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UAInnovate.Data;
using UAInnovate.Models;
using UAInnovate.Repository;

namespace UAInnovate.Pages.Suggestions
{
    public class IndexModel : PageModel
    {
        private readonly UAInnovate.Data.ApplicationDbContext _context;
        private readonly IRepository _repo;

        public IndexModel(UAInnovate.Data.ApplicationDbContext context, IRepository repo)
        {
            _context = context;
        }

        [BindProperty]
        public IList<UAInnovate.Models.Suggestions> Suggestions { get;set; } = default!;

        public async void SetComplete(int id)
        {
            var item = await _repo.GetSuggestions(id);
            await _repo.UpdateStatus(item, StatusTypes.Completed);
            await _context.SaveChangesAsync();
            Suggestions = await _context.Suggestions.Where(i => i.Status == StatusTypes.InProgress).ToListAsync();
        }

        public async void SetRejected(int id)
        {
            var item = await _repo.GetSuggestions(id);
            await _repo.UpdateStatus(item, StatusTypes.Rejected);
            await _context.SaveChangesAsync();
            Suggestions = await _context.Suggestions.Where(i => i.Status == StatusTypes.InProgress).ToListAsync();
        }

        public IActionResult OnPostReject(int id)
        {
            // Call the method to reject the maintenance request
            SetRejected(id);

            // Optionally, return the updated page
            return RedirectToPage();
        }

        public IActionResult OnPostComplete(int id)
        {
            // Call the method to reject the maintenance request
            SetComplete(id);

            // Optionally, return the updated page
            return RedirectToPage();
        }
        public async Task OnGetAsync()
        {
            Suggestions = await _context.Suggestions.Where(i => i.Status == StatusTypes.InProgress).ToListAsync();
        }
    }
}
