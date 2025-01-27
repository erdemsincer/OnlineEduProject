using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.BlogDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class BlogController : Controller
    {
       
        public   IActionResult Index()
        {
            return View();
        }
    }
}
