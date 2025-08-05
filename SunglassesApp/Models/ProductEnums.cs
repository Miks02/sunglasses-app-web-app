using System.ComponentModel.DataAnnotations;

namespace SunglassesApp.Models
{
    public enum FrameType
    {
        [Display(Name = "Okrugle")]
        Round,
        [Display(Name = "Kvadratne")]
        Square,
        [Display(Name = "Pravougaone")]
        Rectangle,
        [Display(Name = "Avijator")]
        Aviator,
        [Display(Name = "Mačje oči")]
        CatEye,
        [Display(Name = "Vejferer")]
        Wayfarer,
        [Display(Name = "Ovalne")]
        Oval,
        [Display(Name = "Leptir")]
        Butterfly,
        [Display(Name = "Bez okvira")]
        Rimless
    }

    public enum FrameColor
    {
        [Display(Name = "Crna")]
        Black,
        [Display(Name = "Tirkizna")]
        Tortoise,
        [Display(Name = "Srebrna")]
        Silver,
        [Display(Name = "Zlatna")]
        Gold,
        [Display(Name = "Plava")]
        Blue,
        [Display(Name = "Braon")]
        Brown,
        [Display(Name = "Crvena")]
        Red,
        [Display(Name = "Providna")]
        Transparent
    }

    public enum LensColor
    {
        [Display(Name = "Crna")]
        Black,
        [Display(Name = "Tirkizna")]
        Tortoise,
        [Display(Name = "Srebrna")]
        Silver,
        [Display(Name = "Zlatna")]
        Gold,
        [Display(Name = "Plava")]
        Blue,
        [Display(Name = "Braon")]
        Brown,
        [Display(Name = "Crvena")]
        Red,
        
    }

    public enum Category
    {
        [Display(Name = "Moda")]
        Fashion,
        [Display(Name = "Vožnja")]
        Driving,
        [Display(Name = "Sport")]
        Sports,
        [Display(Name = "Za decu")]
        Kids,
        [Display(Name = "Svakodnevne")]
        Everyday
    }

    public enum UVProtection
    {
        [Display(Name = "Nema")]
        None,
        [Display(Name = "UV-100")]
        UV100,
        [Display(Name = "UV-200")]
        UV200,
        [Display(Name = "UV-400")]
        UV400,
        [Display(Name = "Polarizovane")]
        Polarized
    }
}
