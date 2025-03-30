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

        Task<OfficeSupplyRequests> UpdateStatus(OfficeSupplyRequests item, StatusTypes type);

        Task<MaintenanceRequests> UpdateStatus(MaintenanceRequests item, StatusTypes type);
        Task<Suggestions> UpdateStatus(Suggestions item, StatusTypes type);
        Task<Office> GetOfficeByName(string name);

        Task<OfficeSupplyRequests> GetSupplyRequest(int id);
        Task<MaintenanceRequests> GetMaintenanceRequest(int id);
        Task<Suggestions> GetSuggestions(int id);

        Task<IEnumerable<OfficeSupplyRequests>> GetSuppliesByStatus(StatusTypes type);

    }
}
