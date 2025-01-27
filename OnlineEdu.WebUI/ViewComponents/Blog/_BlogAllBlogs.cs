using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.BlogDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogAllBlogs:ViewComponent
    {
        private readonly HttpClient httpClient = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(values);
        }
    }
}
