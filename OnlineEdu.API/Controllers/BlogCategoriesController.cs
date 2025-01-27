using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;

using OnlineEdu.DTO.Dtos.BlogCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController(IBlogCategoryService _blogCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var values = _blogCategoryService.GetCategoriesWithBlogs();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var values = _blogCategoryService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult Create(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var newValue = _mapper.Map<BlogCategory>(createBlogCategoryDto);
            _blogCategoryService.TCreate(newValue);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _blogCategoryService.TDelete(id);
            return Ok("Silindi");

        }

        [HttpPut]

        public IActionResult Put(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            var value = _mapper.Map<BlogCategory>(updateBlogCategoryDto);
            _blogCategoryService.TUpdate(value);
            return Ok("Düzenlendi");
        }
    }
}
