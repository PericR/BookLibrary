using AutoMapper;
using BookLibrary.DTOs;
using BookLibrary.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public AccountController(IMapper mapper, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegistrationDto userRegistrationDto)
        {
            User user = this.mapper.Map<User>(userRegistrationDto);
            var result = await this.userManager.CreateAsync(user, userRegistrationDto.Password);

            if(!result.Succeeded)
            {
                return BadRequest("User registration failed.");
            }

            await this.userManager.AddToRoleAsync(user, "Visitor");

            return Ok();
        }
    }
}
