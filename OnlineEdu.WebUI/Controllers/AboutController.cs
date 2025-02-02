using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.AboutDto;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly HttpClient httpClient;

        public AboutController(IHttpClientFactory clientFactory)
        {
            httpClient = clientFactory.CreateClient("EduClient");
        }

        public async Task< IActionResult >Index()
        {
            var values = await httpClient.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }
    }
}
