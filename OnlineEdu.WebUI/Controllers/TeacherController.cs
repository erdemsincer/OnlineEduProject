using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Services;

namespace OnlineEdu.WebUI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IUserService _userService;

        public TeacherController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var teachers = await _userService.GetAllTeachers();
            return View(teachers);
        }
    }
}
