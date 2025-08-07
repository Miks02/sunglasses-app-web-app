using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunglassesApp.Data.Repositories.Implementations;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.ViewModels;
using SunglassesApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SunglassesApp.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepoistory;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment, ILogger<ProductController> logger, IPromotionRepository promotionRepository)

        {
            _productRepoistory = productRepository;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _promotionRepository = promotionRepository;
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

        public async Task<IActionResult> ProductForm()
        {
            var promotions = await _promotionRepository.GetAll();

            var viewModel = new ProductViewModel
            {
                PromotionsList = promotions.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name,
                }).ToList(),
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            _logger.LogInformation("Funkcija je ispaljena");
            var product = await _productRepoistory.Get(id);
            if (product != null)
            {
                var promotions = await _promotionRepository.GetAll();

                var updatedProduct = new ProductViewModel
                {
                    Id = product.Id,
                    Brand = product.Brand,
                    Model = product.Model,
                    Price = product.Price,             
                    FrameColor = product.FrameColor,
                    FrameType = product.FrameType,
                    LensColor = product.LensColor,
                    Category = product.Category,
                    UVProtection = product.UVProtection,
                    Description = product.Description,
                    PromotionId = product.PromotionId,
                    ImageUrl = product.ImageUrl,
                    IsEdit = true, 


                    PromotionsList = promotions.Select(p => new SelectListItem
                    {
                        Value = p.Id.ToString(),
                        Text = p.Name,
                    }).ToList(),
                };
              
                _logger.LogInformation("Funkcija je uspela");
                return View("ProductForm", updatedProduct);
            }
            TempData["ErrorMessage"] = "Došlo je do greške, proizvod nije pronadjen. ID: " + id;
            return View("ManageProducts");
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductViewModel product)
        {
            var promotions = await _promotionRepository.GetAll();

            if (!ModelState.IsValid)
            {
                product.PromotionsList = promotions.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name,
                }).ToList();

                _logger.LogInformation(product.ToString());

                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    if (state == null) break;
                    if (state.Errors.Any())
                    {
                        _logger.LogInformation($"Greška u polju: {key}");
                        foreach (var error in state.Errors)
                        {
                            _logger.LogInformation($" - {error.ErrorMessage}");
                        }
                    }
                }

                product.IsEdit = true;
                return View("ProductForm", product);
            }

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await product.ImageFile.CopyToAsync(fileStream);
            }

            var updatedProduct = new Product
            {
                Id = product.Id,
                Brand = product.Brand,
                Model = product.Model,
                Price = product.Price,
                FrameColor = product.FrameColor,
                FrameType = product.FrameType,
                LensColor = product.LensColor,
                Category = product.Category,
                UVProtection = product.UVProtection,
                Description = product.Description,
                ImageUrl = "/images/" + uniqueFileName,
                PromotionId = product.PromotionId
            };

            try
            {
                await _productRepoistory.Update(updatedProduct);
                await _productRepoistory.Save();

                TempData["SuccessMessage"] = "Proizvod je uspešno ašuriran";
                return RedirectToAction("ManageProducts");
            } 
            catch(Exception ex)
            {
                _logger.LogError("Greška: " + ex);
            }

            return View("Index");
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel product)
        {
            if(!ModelState.IsValid)
            {
                var promotions = await _promotionRepository.GetAll();

                var viewModel = new ProductViewModel
                {
                    PromotionsList = promotions.Select(p => new SelectListItem
                    {
                        Value = p.Id.ToString(),
                        Text = p.Name,
                    }).ToList(),
                };

                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    if (state == null) break;
                    if (state.Errors.Any())
                    {
                        _logger.LogInformation($"Greška u polju: {key}");
                        foreach (var error in state.Errors)
                        {
                            _logger.LogInformation($" - {error.ErrorMessage}");
                        }
                    }
                }

                TempData["ErrorMessage"] = "Došlo je do greške prilikom dodavanja proizvoda ";
                return View("ProductForm", viewModel);
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
                    PromotionId = product.PromotionId
                
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

                    var promotions = await _promotionRepository.GetAll();

               
                    product.PromotionsList = promotions.Select(p => new SelectListItem
                    {
                        Value = p.Id.ToString(),
                        Text = p.Name
                    }).ToList();

                    return View("ProductForm", product);
                }

            }

            TempData["SuccessMessage"] = "Proizvod je uspešno dodat";
            return RedirectToAction("ProductForm");


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
            return RedirectToAction("ManageProducts");

        }

      

    }
}
