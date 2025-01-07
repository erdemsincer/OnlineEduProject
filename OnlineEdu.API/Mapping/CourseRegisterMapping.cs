using AutoMapper;
using OnlineEdu.DTO.Dtos.CourseRegisterDto;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseRegisterMapping : Profile
    {
        public CourseRegisterMapping()
        {
            CreateMap<CourseRegister, ResultCourseRegisterDto>().ReverseMap();
            CreateMap<CourseRegister, UpdateCourseRegisterDto>().ReverseMap();
            CreateMap<CourseRegister, CreateCourseRegisterDto>().ReverseMap();
        }
    }
}
