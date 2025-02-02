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
using OnlineEdu.WebUI.Services.TokenServices;

namespace OnlineEdu.WebUI.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    [Area("Student")]
    public class CourseRegisterController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;
    

        public CourseRegisterController( ITokenService tokenService, IHttpClientFactory clientFactory)
        {

            _client = clientFactory.CreateClient("EduClient");
            _tokenService = tokenService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;
           
            var values = await _client.GetFromJsonAsync<List<ResultCourseRegisterDto>>("courseRegister/GetMyCourses/" + userId);
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

            var userId = _tokenService.GetUserId;
            createCourseRegisterDto.AppUserId = userId;
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
