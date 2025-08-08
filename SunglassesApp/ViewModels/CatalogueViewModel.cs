using SunglassesApp.Models;

namespace SunglassesApp.ViewModels
{
    public class CatalogueViewModel
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List <Promotion> Promotions { get; set; } = new List<Promotion>();

        public List<Category> Categories { get; set;} = new List<Category>();

        public List<FrameType> FrameTypes { get; set; } = new List<FrameType>();

        public List<FrameColor> FrameColors { get; set; } = new List<FrameColor>();

        public List <LensColor> LensColors { get; set; } = new List<LensColor>();

        public List<UVProtection> UVProtections { get; set; } = new List<UVProtection>();

        

    }
}
