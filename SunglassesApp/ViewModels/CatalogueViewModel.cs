using SunglassesApp.Models;

namespace SunglassesApp.ViewModels
{
    public class CatalogueViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public FilterViewModel Filter { get; set; } = new FilterViewModel();

    }
}
