using SunglassesApp.Models;

namespace SunglassesApp.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; } = null!;

        public DateTime AddedAt { get; set; }

        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;

        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

    }
}
