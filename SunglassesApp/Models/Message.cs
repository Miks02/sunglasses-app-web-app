namespace SunglassesApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderId { get; set; } = null!;
        public string RecieverId { get; set; } = null!;
        public string MessageContent { get; set; } = null!;
        public int ProductId { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
