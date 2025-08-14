using System.ComponentModel.DataAnnotations;

namespace SunglassesApp.ViewModels
{
    public class TicketMessageVm
    {
        public bool IsFromAdmin { get; set; }

        [Required(ErrorMessage = "Unesite poruku")]
        public string Content { get; set; } = null!;
        public DateTime SentAt { get; set; }
    }
}
