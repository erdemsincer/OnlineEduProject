﻿using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Dtos.CourseDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly HttpClient _client;

        public CourseController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<IActionResult >Index()
        {
            var courses = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");
            return View(courses);
        }

        public async Task<IActionResult> GetCoursesByCategoryId(int id)
        {
            var courses = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses/GetCoursesByCategoryId/" + id);
            var category = (from x in courses
                            select x.CourseCategory.Name).FirstOrDefault();
            ViewBag.category = category;
            return View(courses);
        }   
    }
}
