using System.ComponentModel.DataAnnotations;

namespace SunglassesApp.Models
{
    public class SupportTicketMessage
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public SupportTicket Ticket { get; set; } = null!;

        public string SenderId { get; set; } = null!;
        public ApplicationUser Sender { get; set; } = null!;

        public string Content { get; set; } = null!;

        public bool IsFromAdmin { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime SentAt { get; set; } 
    }
}
