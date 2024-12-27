using Microsoft.AspNetCore.Identity;
using OnlineEdu.WebUI.Dtos.UserDto;

namespace OnlineEdu.WebUI.Services
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);

        Task<bool> LogoutAsync();

        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);
        Task<bool> AssignRoleAsync(AssignRoleDto assignRoleDto);
       
    }
}
