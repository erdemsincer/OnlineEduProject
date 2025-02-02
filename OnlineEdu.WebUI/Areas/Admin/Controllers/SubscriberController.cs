using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.SubscriberDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SubscriberController : Controller
    {
        private readonly HttpClient _client;

        public SubscriberController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSubscriberDto>>("subscribers");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var response = await _client.DeleteAsync($"subscribers/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Abone başarıyla silindi.";
            }
            else
            {
                TempData["Error"] = "Abone silinirken bir hata oluştu.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscriber(CreateSubscriberDto createSubscriberDto)
        {
            var response = await _client.PostAsJsonAsync("subscribers", createSubscriberDto);
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Abone başarıyla eklendi.";
            }
            else
            {
                TempData["Error"] = "Abone eklenirken bir hata oluştu.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatusSubscriber(int id)
        {
            var subscriber = await _client.GetFromJsonAsync<UpdateSubscriberDto>($"subscribers/{id}");
            if (subscriber != null)
            {
                subscriber.IsActive = !subscriber.IsActive;
                var response = await _client.PutAsJsonAsync("subscribers", subscriber);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Abone durumu başarıyla güncellendi.";
                }
                else
                {
                    TempData["Error"] = "Abone durumu güncellenirken bir hata oluştu.";
                }
            }
            else
            {
                TempData["Error"] = "Abone bulunamadı.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
