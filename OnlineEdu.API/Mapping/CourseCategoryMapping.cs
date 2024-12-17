using AutoMapper;
using OnlineEdu.DTO.Dtos.CourseCategoryDtos;
using OnlineEdu.DTO.Dtos.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseCategoryMapping : Profile
    {
        public CourseCategoryMapping()
        {

            CreateMap<CreateCourseCategoryDto, CourseCategory>().ReverseMap();
            CreateMap<UpdateCourseCategoryDto, CourseCategory>().ReverseMap();
            CreateMap<ResultCourseCategoryDto, CourseCategory>().ReverseMap();
        }
    }
}
