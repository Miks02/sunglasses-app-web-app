using SunglassesApp.Models;
using System.ComponentModel.DataAnnotations;

namespace SunglassesApp.ViewModels
{
    public class PromotionViewModel
    {
        public int Id { get; set; }
        public bool IsEdit { get; set; } = false;

        [Display(Name = "Naziv promocije")]
        [Required(ErrorMessage = "Unesite naziv promocije")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Naziv promocije ne sme biti kraći od 5 i duži od 30 karaktera")]
        public string Name { get; set; } = null!;

        [Display(Name = "Procenat akcije")]
        [Required(ErrorMessage = "Unesite procenat akcije")]
        [Range(10,100, ErrorMessage = "Procenat akcije mora biti izmedju 10% i 100%")]
        public int? DiscountPercentage { get; set; }

        [Display(Name = "Početak promocije")]
        [Required(ErrorMessage = "Početni datum je obavezan")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Kraj promocije")]
        [Required(ErrorMessage = "Krajnji datum je obavezan")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

  
    }
}
