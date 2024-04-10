using OnlineInventory.Models;
using OnlineInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repositories.Warehouse
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationDbContext _context;
        public WarehouseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Count()
        {
            try
            {
                int count = _context.Warehouses.Count();
                return count;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<WarehouseViewModel> GetAllWarehouses()
        {
            try
            {
                var warehouses = _context.Warehouses.Select(x => new WarehouseViewModel
                {
                    WarehouseId = x.WarehouseId,
                    WarehouseName = x.WarehouseName,
                    City = x.City,
                    Country = x.Country,
                }).OrderBy(o => o.WarehouseId).ToList();

                return warehouses;
            }
            catch
            {
                return new List<WarehouseViewModel>();
            }
        }

        public WarehouseViewModel GetWarehouseById(int id)
        {
            try
            {
                var warehouse = _context.Warehouses.Select(s => new WarehouseViewModel
                {
                    WarehouseId = s.WarehouseId,
                    WarehouseName = s.WarehouseName,
                    City = s.City,
                    Country = s.Country,
                }).First();
                return warehouse;
            } catch
            {
                return new WarehouseViewModel();
            }
        }

        public async Task<int> CreateWarehouse(WarehouseViewModel model)
        {
            try
            {
                var warehouse = new WarehouseModel
                {
                    WarehouseName = model.WarehouseName,
                    City = model.City,
                    Country = model.Country,
                };

                _context.Warehouses.Add(warehouse);

                await _context.SaveChangesAsync();

                return warehouse.WarehouseId;
            }
            catch { 
                return 0;
            }
        }
        public async Task<int> UpdateWarehouse(WarehouseViewModel model)
        {
            try
            {
                var warehouse = _context.Warehouses.FirstOrDefault(x => x.WarehouseId == model.WarehouseId);

                if (warehouse == null) return 0;

                warehouse.WarehouseName = model.WarehouseName;
                warehouse.City = model.City;
                warehouse.Country = model.Country;

                _context.Warehouses.Update(warehouse);

                await _context.SaveChangesAsync();

                return warehouse.WarehouseId;
            }
            catch { 
                return 0;
            }
        }

    }

    public interface IWarehouseRepository
    {
        public int Count();
        public List<WarehouseViewModel> GetAllWarehouses();
        public WarehouseViewModel GetWarehouseById(int id);
        public Task<int> CreateWarehouse(WarehouseViewModel warehouse);
        public Task<int> UpdateWarehouse(WarehouseViewModel warehouse);
    }
}
