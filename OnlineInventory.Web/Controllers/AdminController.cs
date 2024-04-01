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

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
