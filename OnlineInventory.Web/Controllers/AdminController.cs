using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineInventory.Repositories.Category;
using OnlineInventory.Repositories.Product;
using OnlineInventory.Repositories.User;
using OnlineInventory.ViewModels;

namespace OnlineInventory.Web.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IProductRepository _productRepo;
        private readonly IUserRepository _userRepo;
        public AdminController(ICategoryRepository categoryRepo, IProductRepository productRepo, IUserRepository userRepo)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            var model = new HomeModel();
            model.Products = _productRepo.CountProducts();
            model.Categories = _categoryRepo.CountCategories();

            return PartialView("_Home",model);
        }

        public IActionResult Profile()
        {
            var model = new ProfileVIewModel();
            return PartialView("_Profile", model);
        }

        public IActionResult Category()
        {
            var categories = _categoryRepo.GetAllCategories();
            return PartialView("_Category", categories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            var model = new CategoryViewModel();
            return PartialView("_AddCategory", model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
