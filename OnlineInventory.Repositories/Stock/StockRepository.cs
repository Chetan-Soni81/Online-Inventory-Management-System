using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineInventory.Models;
using OnlineInventory.ViewModels;

namespace OnlineInventory.Repositories.Stock
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddStock(StockViewModel stock)
        {
            try
            {
                var record = new StockModel
                {
                    ProductId = stock.ProductId,
                    WarehouseId = stock.WarehouseId,
                    Quantity = stock.Quantity,
                };

                _context.Stocks.Add(record);

                await _context.SaveChangesAsync();

                return true;
            } catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteStock(int id)
        {
            try
            {
                var record = await _context.Stocks.FirstOrDefaultAsync(w => w.ProductId == id);

                if (record == null) return false;

                _context.Stocks.Remove(record);

                await _context.SaveChangesAsync();

                return true;
            } catch
            {
                return false;
            }
        }

        public Task<StockViewModel?> GetStockById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StockViewModel>> GetStocks()
        {
            var stocks = await _context.Stocks.Include(i => i.Product).Include(i => i.Warehouse).Select(s => new StockViewModel
            {
                StockId = s.StockId,
                ProductId = s.ProductId,
                WarehouseId = s.WarehouseId,
                Quantity = s.Quantity,
                ProductName = s.Product == null ? "" : s.Product.ProductName,
                WarehouseName = s.Warehouse == null ? "" :s.Warehouse.WarehouseName
            }).ToListAsync();

            return stocks;
        }

        public async Task<List<StockViewModel>> GetStocksByProduct(int productid)
        {
            var stocks = await _context.Stocks.Where(w => w.ProductId == productid).Include(i => i.Product).Include(i => i.Warehouse).Select(s => new StockViewModel
            {
                StockId = s.StockId,
                ProductId = s.ProductId,
                WarehouseId = s.WarehouseId,
                Quantity = s.Quantity,
                ProductName = s.Product == null ? "" : s.Product.ProductName,
                WarehouseName = s.Warehouse == null ? "" : s.Warehouse.WarehouseName
            }).ToListAsync();

            return stocks;
        }

        public async Task<List<StockViewModel>> GetStocksByWarehouse(int warehouseid)
        {
            var stocks = await _context.Stocks.Where(w => w.WarehouseId == warehouseid).Include(i => i.Product).Include(i => i.Warehouse).Select(s => new StockViewModel
            {
                StockId = s.StockId,
                ProductId = s.ProductId,
                WarehouseId = s.WarehouseId,
                Quantity = s.Quantity,
                ProductName = s.Product == null ? "" : s.Product.ProductName,
                WarehouseName = s.Warehouse == null ? "" : s.Warehouse.WarehouseName
            }).ToListAsync();

            return stocks;
        }

        public async Task<bool> UpdateStock(StockViewModel stock)
        {
            try
            {
                var record = await _context.Stocks.FirstOrDefaultAsync(w => w.ProductId == stock.StockId);

                if (record == null) return false;


                record.ProductId = stock.ProductId;
                record.WarehouseId = stock.WarehouseId;
                record.Quantity = stock.Quantity;
                

                _context.Stocks.Update(record);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public interface IStockRepository
    {
        Task<List<StockViewModel>> GetStocks();
        Task<List<StockViewModel>> GetStocksByProduct(int productid);
        Task<List<StockViewModel>> GetStocksByWarehouse(int warehouseid);
        Task<StockViewModel?> GetStockById(int id);
        Task<bool> AddStock(StockViewModel stock);
        Task<bool> DeleteStock(int id);
        Task<bool> UpdateStock(StockViewModel stock);
    }
}
