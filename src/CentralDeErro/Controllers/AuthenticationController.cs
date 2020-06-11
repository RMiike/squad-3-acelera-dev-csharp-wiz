using System;
using System.Collections.Generic;
using AutoMapper;
using CentralDeErro.Core.Domain;
using CentralDeErro.Core.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Application;

namespace CentralDeErro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _services;

        public AuthenticationController(AuthenticationService services)
        {
            _services = services;
        }
        // GET: api/Authentication]
        //test route 
        //return new User
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new SignUpDto());
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            try
            {
                var userSignUpOutDto = await _services.SignUp(signUpDto);
                if (userSignUpOutDto == null)
                    return NotFound("User already exits.");

                return Ok(userSignUpOutDto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"ERROR {ex.Message}");
            }
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            try
            {
                var userSignIOutDto = await _services.SignIn(signInDto);
                if(userSignIOutDto == null)
                    return NotFound("Wrong user or password.");

                return Ok(userSignIOutDto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"ERROR {ex.Message}");
            }
        }
    }
}
