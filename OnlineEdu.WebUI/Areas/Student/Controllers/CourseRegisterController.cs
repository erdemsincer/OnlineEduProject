using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.Areas.Student.Controllers
{
    public class CourseRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
