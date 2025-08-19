using SunglassesApp.Models;
using System.ComponentModel.DataAnnotations;
namespace SunglassesApp.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductViewModel? ProductVm { get; set; }
        public Rating? RatingVm { get; set; }
        public CommentViewModel? CommentVm { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();
        public int Quantity { get; set; } = 1;

        [Required(ErrorMessage = "Unesite korisničko ime")]
        public string UserName { get; set; } = null!;
    }
}
