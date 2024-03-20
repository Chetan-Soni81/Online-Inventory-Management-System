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

        public int CountProducts()
        {
            return _context.Products.Count();
        }
    }
    public interface IProductRepository
    {
        public int CountProducts();
    }
}
