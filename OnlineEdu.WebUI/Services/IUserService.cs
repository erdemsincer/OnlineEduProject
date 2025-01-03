using Microsoft.AspNetCore.Identity;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Dtos.TeacherSocialDtos;
using OnlineEdu.WebUI.Dtos.UserDto;

namespace OnlineEdu.WebUI.Services
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);

        Task<bool> LogoutAsync();

        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);
        Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);

        Task<List<AppUser>> GetAllUsersAsync();

        Task<List<ResultUserDto>> Get4Teachers();

        Task<AppUser> GetUserByIdAsync(int id);
       
    }
}
