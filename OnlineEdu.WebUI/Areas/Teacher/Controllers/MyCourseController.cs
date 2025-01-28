using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Dtos.CourseCategoryDtos;
using OnlineEdu.WebUI.Dtos.CourseDtos;
using OnlineEdu.WebUI.Dtos.CourseVideoDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Area("Teacher")]
    public class MyCourseController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        private readonly UserManager<AppUser> _userManager;

        public MyCourseController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>($"Courses/GetCourseByTeacherId/{user.Id}");
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategoryies");
            ViewBag.Categories = categoryList.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CourseCategoryId.ToString()
            }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto createCourseDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createCourseDto.AppUserId = user.Id;
            createCourseDto.IsShown = false;

            await _client.PostAsJsonAsync("courses", createCourseDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCourse(int id)
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategoryies");
            ViewBag.Categories = categoryList.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CourseCategoryId.ToString()
            }).ToList();

            var value = await _client.GetFromJsonAsync<UpdateCourseDto>($"courses/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            updateCourseDto.AppUserId = user.Id;
            await _client.PutAsJsonAsync("courses", updateCourseDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _client.DeleteAsync($"courses/{id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CourseVideos(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseVideoDto>>("courseVideos/GetCourseVideosByCourseId/" + id);

            TempData["courseId"] = id;

            ViewBag.courseName = values.Select(x => x.Course.CourseName).FirstOrDefault();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateVideo()
        {
            var courseId = (int)TempData["courseId"];
            var course = await _client.GetFromJsonAsync<ResultCourseDto>("courses/" + courseId);
            ViewBag.courseName = course.CourseName;
            ViewBag.courseId = course.CourseId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateCourseVideoDto createCourseVideoDto)
        {
            await _client.PostAsJsonAsync("courseVideos", createCourseVideoDto);
            return RedirectToAction("Index");
        }
    }
}
