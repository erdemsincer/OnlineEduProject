using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Dtos.CourseDtos;
using OnlineEdu.WebUI.Dtos.CourseRegisterDto;
using OnlineEdu.WebUI.Dtos.CourseVideoDtos;
using OnlineEdu.WebUI.Helpers;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OnlineEdu.WebUI.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    [Area("Student")]
    public class CourseRegisterController : Controller
    {
        private readonly HttpClient _client;
        private readonly UserManager<AppUser> _userManager;

        public CourseRegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _client = HttpClientInstance.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultCourseRegisterDto>>("courseRegister/GetMyCourses/" + user.Id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> RegisterCourse()
        {
            var courseList = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");

            ViewBag.courses = courseList.Select(x => new SelectListItem
            {
                Text = x.CourseName,
                Value = x.CourseId.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCourse(CreateCourseRegisterDto createCourseRegisterDto)
        {
            var courseList = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");

            ViewBag.courses = courseList.Select(x => new SelectListItem
            {
                Text = x.CourseName,
                Value = x.CourseId.ToString()
            }).ToList();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createCourseRegisterDto.AppUserId = user.Id;
            var result = await _client.PostAsJsonAsync("courseregister", createCourseRegisterDto);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createCourseRegisterDto);
        }

        [HttpGet]
        public async Task<IActionResult> CourseVideos(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseVideoDto>>("courseVideos/GetCourseVideosByCourseId/" + id);

            ViewBag.courseName = values.Select(x => x.Course.CourseName).FirstOrDefault();
            return View(values);
        }
    }
}
