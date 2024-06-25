using Microsoft.EntityFrameworkCore;
using OnlineInventory.Models;
using OnlineInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProduct(ProductViewModel product)
        {
            try
            {
                var record = new ProductModel
                {
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductImage = product.ProductImage,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    SupplierId = product.SupplierId,
                };

                _context.Products.Add(record);

                await _context.SaveChangesAsync();

                return true;
            } catch
            {
                return false;
            }
        }

        public int CountProducts()
        {
            return _context.Products.Count();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(w => w.ProductId == id);

                if (product == null) return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            } catch
            {
                return false;
            }
        }

        public async Task<ProductViewModel?> GetProductById(int id)
        {
            var products = await _context.Products.Where(w => w.ProductId == id).Include(i => i.Category).Include(i => i.Supplier).Select(s =>
            new ProductViewModel
            {
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                ProductImage = s.ProductImage,
                Price = s.Price,
                ProductDescription = s.ProductDescription,
                CategoryId = s.CategoryId,
                SupplierId = s.SupplierId,
                SupplierName = s.Supplier == null ? "" : s.Supplier.SupplierName,
                CategoryName = s.Category == null ? "" : s.Category.CategoryName
            }).FirstOrDefaultAsync();

            return products;
        }

        public async Task<List<ProductViewModel>> GetProducts()
        {
            var products = await _context.Products.Include(i => i.Category).Include(i => i.Supplier).Select(s =>
            new ProductViewModel
            {
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                ProductImage = s.ProductImage,
                Price = s.Price,
                ProductDescription = s.ProductDescription,
                CategoryId = s.CategoryId,
                SupplierId = s.SupplierId,
                SupplierName = s.Supplier!.SupplierName,
                CategoryName = s.Category!.CategoryName
            }).ToListAsync();

            return products;
        }

        public async Task<List<ProductViewModel>> GetProductsByCategory(int id)
        {
            var products = await _context.Products.Where(w => w.CategoryId == id).Include(i => i.Category).Include(i => i.Supplier).Select(s =>
            new ProductViewModel
            {
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                ProductImage = s.ProductImage,
                Price = s.Price,
                ProductDescription = s.ProductDescription,
                CategoryId = s.CategoryId,
                SupplierId = s.SupplierId,
                SupplierName = s.Supplier == null ?  "" :  s.Supplier.SupplierName,
                CategoryName = s.Category == null ? "" : s.Category.CategoryName
            }).ToListAsync();

            return products;
        }

        public async Task<List<ProductViewModel>> GetProductsBySupplier(int id)
        {
            var products = await _context.Products.Where(w => w.SupplierId == id).Include(i => i.Category).Include(i => i.Supplier).Select(s =>
            new ProductViewModel
            {
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                ProductImage = s.ProductImage,
                Price = s.Price,
                ProductDescription = s.ProductDescription,
                CategoryId = s.CategoryId,
                SupplierId = s.SupplierId,
                SupplierName = s.Supplier == null ? "" : s.Supplier.SupplierName,
                CategoryName = s.Category == null ? "" : s.Category.CategoryName
            }).ToListAsync();

            return products;
        }

        public async Task<bool> UpdateProduct(ProductViewModel product)
        {
            try
            {
                var record = await _context.Products.FirstOrDefaultAsync(w => w.ProductId == product.ProductId);

                if (record == null) return false;

                record.ProductName = product.ProductName;
                record.ProductDescription = product.ProductDescription;
                record.ProductImage = product.ProductImage;
                record.Price = product.Price;
                record.CategoryId = product.CategoryId;
                record.SupplierId = product.SupplierId;

                _context.Products.Update(record);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<OptionViewModel>> GetProductList()
        {
            try
            {
                var options = await _context.Products.Select(s => new OptionViewModel
                {
                    Value= s.ProductId,
                    Label= s.ProductName ?? ""
                }).ToListAsync();

                return options;
            } catch
            {
                return new List<OptionViewModel>();
            }
        }
    }
    public interface IProductRepository
    {
        public int CountProducts();

        Task<List<ProductViewModel>> GetProducts();
        Task<List<OptionViewModel>> GetProductList();
        Task<ProductViewModel?> GetProductById(int id);
        Task<List<ProductViewModel>> GetProductsByCategory(int id);
        Task<List<ProductViewModel>> GetProductsBySupplier(int id);
        Task<bool> AddProduct(ProductViewModel product);
        Task<bool> UpdateProduct(ProductViewModel product);
        Task<bool> DeleteProduct(int id);
    }
}
