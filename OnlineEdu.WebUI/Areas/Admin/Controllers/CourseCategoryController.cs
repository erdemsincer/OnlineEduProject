using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Dtos.CourseCategoryDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class CourseCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {

            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("coursecategoryies");
            return View(values);
        }

        public async Task<IActionResult> DeleteCourseCategory(int id)
        {
            await _client.DeleteAsync($"coursecategoryies/{id}");
            return RedirectToAction(nameof(Index));
        }


        public IActionResult CreateCourseCategory()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateCourseCategory(CreateCourseCategoryDto createCourseCategoryDto)
        {
            await _client.PostAsJsonAsync("coursecategoryies", createCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateCourseCategory(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateCourseCategoryDto>($"coursecategoryies/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourseCategory(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            await _client.PutAsJsonAsync("coursecategoryies", updateCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("courseCategories/ShowOnHome/" + id);

            return RedirectToAction("Index");


        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("courseCategories/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }
    }
}
