using _11_AutoMapper.Dto;
using _11_AutoMapper.Models;
using AutoMapper;

namespace _11_AutoMapper.MappingProfile
{
    public class UserProfile:Profile
    {
        //User=> Userdto dönüşümünü tanımlıyoruz.
        //Burada FirstName ve LastName FullName e maplıyoruz.


        public UserProfile()
        {
            //
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
                $"{src.FirstName} {src.LastName}"));

            // UserDto => User dönüşümünü tanılıyoruz (isteğe bağlı)
            // iki taraflı dönüşüm olabilir
            //CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
