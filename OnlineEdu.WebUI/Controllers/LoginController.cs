using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using OnlineEdu.WebUI.Dtos.LoginDtos;
using OnlineEdu.WebUI.Dtos.UserDto;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
            var response=await result.Content.ReadFromJsonAsync<LoginResponseDto>();
            var token= handler.ReadJwtToken(response.Token);
            var claims = token.Claims.ToList();
            if (response.Token != null) {
                claims.Add(new Claim("Token", response.Token));
                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                var authProps = new AuthenticationProperties
                {
                    ExpiresUtc = response.ExpireDate
                    IsPersistent = true
                };
                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            return View(userLoginDto);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
