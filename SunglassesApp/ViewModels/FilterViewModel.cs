namespace SunglassesApp.ViewModels
{
    public class FilterViewModel
    {
        public List<int>? Categories { get; set; }
        public List<string>? Brands { get; set; }
        public List<int>? FrameColors { get; set; }
        public List<int>? LensColors { get; set; }
        public List<int>? UVProtections { get; set; }
        public List<int>? Genders { get; set; }
        public List<int>? FrameTypes { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

    }
}
