using AutoMapper;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using CoffeeShare.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly JwtHandler _jwtHandler;

        public UsersController(SignInManager<User> signInManager, UserManager<User> userManager, JwtHandler jwtHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var user = await _userManager.FindByNameAsync(userDto.Email);
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = await _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            await _signInManager.PasswordSignInAsync(userDto.Email, userDto.Password, false, false);
            return Ok(new AuthResponseDto {IsAuthSuccessful = true, Token = token});
            }
        
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                var user = new User() {UserName = userDto.Email, Email = userDto.Email};
                var result = await _userManager.CreateAsync(user, userDto.Password);
                await _userManager.AddToRoleAsync(user, "Default");
                if (result.Succeeded)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (ModelState.IsValid)
            {
                await _signInManager.SignOutAsync();
            }

            return Ok();
        }

        [HttpGet("Privacy")]
        [Authorize]
        public IActionResult Privacy()
        {
            var claims = User.Claims
                .Select(c => new { c.Type, c.Value })
                .ToList();

            return Ok(claims);
        }
    }
}
