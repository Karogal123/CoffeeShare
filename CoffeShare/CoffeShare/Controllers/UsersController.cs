using AutoMapper;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.DataContext;
using CoffeeShare.Jwt;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        private readonly JwtHandler _jwtHandler;
        private readonly CoffeeContext _context;

        public UsersController(SignInManager<User> signInManager, Microsoft.AspNetCore.Identity.UserManager<User> userManager, JwtHandler jwtHandler, CoffeeContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtHandler = jwtHandler;
            _context = context;
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
            var result = await _signInManager.PasswordSignInAsync(userDto.Email, userDto.Password, true, false);
            if (result.Succeeded)
            { 
                return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
            }

            return BadRequest();
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

        [HttpGet("GetUserId")]
        [Authorize]
        public async  Task<IActionResult> GetUserId()
        {
            var claims = User.Claims.FirstOrDefault();
            var claimValue = claims.Value;
            var user = _context.Users.SingleOrDefault(x => x.Email == claimValue);
            return Ok(user.Id);
        }
    }
}
