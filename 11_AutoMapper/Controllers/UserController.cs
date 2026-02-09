using _11_AutoMapper.Dto;
using _11_AutoMapper.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _11_AutoMapper.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper; //AutoMapper nesnesi, nesne dönüşümleri için kullanılır.


        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //Örnek bir User nesnesi oluşturuldu
            User user = new User()
            {
                Id = 1,
                FirstName = "Altan Emre",
                LastName = "Demirci",
                Email = "altanemre@gmail.com"
            };

            //User => UserDTO dönüşümünü gerçekleştirdik.
            //AutoMapper kullanılarak User nesnesi UserDTO nesnesine dönüştürüldü
            var userDto = _mapper.Map<UserDto>(user);

            
            return View(userDto);
        }
    }
}
