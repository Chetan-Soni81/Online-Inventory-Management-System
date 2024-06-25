using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using OnlineInventory.Repositories.Product;
using OnlineInventory.Repositories.Stock;
using OnlineInventory.Repositories.Warehouse;
using OnlineInventory.ViewModels;

namespace OnlineInventory.Web.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        private readonly IStockRepository _repo;
        private readonly IProductRepository _productRepo;
        private readonly IWarehouseRepository _warehouseRepo;
        public StockController(IStockRepository repo, IProductRepository productRepo, IWarehouseRepository warehouseRepo)
        {
            _repo = repo;
            _productRepo = productRepo;
            _warehouseRepo = warehouseRepo;
        }

        public async Task<IActionResult> Index()
        {
            var stocks = await _repo.GetStocks();

            return View(stocks);
        }

        [HttpGet]
        public async Task<IActionResult> AddStock()
        {
            ViewBag.Products = await _productRepo.GetProductList();
            ViewBag.Warehouses = await _warehouseRepo.GetWarehouseList();

            return PartialView("_AddStock");
        }

        [HttpPost]
        public async Task<IActionResult> AddStock(StockViewModel stock)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_AddStock",ModelState);
            }

            await _repo.AddStock(stock);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStock(int id)
        {
            var stock = await _repo.GetStockById(id);
            ViewBag.Products = await _productRepo.GetProductList();
            ViewBag.Warehouses = await _warehouseRepo.GetWarehouseList();

            return PartialView("_UpdateStock", stock);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStock(StockViewModel stock)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_UpdateStock", ModelState);
            }

            await _repo.UpdateStock(stock);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteStock(int id)
        {
            await _repo.DeleteStock(id);
            return RedirectToAction("Index");
        }
    } 
}
