using SunglassesApp.DataTransferObjects;
using SunglassesApp.Models;
using System.Collections.Generic;
namespace SunglassesApp.ViewModels
{
    public class AdminPanelViewModel
    {
        public IEnumerable<Product> products { get; set; } = new List<Product>();

        public int UserCount { get; set; }
        public int OrdersCount { get; set; }
        public List<BrandRatingDTO> Brands { get; set; } = new List<BrandRatingDTO>();
    }
}
