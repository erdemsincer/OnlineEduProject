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
            var values = _courseRegisterService.TGetAllWithCourseAndCategory(x=>x.AppUserId== userId);
            var mappedValues = _mapper.Map<List<ResultCourseRegisterDto>>(values);
            return Ok(mappedValues);
        }

        [HttpPost]

        public IActionResult CreateCourse(CreateCourseRegisterDto createCourseRegisterDto)
        {
            var newValue = _mapper.Map<CourseRegister>(createCourseRegisterDto);
            _courseRegisterService.TCreate(newValue);
            return Ok("Kursa Kayıt başarılı");
        }
        [HttpPut]

        public IActionResult UpdateCourse(UpdateCourseRegisterDto updateCourseRegisterDto)
        {
            var value = _mapper.Map<CourseRegister>(updateCourseRegisterDto);
            _courseRegisterService.TUpdate(value);
            return Ok("gÜNCELLENDİ");

        }
        [HttpDelete]
        public IActionResult DeleteCourse(int id)
        {
            _courseRegisterService.TDelete(id);
            return Ok("sİLİNDİ");
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id) {
          var value=_courseRegisterService.TGetById(id);
          var mappedValue=_mapper.Map<CourseRegister>(value);
            return Ok(mappedValue);
        }
    }
}
