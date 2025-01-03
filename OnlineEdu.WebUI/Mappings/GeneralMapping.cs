using AutoMapper;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Dtos.RoleDto;
using OnlineEdu.WebUI.Dtos.TeacherSocialDtos;
using OnlineEdu.WebUI.Dtos.UserDto;

namespace OnlineEdu.WebUI.Mappings
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<AppRole, ResultRoleDto>().ReverseMap();
            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDto>().ReverseMap();
            CreateMap<AppUser, ResultUserDto>().ReverseMap();
        }
    }
}
