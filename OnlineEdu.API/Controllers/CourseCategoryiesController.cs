    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OnlineEdu.Business.Abstract;

    using OnlineEdu.DTO.Dtos.CourseCategoryDtos;
    using OnlineEdu.Entity.Entities;

    namespace OnlineEdu.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CourseCategoryiesController(ICourseCategoryService _courseCategoryService, IMapper _mapper) : ControllerBase
        {
            [HttpGet]

            public IActionResult Get()
            {
                var values = _courseCategoryService.TGetList();
                var courseCategories=_mapper.Map<List<ResultCourseCategoryDto>>(values);
                return Ok(courseCategories);
            }
            [HttpGet("{id}")]

            public IActionResult GetById(int id)
            {
                var values = _courseCategoryService.TGetById(id);
                return Ok(values);
            }
            [HttpPost]
            public IActionResult Create(CreateCourseCategoryDto createCourseCategoryDto)
            {
                var newValue = _mapper.Map<CourseCategory>(createCourseCategoryDto);
                _courseCategoryService.TCreate(newValue);
                return Ok("Eklendi");
            }
            [HttpDelete("{id}")]

            public IActionResult Delete(int id)
            {
                _courseCategoryService.TDelete(id);
                return Ok("Silindi");

            }

            [HttpPut]

            public IActionResult Put(UpdateCourseCategoryDto updateCourseCategoryDto)
            {
                var value = _mapper.Map<CourseCategory>(updateCourseCategoryDto);
                _courseCategoryService.TUpdate(value);
                return Ok("Düzenlendi");
            }
            [HttpGet("ShowOnHome/{id}")]
            public IActionResult ShowOnHome(int id)
            {
                _courseCategoryService.TShowOnHome(id);
                return Ok("Ana Sayfada Gösteriliyor");
            }

            [HttpGet("DontShowOnHome/{id}")]
            public IActionResult DontShowOnHome(int id)
            {
                _courseCategoryService.TDontShowOnHome(id);
                return Ok("Ana Sayfada Gösterilmiyor");
            }

            [HttpGet("GetActiveCategories")]

            public IActionResult GetActiveCategories()
            {
               var values=_courseCategoryService.TGetFilteredList(x=>x.IsShown==true);
               return Ok(values);
            }


        }
    }
