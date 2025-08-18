using SunglassesApp.Models;
namespace SunglassesApp.ViewModels
{
    public class CheckoutViewModel
    {
        public Cart Cart { get; set; } = null!;
        
        public string City { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string ShippingAddress { get; set; } = null!;
    }
}
