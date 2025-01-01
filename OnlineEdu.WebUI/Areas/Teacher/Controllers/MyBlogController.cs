using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Dtos.BlogDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class MyBlogController : Controller
    {
        private readonly HttpClient _httpClient=HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;

        public MyBlogController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            
        }

        public async Task< IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs/GetBlogByWriterId/" + user.Id);
            return View(values);
        }
    }
}
