using AutoMapper;
using OnlineEdu.DTO.Dtos.AboutDto;
using OnlineEdu.DTO.Dtos.TestimonialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
        }
    }
}
