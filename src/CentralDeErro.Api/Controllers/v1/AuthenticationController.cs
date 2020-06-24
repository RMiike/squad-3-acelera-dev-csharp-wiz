using System;
using System.Threading.Tasks;
using CentralDeErro.Core.Contracts.Services;
using CentralDeErro.Core.Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErro.Api.Controllers.v1
{
    [Route("v1")]
    [AllowAnonymous]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new RegisterCreateDTO());
        }

        #region Register
        // POST: v1/register

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromServices] IAuthenticationService _service,
            [FromBody] RegisterCreateDTO registerDTO)
        {
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
        //Get: v1/confirmemail?userEmail=&token
        [HttpGet("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(
              [FromServices] IAuthenticationService _service,
              string userEmail,
              string token
            )
        {
            if (string.IsNullOrWhiteSpace(userEmail) || string.IsNullOrWhiteSpace(token))
            {
                return NotFound(new { message = "Wrong email or invalid token" });
            }

            var result = await _service.ConfirmEmail(userEmail, token);

            //TODO
            if (result.Success == true)
                return Redirect("http://localhost:53228/ConfirmEmail.html");

            return BadRequest(result);
        }

        #endregion

        #region Sign In
        // POST: v1/signin
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(
            [FromServices] IAuthenticationService _services,
            [FromBody]LoginCreateDTO loginDTO)
        {
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
        // POST: v1/forgotpassword
        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(
         [FromServices] IAuthenticationService _services,
            [FromBody] ForgotPasswordDTO forgotPasswordDTO)
        {
            if (string.IsNullOrWhiteSpace(forgotPasswordDTO.Email))
            {
                return NotFound(new { message = "Wrong email, please verify and try again." });
            }

            var result = await _services.ForgotPassword(forgotPasswordDTO);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }
        #endregion


        #region LoginWith2fa
        #endregion


        #region ExternalLogin
        #endregion

    }
}
