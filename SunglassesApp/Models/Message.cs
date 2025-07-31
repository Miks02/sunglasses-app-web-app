namespace SunglassesApp.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string SenderId { get; set; } = null!;
        public ApplicationUser Sender { get; set; } = null!;

        public string Subject { get; set; } = null!;
        public string Content { get; set; } = null!;

        public DateTime SentAt { get; set; }
        public bool IsAnswered { get; set; }
    }

}
