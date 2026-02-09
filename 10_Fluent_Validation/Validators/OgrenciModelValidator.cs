using _10_Fluent_Validation.Models;
using FluentValidation;

namespace _10_Fluent_Validation.Validators
{
    //Nuget Package Manager üzerinden -> FluentValidation.AspNetCore paketini kurduk
    public class OgrenciModelValidator:AbstractValidator<Ogrenci>
    {
        public OgrenciModelValidator()
        {
            RuleFor(og => og.Ad).NotEmpty().WithMessage("Ad kısmı boş geçilemez.");
            RuleFor(og => og.Ad).NotNull().WithMessage("Ad kısmı boş geçilemez.");            
            RuleFor(og => og.Ad).Length(3, 30).WithMessage("Ad uzunluğu en az 3 en fazla 30 karakter olabilir.");


            RuleFor(og => og.Soyad).NotNull().WithMessage("Soyad kısmı boş geçilemez.");
            RuleFor(og => og.Soyad).NotEmpty().WithMessage("Soyad kısmı boş geçilemez.");
            RuleFor(og => og.Soyad).Length(3, 30).WithMessage("Soyad uzunluğu en az 3 en fazla 30 karakter olabilir.");
            
            RuleFor(og => og.Adres).NotNull().WithMessage("Adres kısmı boş geçilemez.");
            RuleFor(og => og.Adres).NotEmpty().WithMessage("Adres kısmı boş geçilemez.");
            RuleFor(og => og.Adres).Length(10, 100).WithMessage("Adres uzunluğu en az 10 en fazla 100 karakter olabilir.");

            RuleFor(og => og.Telefon).NotNull().WithMessage("Telefon kısmı boş geçilemez.");
            RuleFor(og => og.Telefon).NotEmpty().WithMessage("Telefon kısmı boş geçilemez.");
            RuleFor(og => og.Telefon).Length(11, 13).WithMessage("Telefon uzunluğu en az 11 en fazla 13 rakam olabilir.");
        }
    }
}
