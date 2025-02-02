using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.UserDto;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services;

namespace OnlineEdu.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HttpClient _client=HttpClientInstance.CreateClient();
    

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDto userRegisterDto)
        {
         

            var result = await _client.PostAsJsonAsync("users/register", userRegisterDto);
            if (!ModelState.IsValid)
            {
                return View(userRegisterDto); // Model doğrulama hatalarını tekrar göster
            }
            if (!result.IsSuccessStatusCode)
            {
                var errors = await result.Content.ReadFromJsonAsync<List<RegisterResponseDto>>();
                foreach (var item in errors)
                {
                    ModelState.AddModelError("", item.Description); // Hata mesajlarını göster
                }
                return View(userRegisterDto);
            }

            TempData["SuccessMessage"] = "Kayıt işlemi başarıyla tamamlandı.";
            return RedirectToAction("SignIn", "Login");
        }
    }
}
