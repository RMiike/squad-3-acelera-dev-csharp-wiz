using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CentralDeErro.Core.Entities.Dto;
using CentralDeErro.Core.Contracts.Services;

namespace CentralDeErro.Controllers
{
    [Route("v1")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        // GET: api/Authentication]
        //test route 
        //return new User
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(new RegisterDTO());
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromServices] IAuthenticationService _services, [FromBody] RegisterDTO registerDTO)
        {
            try
            {
                var userSignUpOutDto = await _services.Register(registerDTO);
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

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> Post([FromServices] IAuthenticationService _services, [FromBody]LoginDTO loginDTO)
        {
            try
            {
                var userSignIOutDto = await _services.Login(loginDTO);
                if (userSignIOutDto == null)
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
