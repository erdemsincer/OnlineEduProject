using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.BlogDtos;
using OnlineEdu.WebUI.Dtos.SubscriberDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client;

        public BlogController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

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

        public async Task<IActionResult> BlogDetails(int id)
        {
            var response = await _client.GetFromJsonAsync<ResultBlogDto>("blogs/"+id);
         
            return View(response);
        }

        public async Task<IActionResult> BlogsByCategory(int id)
        {
            var response = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs/GetBlogsByCategoryId/"+id);
            ViewBag.Name=response.Select(x=>x.BlogCategory.Name).FirstOrDefault();
            return View(response);
        }
    }
}
