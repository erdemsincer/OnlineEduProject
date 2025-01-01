using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;

using OnlineEdu.DTO.Dtos.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController( IMapper _mapper,IBlogService _blogService) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = _blogService.GetBlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var values = _blogService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult Create(CreateBlogDto createBlogDto)
        {
            var newValue = _mapper.Map<Blog>(createBlogDto);
            _blogService.TCreate(newValue);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _blogService.TDelete(id);
            return Ok("Silindi");

        }

        [HttpPut]

        public IActionResult Put(UpdateBlogDto updateBlogDto)
        {
            var value = _mapper.Map<Blog>(updateBlogDto);
            _blogService.TUpdate(value);
            return Ok("Düzenlendi");
        }

        [HttpGet("GetBlogByWriterId/{id}")]

        public IActionResult GetBlogByWriterId(int id)
        {
            var values=_blogService.TGetFilteredList(x=>x.WriterId==id);
            var mappedValues=_mapper.Map<List<ResultBlogDto>>(values);
            return Ok(mappedValues);
        }

    }
}
