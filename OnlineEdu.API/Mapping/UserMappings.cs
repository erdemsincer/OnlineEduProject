using AutoMapper;
using OnlineEdu.DTO.Dtos.UserDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<LoginDto, AppUser>();
        }
    }
}
