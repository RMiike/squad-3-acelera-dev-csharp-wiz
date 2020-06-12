using AutoMapper;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application
{
    public class AuthenticationService : IAuthenticationService
    {

        //TODO 2 atuenticação
        //recuperar senha
        //esqueci senha
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AuthenticationService(
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

        public async Task<AuthenticationOutPut> SignUp(SignUpDto signUpDto)
        {
           var user = await _userManager.FindByEmailAsync(signUpDto.Email);

           if (user == null)
            {
                user = new User(signUpDto.UserName, signUpDto.Email);
                var result = await _userManager.CreateAsync(user, signUpDto.Password);

                if (result.Succeeded)
                {
                    var appUser = await _userManager.Users
                     .FirstOrDefaultAsync(u => u.NormalizedUserName == user.UserName.ToUpper());

                    var token = GenerateJwtToken(appUser).Result;

                    var userToReturn = _mapper.Map<AuthenticationOutPut>(appUser);
                    userToReturn.Token = token;
                    return userToReturn;
                }
            }
           //TODO
            return null;
        }

        public async Task<AuthenticationOutPut> SignIn(SignInDto signInDto)
        {
           var user = await _userManager.FindByEmailAsync(signInDto.Email);

            if (user != null)
            {
                var result = await _signInManager
                    .CheckPasswordSignInAsync(user, signInDto.Password, false);

                if (result.Succeeded)
                {

                    var appUser = await _userManager.Users
                           .FirstOrDefaultAsync(u => u.NormalizedEmail == user.Email.ToUpper());

                    var token = GenerateJwtToken(appUser).Result;

                    var userToReturn = _mapper.Map<AuthenticationOutPut>(appUser);
                    userToReturn.Token = token;

                    return userToReturn;
                }

            }
            //TODO
            return null;
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

    }
}
