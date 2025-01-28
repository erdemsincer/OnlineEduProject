using AutoMapper;
using OnlineEdu.DTO.Dtos.BlogCategoryDtos;
using OnlineEdu.DTO.Dtos.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<CreateBlogDto, Blog>().ReverseMap();
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();
            CreateMap<ResultBlogDto,Blog >().ReverseMap();
        }
    }
}
