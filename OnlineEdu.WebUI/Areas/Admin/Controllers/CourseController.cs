using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.Dtos.CourseCategoryDtos;
using OnlineEdu.WebUI.Dtos.CourseDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
 
    public class CourseController : Controller
    {
        private readonly HttpClient _client;

        public CourseController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task CourseCategoryDropdown()
        {
            var courseCategoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("coursecategoryies");

            List<SelectListItem> courseCategories = (from x in courseCategoryList
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.CourseCategoryId.ToString()
                                                     }).ToList();
            ViewBag.courseCategories = courseCategories;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");
            return View(values);
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                var response = await _client.DeleteAsync($"courses/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Error", $"Silme işlemi başarısız oldu. Durum: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            await  CourseCategoryDropdown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto createCourseDto)
        {
            await _client.PostAsJsonAsync("courses", createCourseDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateCourse(int id)
        {
            await CourseCategoryDropdown();
            var values = await _client.GetFromJsonAsync<UpdateCourseDto>($"courses/{id}");
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            if (updateCourseDto == null || updateCourseDto.CourseId == 0)
            {
                TempData["ErrorMessage"] = "Güncelleme için geçersiz veri.";
                return RedirectToAction(nameof(Index));
            }

            var response = await _client.PutAsJsonAsync("courses", updateCourseDto);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Kurs başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Güncelleme işlemi başarısız oldu.";
                return RedirectToAction(nameof(Index));
            }
        }




        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("courses/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("courses/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }
    }
}
