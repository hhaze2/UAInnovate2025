using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UAInnovate.Data;
using UAInnovate.Models;

namespace UAInnovate.Pages.UserModels
{
    public class IndexModel : PageModel
    {
        private readonly UAInnovate.Data.ApplicationDbContext _context;

        public IndexModel(UAInnovate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UAInnovate.Models.UserModels> UserModels { get;set; } = default!;

        public async Task OnGetAsync()
        {
            UserModels = await _context.UserModels.ToListAsync();
        }
    }
}
