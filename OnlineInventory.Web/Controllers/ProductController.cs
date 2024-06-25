﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineInventory.Repositories.Category;
using OnlineInventory.Repositories.Product;
using OnlineInventory.Repositories.Supplier;
using OnlineInventory.ViewModels;

namespace OnlineInventory.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        private readonly ICategoryRepository _cateRepo;
        private readonly ISupplierRepository _suppRepo;

        public ProductController(IProductRepository repo, ICategoryRepository cateRepo, ISupplierRepository suppRepo)
        {
            _repo = repo;
            _cateRepo = cateRepo;
            _suppRepo = suppRepo;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _repo.GetProducts();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            ViewBag.Categories = _cateRepo.GetAllCategories();
            ViewBag.Suppliers = await _suppRepo.GetSuppliers();
            return PartialView("_AddProduct");
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_AddProduct", ModelState);
            }

            if (product.ImageFile != null)
            {
                product.ProductImage = await UploadImage(product.ImageFile, product.ProductName ?? "");
            }
            await _repo.AddProduct(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            ViewBag.Categories = _cateRepo.GetAllCategories();
            ViewBag.Suppliers = await _suppRepo.GetSuppliers();
            var product = await _repo.GetProductById(id);
            return PartialView("_UpdateProduct", product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_UpdateProduct", ModelState);
            }

            if (product.ImageFile != null)
            {
                DeleteImage(product.ProductImage);
                product.ProductImage = await UploadImage(product.ImageFile, product.ProductName ?? "");
            }
            await _repo.UpdateProduct(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _repo.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        private async Task<string?> UploadImage(IFormFile file, string name)
        {
            var filename = "product_" + string.Format("{0 : ddMMyyyyhhmmss}", DateTime.Now) + name.Replace(" ", "") + Path.GetExtension(file.FileName);

            if (!Directory.Exists(@"wwwroot\upload\product"))
            {
                Directory.CreateDirectory(@"wwwroot\upload\product");
            }

            var filepath = Path.Combine(@"wwwroot\upload\product", filename);

            using (FileStream fs = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return Path.Combine(@"upload\product", filename);
        }

        private bool DeleteImage(string filepath)
        {
            try
            {

                if (System.IO.File.Exists(@"wwwroot\" + filepath))
                {
                    System.IO.File.Delete(@"wwwroot\" + filepath);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
