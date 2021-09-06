using AutoMapper;
using BookLibrary.DTOs;
using BookLibrary.Entities;
using BookLibrary.Interfaces;
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
        private readonly IAuthService authService;

        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IAuthService authService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authService = authService;
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

            await this.userManager.AddToRoleAsync(user, "Administrator");

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("User login failed.");
            }

            User user = await this.userManager.FindByNameAsync(userLoginDto.UserName);

            if (await this.authService.ValidateUser(userLoginDto, user))
            {
                return Ok((new { Token = this.authService.CreateToken(user) }));
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
