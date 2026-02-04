using _10_Fluent_Validation.ViewModels;
using FluentValidation;

namespace _10_Fluent_Validation.Validators
{
    //Fluentvalidation paketi kuruldu.
    public class HomeViewModelValidator:AbstractValidator<HomeViewModel>
    {
        //Proje içerisinde bulunan nesne tabanlı classların hata mesajları yazıldı.
        public HomeViewModelValidator()
        {
            RuleFor(vm => vm.KisiNesnesi).NotNull().WithMessage("Kişi bilgileri boş bırakılamaz.");
            RuleFor(vm => vm.AdresNesnesi).NotNull().WithMessage("Adres bilgileri boş bırakılamaz.");

            RuleFor(vm => vm.KisiNesnesi.Ad)
                .NotNull().WithMessage("Ad alanı boş bırakılamaz")
                .NotEmpty().WithMessage("Ad alanı boş bırakılamaz")
                .Length(1, 60).WithMessage("Ad alanı 1 ile 60 karakter arasında olmalıdır");

            RuleFor(vm => vm.KisiNesnesi.Soyad)
               .NotNull().WithMessage("Soyad alanı boş bırakılamaz")
               .NotEmpty().WithMessage("Soyad alanı boş bırakılamaz")
               .Length(1, 60).WithMessage("Soyad alanı 1 ile 60 karakter arasında olmalıdır");

            RuleFor(vm => vm.KisiNesnesi.Yas)
                .GreaterThan(0).WithMessage("Yaş 0'dan büyük olmalıdır.")
                .LessThan(120).WithMessage("Yaş 120'den küçük olmalıdır.");

            RuleFor(vm => vm.AdresNesnesi.AdresTanimi)
                .NotNull().WithMessage("AdresTanımı alanı boş bırakılamaz")
               .NotEmpty().WithMessage("AdresTanımı alanı boş bırakılamaz")
               .Length(1, 100).WithMessage("AdresTanımı alanı 1 ile 100 karakter arasında olmalıdır");

            RuleFor(vm => vm.AdresNesnesi.Sehir)
               .NotNull().WithMessage("Sehir alanı boş bırakılamaz")
              .NotEmpty().WithMessage("Sehir alanı boş bırakılamaz")
              .Length(1, 50).WithMessage("Sehir alanı 1 ile 50 karakter arasında olmalıdır");
        }

    }
}
