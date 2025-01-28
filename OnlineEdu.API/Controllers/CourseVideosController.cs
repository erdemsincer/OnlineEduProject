﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.Dtos.CourseVideoDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseVideosController : ControllerBase
    {
        private readonly IGenericService<CourseVideo> _courseVideoService;
        private readonly IMapper _mapper;

        public CourseVideosController(IGenericService<CourseVideo> courseVideoService, IMapper mapper)
        {
            _courseVideoService = courseVideoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseVideoService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _courseVideoService.TGetById(id);
            if (value == null)
                return NotFound("Kurs videosu bulunamadı.");

            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCourseVideoDto createCourseVideoDto)
        {
            if (createCourseVideoDto == null)
                return BadRequest("Geçersiz giriş!");

            var newValue = _mapper.Map<CourseVideo>(createCourseVideoDto);
            _courseVideoService.TCreate(newValue);
            return Ok("Kurs videosu eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var value = _courseVideoService.TGetById(id);
            if (value == null)
                return NotFound("Silinecek kurs videosu bulunamadı.");

            _courseVideoService.TDelete(id);
            return Ok("Kurs videosu silindi.");
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateCourseVideoDto updateCourseVideoDto)
        {
            if (updateCourseVideoDto == null)
                return BadRequest("Geçersiz giriş!");

            var value = _mapper.Map<CourseVideo>(updateCourseVideoDto);
            _courseVideoService.TUpdate(value);
            return Ok("Kurs videosu güncellendi.");
        }
    }
}
