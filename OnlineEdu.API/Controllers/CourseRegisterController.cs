using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.Dtos.CourseRegisterDto;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRegisterController(ICourseRegisterService _courseRegisterService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("GetMyCourses/{userId}")]
        public IActionResult GetMyCourses(int userId) 
        {
            var values = _courseRegisterService.TGetAllWithCourseAndCategory(x => x.AppUserId == userId);

            if (values == null || !values.Any())
            {
                return NotFound("Kayıtlı kurs bulunamadı.");
            }

            var mappedValues = _mapper.Map<List<ResultCourseRegisterDto>>(values);
            return Ok(mappedValues);
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] CreateCourseRegisterDto createCourseRegisterDto)
        {
            if (createCourseRegisterDto == null)
                return BadRequest("Geçersiz giriş!");

            var newValue = _mapper.Map<CourseRegister>(createCourseRegisterDto);
            _courseRegisterService.TCreate(newValue);
            return Ok("Kursa kayıt başarılı.");
        }

        [HttpPut]
        public IActionResult UpdateCourse([FromBody] UpdateCourseRegisterDto updateCourseRegisterDto)
        {
            if (updateCourseRegisterDto == null)
                return BadRequest("Geçersiz giriş!");

            var value = _mapper.Map<CourseRegister>(updateCourseRegisterDto);
            _courseRegisterService.TUpdate(value);
            return Ok("Güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            _courseRegisterService.TDelete(id);
            return Ok("Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _courseRegisterService.TGetById(id);
            if (value == null)
                return NotFound("Kayıt bulunamadı.");

            var mappedValue = _mapper.Map<ResultCourseRegisterDto>(value);
            return Ok(mappedValue);
        }
    }
}
