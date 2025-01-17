﻿using Async_Inn.Interfaces;
using Async_Inn.Models;
using Async_Inn.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Async_Inn.Services
{
    public class IdentityUserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityUserService(UserManager<ApplicationUser> Manager, SignInManager<ApplicationUser> signInManager)
        {
            userManager = Manager;
            _signInManager = signInManager;
        }
        public async Task<UserDto> Authenticate(string username, string password, ModelStateDictionary modelState)
        {
            {
                var user = await userManager.FindByNameAsync(username);
                if (user == null)
                {
                    return null;
                }

                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    return new UserDto
                    {
                        Id = user.Id,
                        Username = user.UserName
                    };
                }

                modelState.AddModelError(string.Empty, "Invalid Login Attempt");
                return null;
            }
        }
        public async Task Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                return;
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }
        }

       
    }
}
