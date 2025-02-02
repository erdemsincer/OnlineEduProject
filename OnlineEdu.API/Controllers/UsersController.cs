using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.Dtos.UserDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<AppUser> _userManager,SignInManager<AppUser> _signInManager,IJwtService _JwtService,IMapper _mapper) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) {
                return BadRequest("Bu Email Sisteme Kayıtlı değil");
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
            {
                return BadRequest("Kullanıc adı veye Şifreniz Hatalı");
            }

            var token =await _JwtService.CreateTokenAsync(user);

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var user = _mapper.Map<AppUser>(model);
            if (ModelState.IsValid) { 

                var result= await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);   
                }
                await _userManager.AddToRoleAsync(user, "Student");
                return Ok("Kullanıcı Kaydı Başarılı");

           
            }
            ModelState.AddModelError("", "Bilgileri Kontrol Ediniz");
            return BadRequest();

        }
    }
}
