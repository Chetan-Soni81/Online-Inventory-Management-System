using Microsoft.AspNetCore.Mvc;

namespace OnlineInventory.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
