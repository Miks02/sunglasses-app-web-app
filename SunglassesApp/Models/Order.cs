namespace SunglassesApp.Models
{
    public class Order
    {
        public int Id { get; set; } 

        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; } = null!;

        public OrderStatus Status { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

}
