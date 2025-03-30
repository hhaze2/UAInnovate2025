using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UAInnovate.Repository;
using UAInnovate.Models;
using Microsoft.CodeAnalysis.CSharp;

namespace UAInnovate.Pages
{
    public class AdminHome : PageModel
    {
        private readonly IRepository _repo;

        public AdminHome(IRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<UAInnovate.Models.Inventory> InventoryCard { get; set; }
        public IEnumerable<UAInnovate.Models.Suggestions> SuggestionCard { get; set; }
        public IEnumerable<UAInnovate.Models.MaintenanceRequests> MaintenanceCard { get; set; }
        public IEnumerable<UAInnovate.Models.OfficeSupplyRequests> SuppliesCard { get; set; }
        public async Task OnGetAsync()
        {
            InventoryCard = await _repo.GetInventoryOfPriority(PriorityTypes.High, null);
            SuggestionCard = await _repo.GetSuggestionsByPriority(PriorityTypes.High, null);
            MaintenanceCard = await _repo.GetMaintenanceByPriority(PriorityTypes.High, null);

            List<CurrStockTypes> types = [CurrStockTypes.New];
            SuppliesCard = await _repo.GetOfficeSupplyByStock(types, null);

        }
    }
}
