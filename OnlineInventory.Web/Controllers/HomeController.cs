using Microsoft.AspNetCore.Mvc;
using OnlineInventory.Repositories.Role;
using OnlineInventory.Repositories.User;
using OnlineInventory.ViewModels;
using OnlineInventory.Web.Models;
using System.Diagnostics;

namespace OnlineInventory.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoleRepository _roleRepo;
        private readonly IUserRepository _userRepo;
        public HomeController(ILogger<HomeController> logger, IRoleRepository roleRepo, IUserRepository userRepo)
        {
            _logger = logger;
            _roleRepo = roleRepo;
            _userRepo = userRepo;
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
            if(!ModelState.IsValid)
            {
                return PartialView("_Login", model);
            }

            var id = _userRepo.LoginUser(model);

            if (id.UserId == 0) { 
                model.ErrorMessage = "* Invalid Credentials";
                return PartialView("_Login", model);
            }

            return Ok("<script>document.location.pathname = '/admin';</script>");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet] 
        public IActionResult Register() {
            var register = new RegisterViewModel();
            return PartialView("_Register", register);
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) {
                return PartialView("_Register", model);
            }

            var id = _userRepo.CreateUser(model);

            if (id == 0) return PartialView("_Register", model);

            var details = new RegisterDetailViewModel { UserId = id };
            return PartialView("_Register2", details);
        }

        [HttpPost]
        public IActionResult Register2(RegisterDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Register2", model);
            }

            var id = _userRepo.CreateUserDetails(model);

            if (id == 0) return PartialView("_Register", new RegisterViewModel());

            return PartialView("_Login", new LoginViewModel());
        }

        public IActionResult Roles()
        {
            var roles = _roleRepo.GetAllRoles();
            return PartialView("_RolesDDL",roles);
        }
    }
}
