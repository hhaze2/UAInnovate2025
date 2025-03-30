﻿using System.Data.Entity;
using UAInnovate.Data;
using UAInnovate.Models;

namespace UAInnovate.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetInventoryOfPriority(PriorityTypes type, Office? office)
        {
            double discount = 1;
            switch (type)
            {
                case PriorityTypes.High:
                    discount = 1.5;
                    break;
                case PriorityTypes.Medium:
                    discount = 1;
                    break;
                case PriorityTypes.Low:
                    discount = 0.5;
                    break;
                default:
                    discount = 1;
                    break;
            }
            if (office != null)
            {
                return _context.Inventory.Where(i => i.CurrentAmount <= (int)Math.Round((double)i.AvgAmount! * discount) && i.OfficeLocation == office.OfficeName).ToList();
            }
            else
            {
                return _context.Inventory.Where(i => i.CurrentAmount <= (int)Math.Round((double)i.AvgAmount! * discount)).ToList();
            }
        }

        public async Task<IEnumerable<OfficeSupplyRequests>> GetOfficeSupplyByStock(List<CurrStockTypes> types, Office? office)
        {
            if (office != null)
            {
                return _context.OfficeSupplyRequests.Where(i => types.Contains(i.CurrStock) && i.OfficeLocation == office.OfficeName).ToList();
            } 
            else
            {
                return _context.OfficeSupplyRequests.Where(i => types.Contains(i.CurrStock) && i.Status == StatusTypes.InProgress).ToList();
            }
        }

        public async Task<IEnumerable<MaintenanceRequests>> GetMaintenanceByPriority(PriorityTypes type, Office? office)
        {
            if (office != null)
            {
                return _context.MaintenanceRequests.Where(i => i.Priority == type && i.OfficeLocation != office.OfficeName).ToList();
            }
            else
            {
                return _context.MaintenanceRequests.Where(i => i.Priority == type && i.Status == StatusTypes.InProgress).ToList();
            }
        }

        public async Task<IEnumerable<Suggestions>> GetSuggestionsByPriority(PriorityTypes type, Office? office)
        {
            if (office != null)
            {
                return _context.Suggestions.Where(i => i.Priority == type && i.OfficeLocation == office.OfficeName).ToList();
            }
            else
            {
                return _context.Suggestions.Where(i => i.Priority == type && i.Status == StatusTypes.InProgress).ToList();
            }
        }

        public async Task<Inventory> GetInventoryByName(string name, Office office)
        {
            return await _context.Inventory.FirstOrDefaultAsync(i => i.ItemName == name && i.OfficeLocation == office.OfficeName);
        }

        public async Task<Office> GetOfficeByName(string name)
        {
            return await _context.Office.FirstOrDefaultAsync(i => i.OfficeName == name);
        }

        public async Task<OfficeSupplyRequests> UpdateStatus(OfficeSupplyRequests item, StatusTypes type)
        {
            item.Status = type;
            _context.OfficeSupplyRequests.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<MaintenanceRequests> UpdateStatus(MaintenanceRequests item, StatusTypes type)
        {
            item.Status = type;
            _context.MaintenanceRequests.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Suggestions> UpdateStatus(Suggestions item, StatusTypes type)
        {
            item.Status = type;
            _context.Suggestions.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<OfficeSupplyRequests> GetSupplyRequest(int id)
        {
             return _context.OfficeSupplyRequests.FirstOrDefault(i => i.Id == id);
        }

        public async Task<MaintenanceRequests> GetMaintenanceRequest(int id)
        {
            return _context.MaintenanceRequests.FirstOrDefault(i => i.Id == id);
        }
        public async Task<Suggestions> GetSuggestions(int id)
        {
            return _context.Suggestions.FirstOrDefault(i => i.Id == id);
        }

        public async Task<IEnumerable<OfficeSupplyRequests>> GetSuppliesByStatus(StatusTypes type)
        {
            return await _context.OfficeSupplyRequests.Where(i => i.Status == type).ToListAsync();
        }
    }
}
