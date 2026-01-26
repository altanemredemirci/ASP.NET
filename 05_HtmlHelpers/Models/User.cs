using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace _05_HtmlHelpers.Models
{
    public class User
    {
        [Required(ErrorMessage ="İsim alanı boş geçilemez.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Yaş alanı boş geçilemez.")]
        [Range(1,120,ErrorMessage ="Yaş aralığı hatalı.")]
        public int Age { get; set; }

        public bool IsSubscribed { get; set; }

        [Required(ErrorMessage ="Cinsiyet alanı boş geçilemez.")]
        public string Gender { get; set; }

        [Required(ErrorMessage ="Ülke alanı boş geçilemez.")]
        public string Country { get; set; }

        public IEnumerable<SelectListItem> CountryList { get; set; } = new List<SelectListItem>();
    }
}
