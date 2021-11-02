using AutoMapper;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.Auth;
using CoffeeShare.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(User user)
        {
            var authResponse = await _repository.RegisterAsync(user);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(User user)
        {
            var authResponse = await _repository.LoginAsync(user);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token
            });
        }
    }
}
