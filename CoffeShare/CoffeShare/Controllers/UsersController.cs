using AutoMapper;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
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
            var result = await _signInManager.PasswordSignInAsync(userDto.Email, userDto.Password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userDto.Email);
                var signingCredentials = _jwtHandler.GetSigningCredentials();
                var claims = await _jwtHandler.GetClaims(user);
                var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
            }
            return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
        }
        
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            if(userDto == null || !ModelState.IsValid)
                return BadRequest();

            var user = new User() {UserName = userDto.Email, Email = userDto.Email};
            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(new RegistrationResponseDto { Errors = errors });
            }
            await _userManager.AddToRoleAsync(user, "Default");
            return Ok();
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
        public async  Task<IActionResult> GetUserId()
        {
            var claims = User.Claims.FirstOrDefault();
            if (claims == null)
            {
                return BadRequest();
            }
            var claimValue = claims.Value;
            var user = _context.Users.SingleOrDefault(x => x.Email == claimValue);
            return Ok(user.Id);
        }
    }
}
