namespace SunglassesApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        // Kategorije
        public string FrameType { get; set; } = null!;
        public string LensColor { get; set; } = null!;
        public string FrameColor { get; set; } = null!;
        public string Category { get; set; } = null!;

        public string Brand { get; set; } = null!;
        public string UVProtection { get; set; } = null!;

        // Akcije
        public int? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

}
