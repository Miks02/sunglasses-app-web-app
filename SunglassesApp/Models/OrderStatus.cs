using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SunglassesApp.Models
{
    public enum OrderStatus
    {
        [Display(Name = "U obradi")]
        Pending,
        [Display(Name = "Poslata")]
        Shipped,
        [Display(Name = "Isporučena")]
        Delivered,
        [Display(Name = "Otkazana")]
        Cancelled
    }

}
