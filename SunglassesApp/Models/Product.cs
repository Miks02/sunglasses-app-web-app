using System.ComponentModel.DataAnnotations;

namespace SunglassesApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Model { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Name { get { return $"{Brand} {Model}"; } } 
        public decimal? Price { get; set; }
        public decimal? PromoPrice { get; set; }
        public FrameType? FrameType { get; set; } 
        public LensColor? LensColor { get; set; } 
        public FrameColor? FrameColor { get; set; } 
        public Category? Category { get; set; } 
        public UVProtection? UVProtection { get; set; } 



        public Gender? Gender { get; set; }

        public string Brand { get; set; } = null!;
        public string? Description { get; set; }

        public int TimesBought { get; set; } = 0;

        public int? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

}
