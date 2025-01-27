using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.BlogDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogRecentBlogs:ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs/GetLast4Blogs");
        return View(values);
    }
}
}
