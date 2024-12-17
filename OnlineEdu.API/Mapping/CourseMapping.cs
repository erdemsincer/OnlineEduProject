using AutoMapper;
using OnlineEdu.DTO.Dtos.BlogDtos;
using OnlineEdu.DTO.Dtos.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseDto, Course>().ReverseMap();
            CreateMap<UpdateCourseDto, Course>().ReverseMap();
            CreateMap<ResultCourseDto, Course>().ReverseMap();
        }
    }
}
