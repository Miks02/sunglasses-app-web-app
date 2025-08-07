using Microsoft.AspNetCore.Mvc.Rendering;
using SunglassesApp.Models;
using System.ComponentModel.DataAnnotations;

namespace SunglassesApp.ViewModels
{
    public class ProductViewModel
    {
        public bool IsEdit { get; set; } = false;

        public int Id { get; set; }

        [Required(ErrorMessage = "Unesite model naočara")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Model naočara mora biti izmedju 3 i 20 karaktera")]
        public string Model { get; set; } = null!;

        [Required(ErrorMessage = "Unesite brend naočara")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Brend naočara mora biti izmedju 3 i 20 karaktera")]
        public string Brand { get; set; } = null!;

        [Required(ErrorMessage = "Unesite sliku naočara.")]
        public IFormFile ImageFile { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Unesite cenu naočara")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cena mora biti veća od 0.")]
        public decimal? Price { get; set; }

        
        [Required(ErrorMessage = "Izaberite tip okvira")]
        public FrameType? FrameType { get; set; }

        [Required(ErrorMessage = "Izaberite boju stakala")]  
        public LensColor? LensColor { get; set; }

        [Required(ErrorMessage = "Izaberite boju okvira")]      
        public FrameColor? FrameColor { get; set; }

        [Required(ErrorMessage = "Izaberite kategoriju")]
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Izaberite nivo UV zaštite")]
        public UVProtection? UVProtection { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Promocije")]
        public int? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        public List<SelectListItem>? PromotionsList { get; set; }

    }
}
