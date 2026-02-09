using System.ComponentModel.DataAnnotations;

namespace _10_Fluent_Validation.Models
{
    public class Ogrenci
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Boş Geçilemez")]
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }

    }
}
