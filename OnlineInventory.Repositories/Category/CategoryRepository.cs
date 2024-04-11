using OnlineInventory.Models;
using OnlineInventory.ViewModels;
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

        public int CreateCategory(string categoryName)
        {
            try
            {
                var category = new CategoryModel { CategoryName = categoryName };
                _context.Categories.Add(category);
                _context.SaveChanges();
                return category.CategoryId;
            } catch
            {
                return 0;
            }
        }

        public int UpdateCategory(CategoryViewModel model)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(x => x.CategoryId == model.CategoryID);

                if (category == null) return 0;
                category.CategoryName = model.CategoryName;
                _context.Categories.Update(category);
                _context.SaveChanges();
                return category.CategoryId;
            } catch
            {
                return 0;
            }
        }

        public int DeleteCategory(int id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);

                if (category == null) return 0;
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public List<CategoryViewModel> GetAllCategories()
        {
            var categories = _context.Categories.Select(s => new CategoryViewModel
            {
                CategoryID = s.CategoryId,
                CategoryName = s.CategoryName ?? "UnNamed",
            }).OrderBy(x => x.CategoryID).ToList();

            return categories;
        }

        public CategoryViewModel GetCategoryById(int id)
        {
            var category = _context.Categories.Where(x => x.CategoryId == id).Select(s => new CategoryViewModel
            {
                CategoryID = s.CategoryId,
                CategoryName = s.CategoryName,
            }).First();
            return category;
        }
    }

    public interface ICategoryRepository
    {
        public int CountCategories();
        public int CreateCategory(string categoryName);
        public int UpdateCategory(CategoryViewModel category);
        public int DeleteCategory(int id);
        public List<CategoryViewModel> GetAllCategories();
        public CategoryViewModel GetCategoryById(int id);
    }
}
