using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineInventory.Repositories.Warehouse;
using OnlineInventory.ViewModels;

namespace OnlineInventory.Web.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseRepository _repo;

        public WarehouseController(IWarehouseRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var warehouses = _repo.GetAllWarehouses();
            return PartialView("_Warehouse",warehouses);
        }

        [HttpGet]
        public IActionResult AddWarehouse()
        {
            var model = new WarehouseViewModel();
            return PartialView("_AddWarehouse",model);
        }

        [HttpPost]
        public IActionResult AddWarehouse(WarehouseViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return PartialView("_AddWarehouse", ModelState);
            }

            var i = _repo.CreateWarehouse(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateWarehouse(int id)
        {
            var model = _repo.GetWarehouseById(id);
            return PartialView("_UpdateWarehouse", model);
        }

        [HttpPost]
        public IActionResult UpdateWarehouse(WarehouseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_AddWarehouse", ModelState);
            }

            var i = _repo.UpdateWarehouse(model);

            return RedirectToAction("Index");
        }
    }
}
