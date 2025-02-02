using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.Dtos.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(IGenericService<Subscriber> _subscriberService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = _subscriberService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var values = _subscriberService.TGetById(id);
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create(CreateSubscriberDto createSubscriberDto)
        {
            var newValue = _mapper.Map<Subscriber>(createSubscriberDto);
            _subscriberService.TCreate(newValue);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _subscriberService.TDelete(id);
            return Ok("Silindi");

        }

        [HttpPut]

        public IActionResult Put(UpdateSubscriberDto updateSubscriberDto)
        {
            var value = _mapper.Map<Subscriber>(updateSubscriberDto);
            _subscriberService.TUpdate(value);
            return Ok("Düzenlendi");
        }
    }
}
