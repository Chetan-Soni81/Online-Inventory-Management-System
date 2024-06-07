using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using OnlineInventory.Repositories.Supplier;
using OnlineInventory.ViewModels;
using System.Diagnostics.CodeAnalysis;

namespace OnlineInventory.Web.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _repo;
        public SupplierController(ISupplierRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var suppliers = await _repo.GetSuppliers();
            return View(suppliers);
        }
        [HttpGet]
        public IActionResult AddSupplier()
        {
            return PartialView("_AddSupplier");
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier(SupplierViewModel supplier)
        {
            await _repo.AddSupplier(supplier);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSupplier(int id)
        {
            var supplier = await _repo.GetSupplierById(id);
            return PartialView("_UpdateSupplier",supplier);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSupplier(SupplierViewModel supplier)
        {
            await _repo.UpdateSupplier(supplier);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            await _repo.DeleteSupplier(id);
            return RedirectToAction("Index");
        }
    }
}
