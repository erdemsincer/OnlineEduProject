using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.Dtos.AboutDto;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericService<About> _aboutService,IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]

        public IActionResult Get()
        {
            var values= _aboutService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var values=_aboutService.TGetById(id);
            return Ok(values);  
        }
        [HttpPost]
        public IActionResult Create(CreateAboutDto createAboutDto)
        {
          var newValue=_mapper.Map<About>(createAboutDto);
          _aboutService.TCreate(newValue);
          return Ok("Eklendi");
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _aboutService.TDelete(id);
            return Ok("Silindi");
           
        }

        [HttpPut]

        public IActionResult Put(UpdateAboutDto updateAboutDto)
        {
            var value=_mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(value);
            return Ok("Düzenlendi");
        }

    }
}
