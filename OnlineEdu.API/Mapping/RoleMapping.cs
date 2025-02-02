using AutoMapper;
using OnlineEdu.DTO.Dtos.RoleDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class RoleMapping:Profile
    {
        public RoleMapping()
        {
            CreateMap<CreateRoleDto, AppRole>();
        }
    }
}
