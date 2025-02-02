using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.Dtos.AboutDto;
using OnlineEdu.DTO.Dtos.BannerDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin")]

    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> _bannerService, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
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
        public IActionResult Create(CreateBannerDto createBannerDto)
        {
            var newValue = _mapper.Map<Banner>(createBannerDto);
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

        public IActionResult Put(UpdateBannerDto updateBannerDto)
        {
            var value = _mapper.Map<Banner>(updateBannerDto);
            _bannerService.TUpdate(value);
            return Ok("Düzenlendi");
        }
    }
}
