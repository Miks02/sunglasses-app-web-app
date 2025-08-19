using SunglassesApp.Models;

namespace SunglassesApp.ViewModels
{
    public class RecommendationViewModel
    {
        public List<Message> Messages { get; set; } = new List<Message>();
        public Message? Message { get; set; } 
        public int ProductId { get; set; }
    }
}
