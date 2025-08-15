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


        public bool IsEmpty =>
            (Categories == null || Categories.Count == 0) &&
            (Brands == null || Brands.Count == 0) &&
            (Genders == null || Genders.Count == 0) &&
            (FrameTypes == null || FrameTypes.Count == 0) &&
            (FrameColors == null || FrameColors.Count == 0) &&
            (LensColors == null || LensColors.Count == 0) &&
            (UVProtections == null || UVProtections.Count == 0);

    }


}
