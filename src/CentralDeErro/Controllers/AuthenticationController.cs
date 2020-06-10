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

namespace CentralDeErro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthenticationController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration config,
            IMapper mapper
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _mapper = mapper;
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
                        var appUser = await _userManager.Users
                         .FirstOrDefaultAsync(u => u.NormalizedUserName == user.UserName.ToUpper());

                        var token = GenerateJwtToken(appUser).Result;

                        return Ok(token);
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

                      var appUser = await _userManager.Users
                             .FirstOrDefaultAsync(u => u.NormalizedEmail == user.Email.ToUpper());

                        var userToReturn = _mapper.Map<SignInDto>(appUser);


                        return Ok(new
                        {
                            token = GenerateJwtToken(appUser).Result,
                            user = userToReturn
                        });
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

        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
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
