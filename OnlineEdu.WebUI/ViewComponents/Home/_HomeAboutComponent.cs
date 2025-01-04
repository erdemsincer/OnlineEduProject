using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.AboutDto;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeAboutComponent:ViewComponent
    {
        private readonly HttpClient _client=HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }
    }
}
