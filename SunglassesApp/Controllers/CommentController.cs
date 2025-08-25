using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.ViewModels;
using SunglassesApp.Models;
using SunglassesApp.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace SunglassesApp.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private ILogger<CommentController> _logger;
        private UserManager<ApplicationUser> _userManager;
        public CommentController(ICommentRepository commentRepository,ILogger<CommentController> logger, UserManager<ApplicationUser> userManager)
        {
            _commentRepository = commentRepository;
            _logger = logger;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(ProductDetailsViewModel viewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            ModelState.Remove("CommentVm.User");
            ModelState.Remove("CommentVm.UserId");
            ModelState.Remove("CommentVm.Product");
            ModelState.Remove("ProductVm.FrameColor");
            ModelState.Remove("ProductVm.ImageFile");
            ModelState.Remove("ProductVm.Price");
            ModelState.Remove("ProductVm.Model");
            ModelState.Remove("ProductVm.LensColor");
            ModelState.Remove("ProductVm.FrameType");
            ModelState.Remove("ProductVm.Category");
            ModelState.Remove("ProductVm.UVProtection");
            ModelState.Remove("ProductVm.Gender");
            ModelState.Remove("ProductVm.Brand");
            ModelState.Remove("UserName");
            if (!ModelState.IsValid)
            {
                TempData["CommentErrorMessage"] = "Unesite komentar";
                Helper.LogModelErrors(ModelState, _logger, "");
                _logger.LogInformation("ID proizvoda: " + user);
                return RedirectToAction("ProductDetails", "Customer", new { viewModel.ProductVm!.Id });
            }

            var comment = new Comment
            {
                Content = viewModel.CommentVm!.Content,
                AddedAt = DateTime.Now,
                ProductId = viewModel.ProductVm!.Id,  
                UserId = user!.Id

            };

            _logger.LogInformation("Komentar koji dodajem: " + comment);

            try
            {
                await _commentRepository.Insert(comment);
                await _commentRepository.Save();

                return RedirectToAction("ProductDetails", "Customer", new {id = viewModel.ProductVm.Id});
            }
            catch (Exception ex)
            {
                _logger.LogError("Greška: " + ex);
                TempData["CommentErrorMessage"] = "Došlo je do greške prilikom dodavanja komentara, pokušajte ponovo";
                return RedirectToAction("ProductDetails", "Customer", new { id = viewModel.ProductVm.Id });

            }

        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteComment(int id)
        {
            

            var comment = await _commentRepository.Get(id);

            if (comment == null) throw new KeyNotFoundException("Komentar nije pronadjen");

            try
            {
                await _commentRepository.Delete(comment);
                await _commentRepository.Save();
                return RedirectToAction("ProductDetails", "Customer", new {id = comment.ProductId});
            }
            catch(Exception ex)
            {
                _logger.LogError("Došlo je do greške prilikom brisanja komentara\nGreška: " + ex);
                return RedirectToAction("ProductDetails", "Customer", new { id = comment.ProductId });
            }
        }
    }
}
