using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.SocialMediaDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.UILayout
{
    public class _UILayoutSocialMedia:ViewComponent
    {
        private readonly HttpClient _client=HttpClientInstance.CreateClient();
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var response = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialmedias");
            return View(response);
        }
    }
}
