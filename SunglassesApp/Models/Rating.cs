namespace SunglassesApp.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public int Score { get; set; } 
        public string? Comment { get; set; }
        public DateTime DateRated { get; set; }
    }

}
