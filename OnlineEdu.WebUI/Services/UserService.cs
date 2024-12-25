﻿using Microsoft.AspNetCore.Identity;
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

        public Task<bool> LoginAsync(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
