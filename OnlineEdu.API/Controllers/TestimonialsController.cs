using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.Dtos.TestimonialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IGenericService<Testimonial> _testimonialService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var values = _testimonialService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult Create(CreateTestimonialDto createTestimonialDto)
        {
            var newValue = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TCreate(newValue);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Silindi");

        }

        [HttpPut]

        public IActionResult Put(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok("Düzenlendi");
        }
    }
}
