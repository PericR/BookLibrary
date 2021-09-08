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

        /// <summary>
        /// Registers new User.
        /// Uses asp.net core Identity framework.
        /// </summary>
        /// <param name="userRegistrationDto">User registration data transfer object</param>
        /// <returns></returns>
        /// <response code="200">User added to database successfully.</response>
        /// <response code="400">Something went wrong in the proces of adding user.</response>
        [HttpPost("register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Register(UserRegistrationDto userRegistrationDto)
        {
            User user = this.mapper.Map<User>(userRegistrationDto);
            var result = await this.userManager.CreateAsync(user, userRegistrationDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await this.userManager.AddToRoleAsync(user, "Administrator");

            User newUser = await this.userManager.FindByNameAsync(userRegistrationDto.UserName);

            return Ok((new { Token = this.authService.CreateToken(newUser) }));
        }

        /// <summary>
        /// Login users functionality.
        /// Uses asp.net core Identity framework.
        /// </summary>
        /// <param name="userLoginDto">Data Transfer Object for loging user to application</param>
        /// <returns>JWT with userName and user roles</returns>
        /// <response code="200">User successfully loged in the app</response>
        /// <response code="400">Something went wrong in the login proces, probably bad username or password</response>
        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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

        /// <summary>
        /// Logout user functionality.
        /// Uses asp.net core Identity framework.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Logged out successfully</response>
        [HttpPost("logout")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return Ok("Signed out successfully");
        }
    }
}
