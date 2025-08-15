using SunglassesApp.Helpers;
using SunglassesApp.Models;

namespace SunglassesApp.ViewModels
{
    public class CatalogueViewModel
    {
        public PaginatedList<Product> Products { get; set; } 
        public IEnumerable<ProductViewModel> productList { get; set; } = new List<ProductViewModel>();
        public FilterViewModel Filter { get; set; } = new FilterViewModel();

    }
}
