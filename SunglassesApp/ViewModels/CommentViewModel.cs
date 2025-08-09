using SunglassesApp.Models;
using System.ComponentModel.DataAnnotations;

namespace SunglassesApp.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = null!;

        public DateTime AddedAt { get; set; }

        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;

        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;


    }
}
