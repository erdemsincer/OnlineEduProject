using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.BlogDtos;
using OnlineEdu.WebUI.Dtos.SubscriberDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client=HttpClientInstance.CreateClient();

        public   IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscriberDto createSubscriberDto)
        {
            await _client.PostAsJsonAsync("subscribers", createSubscriberDto);
            return RedirectToAction("Index");
        }
    }
}
