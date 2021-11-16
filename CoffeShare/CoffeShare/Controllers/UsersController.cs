using AutoMapper;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UsersController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(email, password, true, false);
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }

            return Ok();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var user = new User() {UserName = email, Email = email};
                var result = await _userManager.CreateAsync(user, password);
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
    }
}
