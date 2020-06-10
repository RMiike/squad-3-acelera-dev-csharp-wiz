using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralDeErro.Core.Domain;
using CentralDeErro.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationController(
            UserManager<User> userManager,
            SignInManager<User> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: api/Authentication]
        //test route 
        //return new User
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new User());
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(signUpDto.Email);

                if (user == null)
                {
                    user = new User
                    {
                        Id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10),
                        UserName = signUpDto.UserName,
                        Email = signUpDto.Email
                    };
                    var result = await _userManager.CreateAsync(user, signUpDto.Password);

                    if (result.Succeeded)
                    {
                        //TODO token
                        return Ok(user);
                    }
                }
                return BadRequest("User already existis!");
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
                var user = await _userManager.FindByEmailAsync(signInDto.Email);

                if (user != null)
                {
                    var result = await _signInManager
                        .CheckPasswordSignInAsync(user, signInDto.Password, false);

                    if(result.Succeeded)
                    {
                        //TODO token
                        return Ok(user);
                    }

                }
                return BadRequest("Wrong user or password!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"ERROR {ex.Message}");
            }
        }
        // GET: api/Authentication/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Authentication
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Authentication/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
