using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.BannerDtos;
using OnlineEdu.WebUI.Dtos.CourseCategoryDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeCourseCategoryComponent:ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("coursecategoryies/GetActiveCategories");
            return View(values);
        }
    }
}
