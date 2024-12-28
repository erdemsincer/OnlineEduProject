using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.AboutDto;
using OnlineEdu.WebUI.Dtos.BannerDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    
    public class BannerController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDto>>("banners");
            return View(values);
        }
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _client.DeleteAsync($"banners/{id}");
            return RedirectToAction("Index");
        }

        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            await _client.PostAsJsonAsync("banners",createBannerDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateBanner(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateBannerDto>($"banners/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            await _client.PutAsJsonAsync("banners", updateBannerDto);
            return RedirectToAction(nameof(Index));
        }
    }

    
}
