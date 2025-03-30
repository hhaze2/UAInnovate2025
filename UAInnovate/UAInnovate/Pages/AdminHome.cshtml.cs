using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UAInnovate.Repository;
using UAInnovate.Models;
using Microsoft.CodeAnalysis.CSharp;
using UAInnovate.Data;
using UAInnovate.Services;

namespace UAInnovate.Pages
{
    public class AdminHome : PageModel
    {
        private readonly IRepository _repo;
        private ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public AdminHome(ApplicationDbContext context, IRepository repo, EmailService emailService)
        {
            _context = context;
            _repo = repo;
            _emailService = emailService;
        }

        public void SendEmail()
        {
            _emailService.SendEmail(
                toEmail: "cloie@southerndales.net",
                subject: "test from hackathon",
                body: "a new request was made"
                );
        }

        public IEnumerable<UAInnovate.Models.Inventory> InventoryCard { get; set; }
        public IEnumerable<UAInnovate.Models.Suggestions> SuggestionCard { get; set; }
        public IEnumerable<UAInnovate.Models.MaintenanceRequests> MaintenanceCard { get; set; }
        public IEnumerable<UAInnovate.Models.OfficeSupplyRequests> SuppliesCard { get; set; }
        public List<DataPoint> TimeDataPoints { get; set; }

        public List<DataPoint> ItemDataPoints { get; set; }
        public async Task OnGetAsync()
        {
            InventoryCard = await _repo.GetInventoryOfPriority(PriorityTypes.High, null);
            SuggestionCard = await _repo.GetSuggestionsByPriority(PriorityTypes.High, null);
            MaintenanceCard = await _repo.GetMaintenanceByPriority(PriorityTypes.High, null);

            List<CurrStockTypes> types = [CurrStockTypes.New];
            SuppliesCard = await _repo.GetOfficeSupplyByStock(types, null);

            //Request over time data
            var groupedRequests = _context.OfficeSupplyRequests
            .GroupBy(r => r.Date.Date)
            .Select(group => new
            {
                Date = group.Key,
                RequestCount = group.Count()
            })
            .OrderBy(data => data.Date).ToList();

            TimeDataPoints = groupedRequests.Select( g => new DataPoint
            {
                x = g.Date.ToString("yyyy-MM-dd"), // X-axis (date)
                y = g.RequestCount                 // Y-axis (request count)
            }).ToList();

            //Most Popular Request Over time
            var itemCounts = _context.OfficeSupplyRequests
            .GroupBy(r => r.ItemName) // Group requests by item name
            .Select(group => new DataPoint
            {
             x = group.Key,        // The item name
             y = group.Count() // Count the number of requests for each item
            })
            .OrderByDescending(data => data.y) // Sort by the count (most requested first)
            .Take(10) // Optional: Limit to the top 10 most requested items
            .ToList();

            ItemDataPoints = itemCounts.Select(item => new DataPoint
            {
                x = item.x,       // X-axis: item name
                y = item.y    // Y-axis: request count
            }).ToList();
        }
    }
}
