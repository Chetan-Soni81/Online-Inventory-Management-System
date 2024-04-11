using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineInventory.Repositories.Category;
using OnlineInventory.ViewModels;

namespace OnlineInventory.Web.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class CategoryController: Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepo.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            var model = new CategoryViewModel();
            return PartialView("_AddCategory", model);
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_AddCategory", ModelState);
            }

            var i = _categoryRepo.CreateCategory(model.CategoryName);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory()
        {
            var model = new CategoryViewModel();
            return PartialView("_UpdateCategory", model);
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                return PartialView("_UpdateCategory", ModelState);
            }

            _categoryRepo.UpdateCategory(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
