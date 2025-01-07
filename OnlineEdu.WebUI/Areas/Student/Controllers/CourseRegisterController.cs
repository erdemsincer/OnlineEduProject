using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Dtos.CourseDtos;
using OnlineEdu.WebUI.Dtos.CourseRegisterDto;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Student.Controllers
{
    [Authorize(Roles ="Student")]
    [Area("Student")]
    public class CourseRegisterController(UserManager<AppUser> _userManager) : Controller
    {
        private readonly HttpClient _client=HttpClientInstance.CreateClient();

        public async Task< IActionResult >Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultCourseRegisterDto>>("courseRegister/GetMyCourses/" + user.Id);
            return View(values);
        }

        [HttpGet]

        public async Task<IActionResult> RegisterCourse()
        {
            var courseList = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");

           ViewBag.courses =(from x in courseList 
                             select new SelectListItem
                           {
                              Text=x.CourseName,
                              Value=x.CourseId.ToString()
                           }).ToList();

            return View();
        
        }

        [HttpPost]

        public async Task<IActionResult> RegisterCourse(CreateCourseRegisterDto createCourseRegisterDto)
        {
            var courseList = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");

            ViewBag.courses = (from x in courseList
                               select new SelectListItem
                               {
                                   Text = x.CourseName,
                                   Value = x.CourseId.ToString()
                               }).ToList();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createCourseRegisterDto.AppUserId=user.Id;
            var result=await _client.PostAsJsonAsync("courseregister",createCourseRegisterDto);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createCourseRegisterDto);
        }
    }
}
