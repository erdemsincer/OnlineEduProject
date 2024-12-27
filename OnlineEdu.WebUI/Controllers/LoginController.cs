using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.UserDto;
using OnlineEdu.WebUI.Services;

namespace OnlineEdu.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View(); // Kullanıcıya giriş formunu göster
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            // Model doğrulama başarısızsa formu tekrar göster
            if (!ModelState.IsValid)
            {
                return View(userLoginDto);
            }

            // Kullanıcı girişini kontrol et
            var userRole = await _userService.LoginAsync(userLoginDto);

            if (userRole == "Admin") { 
                return RedirectToAction("Index","About", new {area ="Admin"});
            }
            if(userRole == "Teacher")
            {
                return RedirectToAction("Index", "MyCourse", new { area = "Teacher" });
            }
            if (userRole == "Student")
            {
                return RedirectToAction("Index", "CourseRegister", new { area = "Student" });
            }

            else
            {
                ModelState.AddModelError("", "Email veya şifre hatalı");
                return View();
            }
        }
    }
}
