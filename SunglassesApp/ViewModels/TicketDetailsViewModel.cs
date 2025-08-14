using SunglassesApp.Models;

namespace SunglassesApp.ViewModels
{
    public class TicketDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsResolved { get; set; }

        public ApplicationUser Sender { get; set; } = null!;
        public List<TicketMessageVm> Messages { get; set; } = new List<TicketMessageVm>();
    }
}
