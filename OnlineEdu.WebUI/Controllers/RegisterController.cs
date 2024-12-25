using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.UserDto;
using OnlineEdu.WebUI.Services;

namespace OnlineEdu.WebUI.Controllers
{
    public class RegisterController(IUserService userService) : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDto userRegisterDto)
        {
            var result=await userService.CreateUserAsync(userRegisterDto);
            if (result.Succeeded || !ModelState.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                        
                }
                return View();
            }
            return RedirectToAction("Index","Login");
        }
    }
}
