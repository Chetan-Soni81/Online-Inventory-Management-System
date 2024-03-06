using Microsoft.AspNetCore.Mvc;
using OnlineInventory.ViewModels;
using OnlineInventory.Web.Models;
using System.Diagnostics;

namespace OnlineInventory.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return PartialView("_Login", model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model) {
            return RedirectToAction();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
