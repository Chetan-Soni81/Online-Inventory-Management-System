using Microsoft.EntityFrameworkCore;
using OnlineInventory.Models;
using OnlineInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repositories.Supplier
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;
        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddSupplier(SupplierViewModel supplier)
        {
            try
            {
                var record = new SupplierModel
                {
                    SupplierName = supplier.SupplierName,
                    MobileNo = supplier.MobileNo,
                    Email = supplier.Email,
                    Country = supplier.Country,
                    City = supplier.City,
                };

                _context.Suppliers.Add(record);

                await _context.SaveChangesAsync();

                return true;
            } catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            try
            {
                var supplier = await _context.Suppliers.Where(s => s.SupplierId == id).FirstOrDefaultAsync();

                if (supplier == null) return false;

                _context.Suppliers.Remove(supplier);

                return true;
            } catch
            {
                return false;
            }
        }

        public async Task<SupplierViewModel?> GetSupplierById(int id)
        {
            try
            {
                var suppliers = await _context.Suppliers.Where(x => x.SupplierId == id).Select(s => new SupplierViewModel
                {
                    SupplierId = s.SupplierId,
                    SupplierName = s.SupplierName,
                    MobileNo = s.MobileNo,
                    Email = s.Email,
                    City = s.City,
                    Country = s.Country,
                }).FirstOrDefaultAsync();

                return suppliers;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<SupplierViewModel>> GetSuppliers()
        {
            try
            {
                var suppliers = await _context.Suppliers.Select(s => new SupplierViewModel
                {
                    SupplierId = s.SupplierId,
                    SupplierName = s.SupplierName,
                    MobileNo = s.MobileNo,
                    Email = s.Email,
                    City = s.City,
                    Country = s.Country,
                }).ToListAsync();

                return suppliers;
            }
            catch
            {
                return new List<SupplierViewModel>();
            }
        }

        public async Task<List<SupplierViewModel>> GetSuppliersByCity(string city)
        {
            try
            {
                var suppliers = await _context.Suppliers.Where(x => x.City == city).Select(s => new SupplierViewModel
                {
                    SupplierId = s.SupplierId,
                    SupplierName = s.SupplierName,
                    MobileNo = s.MobileNo,
                    Email = s.Email,
                    City = s.City,
                    Country = s.Country,
                }).ToListAsync();

                return suppliers;
            }
            catch
            {
                return new List<SupplierViewModel>();
            }
        }

        public async Task<List<SupplierViewModel>> GetSuppliersByCountry(string country)
        {
            try
            {
                var suppliers = await _context.Suppliers.Where(x => x.Country == country).Select(s => new SupplierViewModel
                {
                    SupplierId = s.SupplierId,
                    SupplierName = s.SupplierName,
                    MobileNo = s.MobileNo,
                    Email = s.Email,
                    City = s.City,
                    Country = s.Country,
                }).ToListAsync();

                return suppliers;
            }
            catch
            {
                return new List<SupplierViewModel>();
            }
        }

        public async Task<bool> UpdateSupplier(SupplierViewModel supplier)
        {
            try
            {
                var record = _context.Suppliers.Where(w => w.SupplierId == supplier.SupplierId).FirstOrDefault();

                if (record == null) return false;

                record.SupplierName = supplier.SupplierName;
                record.MobileNo = supplier.MobileNo;
                record.Email = supplier.Email;
                record.Country = supplier.Country;
                record.City = supplier.City;
                

                _context.Suppliers.Update(record);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public interface ISupplierRepository
    {
        Task<List<SupplierViewModel>> GetSuppliers();
        Task<SupplierViewModel?> GetSupplierById(int id);
        Task<List<SupplierViewModel>> GetSuppliersByCountry(string country);
        Task<List<SupplierViewModel>> GetSuppliersByCity(string city);
        Task<bool> AddSupplier(SupplierViewModel supplier);
        Task<bool> UpdateSupplier(SupplierViewModel supplier);
        Task<bool> DeleteSupplier(int id);
    }
}
