using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.AboutDto;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly HttpClient httpClient = HttpClientInstance.CreateClient();
        public async Task< IActionResult >Index()
        {
            var values = await httpClient.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }
    }
}
