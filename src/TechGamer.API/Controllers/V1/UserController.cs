﻿using Microsoft.AspNetCore.Mvc;
using TechGamer.Application.DTOs.Request;
using TechGamer.Application.DTOs.Response;
using TechGamer.Application.Interfaces;

namespace TechGamer.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : Controller
    {
        private IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserRegisteredResponse>> Register(UserRegisteredRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _identityService.RegisterUser(request);

            if (result.Success)
            {
                return Ok(result);
            }
            else if (result.Errors.Count() > 0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponse>> Login(UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _identityService.Login(request);

            if (result.Success)
            {
                return Ok(result);
            }

            return Unauthorized(result);
        }
    }
}
