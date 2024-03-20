using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int CountCategories()
        {
            return _context.Categories.Count();
        }
    }

    public interface ICategoryRepository
    {
        public int CountCategories();
    }
}
