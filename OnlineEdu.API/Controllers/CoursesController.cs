using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.Dtos.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(IGenericService<Course> _courseService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = _courseService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var values = _courseService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult Create(CreateCourseDto createCourseDto)
        {
            var newValue = _mapper.Map<Course>(createCourseDto);
            _courseService.TCreate(newValue);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _courseService.TDelete(id);
            return Ok("Silindi");

        }

        [HttpPut]

        public IActionResult Put(UpdateCourseDto updateCourseDto)
        {
            var value = _mapper.Map<Course>(updateCourseDto);
            _courseService.TUpdate(value);
            return Ok("Düzenlendi");
        }

    }
}
