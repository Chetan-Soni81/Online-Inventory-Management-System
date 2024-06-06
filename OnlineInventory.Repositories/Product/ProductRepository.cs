using OnlineInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<bool> AddProduct(ProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public int CountProducts()
        {
            return _context.Products.Count();
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductViewModel>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductViewModel>> GetProductsByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductViewModel>> GetProductsBySupplier(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(ProductViewModel product)
        {
            throw new NotImplementedException();
        }
    }
    public interface IProductRepository
    {
        public int CountProducts();

        Task<List<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetProductById(int id);
        Task<List<ProductViewModel>> GetProductsByCategory(int id);
        Task<List<ProductViewModel>> GetProductsBySupplier(int id);
        Task<bool> AddProduct(ProductViewModel product);
        Task<bool> UpdateProduct(ProductViewModel product);
        Task<bool> DeleteProduct(int id);
    }
}
