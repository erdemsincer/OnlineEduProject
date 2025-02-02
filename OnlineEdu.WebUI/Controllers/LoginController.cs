using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.UserDto;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services;
using System.IdentityModel.Tokens.Jwt;

namespace OnlineEdu.WebUI.Controllers
{
    public class LoginController : Controller
    {
       private readonly HttpClient _httpClient=HttpClientInstance.CreateClient();

        [HttpGet]
        public IActionResult SignIn()
        {
            return View(); // Kullanıcıya giriş formunu göster
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            var result=await _httpClient.PostAsJsonAsync("users/login", userLoginDto);
            if (!result.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View(userLoginDto);
            }
            var handler= new JwtSecurityTokenHandler();
            var token = await result.Content.ReadAsStringAsync();
        }
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
