using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    public class MyCourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
