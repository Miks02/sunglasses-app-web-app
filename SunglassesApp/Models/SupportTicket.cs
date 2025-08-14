namespace SunglassesApp.Models
{
    public class SupportTicket
    {
        public int Id { get; set; }

        public string SenderId { get; set; } = null!;
        public ApplicationUser Sender { get; set; } = null!;

        public string Subject { get; set; } = null!;

        public DateTime SentAt { get; set; }
        public bool isResolved { get; set; }

        public List<SupportTicketMessage> Messages { get; set; } = new List<SupportTicketMessage>();
    }

}
