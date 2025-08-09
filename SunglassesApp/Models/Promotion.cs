using System.ComponentModel.DataAnnotations;

namespace SunglassesApp.Models
{
    public class Promotion
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public int? DiscountPercentage { get; set; }


        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public ICollection<Product> Products { get; set; }  = new List<Product>();
    }

}
