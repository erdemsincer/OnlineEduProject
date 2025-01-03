using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Dtos.TeacherSocialDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class MySocialMediaController : Controller
    {
        private readonly HttpClient _httpClient=HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;

        public MySocialMediaController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _httpClient.GetFromJsonAsync<List<ResultTeacherSocialDto>>("teachersocials/byTeacherId/"+user.Id);
            return View(values);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _httpClient.DeleteAsync("teachersocials/" + id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateTeacherSocialDto>("teachersocials/"+id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateTeacherSocialDto updateTeacherSocialDto)
        {
           
            await _httpClient.PutAsJsonAsync("teachersocials", updateTeacherSocialDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateTeacherSocial() {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacherSocial(CreateTeacherSocialDto createTeacherSocialDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createTeacherSocialDto.TeacherId = user.Id;
            await _httpClient.PostAsJsonAsync("teachersocials", createTeacherSocialDto);
            return RedirectToAction("Index");

        }
    }
}
