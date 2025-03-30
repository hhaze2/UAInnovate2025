using Microsoft.CodeAnalysis.Editing;
using UAInnovate.Models;


namespace UAInnovate.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Inventory>> GetInventoryOfPriority(PriorityTypes type, Office? office);
        Task<Inventory> GetInventoryByName(string name, Office office);
        Task<IEnumerable<OfficeSupplyRequests>> GetOfficeSupplyByStock(List<CurrStockTypes> types, Office? office);
        Task<IEnumerable<MaintenanceRequests>> GetMaintenanceByPriority(PriorityTypes type, Office? office);
        Task<IEnumerable<Suggestions>> GetSuggestionsByPriority(PriorityTypes type, Office? office);

        Task<Office> GetOfficeByName(string name);
        
    }
}
