using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Dtos.TeacherSocialDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.TokenServices;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class MySocialMediaController : Controller
    {
        private readonly HttpClient _httpClient;

        private readonly ITokenService _tokenService;

        public MySocialMediaController( ITokenService tokenService, IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("EduClient");
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;
            var values = await _httpClient.GetFromJsonAsync<List<ResultTeacherSocialDto>>("teachersocials/byTeacherId/"+userId);
            return View(values);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTeacherSocial(int id)
        {
            await _httpClient.DeleteAsync("teachersocials/" + id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTeacherSocial(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateTeacherSocialDto>("teachersocials/"+id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeacherSocial(UpdateTeacherSocialDto updateTeacherSocialDto)
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
            var userId = _tokenService.GetUserId;
            createTeacherSocialDto.TeacherId = userId;
            await _httpClient.PostAsJsonAsync("teachersocials", createTeacherSocialDto);
            return RedirectToAction("Index");

        }
    }
}
