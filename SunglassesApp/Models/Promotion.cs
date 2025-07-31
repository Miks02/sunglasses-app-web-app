namespace SunglassesApp.Models
{
    public class Promotion
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public int DiscountPercentage { get; set; } 

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Product> Products { get; set; } 
    }

}
