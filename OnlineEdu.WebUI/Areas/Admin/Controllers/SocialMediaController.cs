using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.BannerDtos;
using OnlineEdu.WebUI.Dtos.SocialMediaDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class SocialMediaController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialmedias");
            return View(values);
        }
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _client.DeleteAsync($"socialmedias/{id}");
            return RedirectToAction("Index");
        }

        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            await _client.PostAsJsonAsync("socialmedias", createSocialMediaDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateSocialMediaDto>($"socialmedias/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _client.PutAsJsonAsync("socialmedias", updateSocialMediaDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
