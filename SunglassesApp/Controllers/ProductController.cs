using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunglassesApp.Data.Repositories.Implementations;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.ViewModels;
using SunglassesApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace SunglassesApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepoistory;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment, ILogger<ProductController> logger)

        {
            _productRepoistory = productRepository;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ManageProducts()
        {
            var products = await _productRepoistory.GetAll();

            return View(products);
        }
        [HttpGet]

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditProduct()
        {
            return View("EditProduct");
        }
        

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }

            

            if(product.ImageFile != null && product.ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }
                var newProduct = new Product
                {
                    Brand = product.Brand,
                    Model = product.Model,
                    Price = product.Price,
                    ImageUrl = "/images/" + uniqueFileName,
                    FrameColor = product.FrameColor,
                    FrameType = product.FrameType,
                    LensColor = product.LensColor,
                    Category = product.Category,
                    UVProtection = product.UVProtection,
                    Description = product.Description,
                };
                try
                {
                    await _productRepoistory.Insert(newProduct);
                    await _productRepoistory.Save();

                    
                }
                catch (Exception ex)
                {
                    _logger.LogError("Greška: " + ex);
                    TempData["ErrorMessage"] = "Došlo je do greške prilikom dodavanja proizvoda";
                    ModelState.AddModelError(string.Empty, "Došlo je do greške prilikom dodavanja proizvoda");
                    return View(product);
                }

            }

            TempData["SuccessMessage"] = "Proizvod je uspešno dodat";
            return RedirectToAction("AddProduct");


        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepoistory.Get(id);
            if(product != null)
            {
                try
                {
                    await _productRepoistory.Delete(id);
                    await _productRepoistory.Save();
                    TempData["SuccessMessage"] = "Proizvod je uspešno obrisan";
                    return RedirectToAction("ManageProducts");
                } catch (Exception ex)
                {
                    _logger.LogError("Greška: " + ex);
                    TempData["ErrorMessage"] = "Došlo je do greške prilikom brisanja proizvoda";
                    return RedirectToAction("ManageProducts");
                }

            }
            TempData["ErrorMessage"] = "Greška prilikom brisanja proizvoda. Proizvod nije pronadjen";
            return RedirectToAction("ManageUsers");

        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _productRepoistory.Get(id);
            if(product != null)
            {
                try
                {
                    await _productRepoistory.Update(product);
                    await _productRepoistory.Save();
                    TempData["SuccessMessage"] = "Proizvod je uspešno ažuriran";
                    return RedirectToAction("ManageProducts");
                } catch(Exception ex)
                {
                    TempData["ErrorMessage"] = "Greška prilikom ažuriranja proizvoda " + ex;
                    return RedirectToAction("ManageProducts");
                }
            }
            
            TempData["ErrorMessage"] = "Greška prilikom ažuriranja proizvoda. Proizvod nije pronadjen";
            return NotFound();
        }

    }
}
