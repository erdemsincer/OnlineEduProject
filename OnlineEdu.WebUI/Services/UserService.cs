using Microsoft.AspNetCore.Identity;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.Dtos.UserDto;

namespace OnlineEdu.WebUI.Services
{
    public class UserService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<AppRole> _roleManager) : IUserService
    {
        public Task<bool> AssignRoleAsync(AssignRoleDto assignRoleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            var user = new AppUser
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
            };

            if (userRegisterDto.Password != userRegisterDto.ConfirmPassword)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "PasswordMismatch",
                    Description = "Şifreler uyuşmuyor."
                });
            }

            return await _userManager.CreateAsync(user, userRegisterDto.Password);

        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
           var user=await _userManager.FindByEmailAsync(userLoginDto.Email);

            if (user == null) {
                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user,userLoginDto.Password,false,false);

            if (!result.Succeeded) {
                return null;
            
            }
            else
            {
                var IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                if (IsAdmin)
                {
                    return "Admin";
                }
                var IsTeacher = await _userManager.IsInRoleAsync(user, "Teacher");
                if (IsTeacher)
                {
                    return "Teacher";
                }
                var IsStudent = await _userManager.IsInRoleAsync(user, "Student");
                if (IsStudent)
                {
                    return "Student";
                }

                return null;
            }

    
        }

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
