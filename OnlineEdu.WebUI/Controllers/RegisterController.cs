using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.UserDto;
using OnlineEdu.WebUI.Services;

namespace OnlineEdu.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterDto); // Model doğrulama hatalarını tekrar göster
            }

            var result = await _userService.CreateUserAsync(userRegisterDto);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
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
