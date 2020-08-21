﻿using System;
using System.Threading.Tasks;
using CentralDeErro.Core.Contracts.Services;
using CentralDeErro.Core.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CentralDeErro.WebAPI.Controllers.v1
{
    [Route("v1")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {

        #region Register
      
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromServices] IAuthenticationService _service,
            [FromBody] RegisterCreateDTO registerDTO)
        {
            registerDTO.Validate();
            if (registerDTO.Invalid)
                return BadRequest(new ResultDTO(false, "Invalid field.", registerDTO.Notifications));

            try
            {
                var result = await _service.Register(registerDTO);

                if (result.Success == true)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"ERROR {ex.Message}");
            }
        }
        #endregion

        #region ConfirmEmail
        [HttpGet("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(
              [FromServices] IAuthenticationService _service,
              [FromServices] IConfiguration _configuration,
              string userEmail,
              string token
            )
        {
            if (string.IsNullOrWhiteSpace(userEmail) || string.IsNullOrWhiteSpace(token))
            {
                return BadRequest(new ResultDTO(false, "Wrong email or invalid token", null));
            }

            var result = await _service.ConfirmEmail(userEmail, token);

            if (result.Success == true)
                return Ok(result);

            return BadRequest(result);
        }

        #endregion

        #region Sign In
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(
            [FromServices] IAuthenticationService _services,
            [FromBody] LoginCreateDTO loginDTO)
        {
            loginDTO.Validate();
            if (loginDTO.Invalid)
                return BadRequest(new ResultDTO(false, "Invalid field.", loginDTO.Notifications));

            try
            {
                var userSignIOutDto = await _services.Login(loginDTO);

                if (userSignIOutDto.Success == false)
                    return BadRequest(userSignIOutDto);

                return Ok(userSignIOutDto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"ERROR {ex.Message}");
            }
        }
        #endregion

        #region ForgotPassword
        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(
         [FromServices] IAuthenticationService _services,
            [FromBody] ForgotPasswordDTO forgotPasswordDTO)
        {
            forgotPasswordDTO.Validate();
            if (forgotPasswordDTO.Invalid)
                return BadRequest(new ResultDTO(false, "Wrong email, please verify and try again.", forgotPasswordDTO.Notifications));

            var result = await _services.ForgotPassword(forgotPasswordDTO);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }
        #endregion

       }
}
