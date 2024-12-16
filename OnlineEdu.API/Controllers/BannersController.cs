using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.Dtos.AboutDto;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<About> _bannerService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = _bannerService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var values = _bannerService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult Create(CreateAboutDto createAboutDto)
        {
            var newValue = _mapper.Map<About>(createAboutDto);
            _bannerService.TCreate(newValue);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _bannerService.TDelete(id);
            return Ok("Silindi");

        }

        [HttpPut]

        public IActionResult Put(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            _bannerService.TUpdate(value);
            return Ok("Düzenlendi");
        }
    }
}
