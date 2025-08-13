using SunglassesApp.Models;
namespace SunglassesApp.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductViewModel? ProductVm { get; set; }
        public Rating? RatingVm { get; set; }
        public CommentViewModel? CommentVm { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
