using AutoMapper;
using BookLibrary.DTOs;
using BookLibrary.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegistrationDto userRegistrationDto)
        {
            User user = this.mapper.Map<User>(userRegistrationDto);
            var result = await this.userManager.CreateAsync(user, userRegistrationDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await this.userManager.AddToRoleAsync(user, "Visitor");

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("User login failed.");
            }

            var result = await this.signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, userLoginDto.RememberMe, false);

            if (result.Succeeded)
            {
                return Ok("Successfully loged.");
            }
            else
            {
                return BadRequest("Invalid username or password");
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return Ok("Signed out successfully");
        }
    }
}
