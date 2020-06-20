using AutoMapper;
using CentralDeErro.Core.Contracts.Services;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CentralDeErro.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthenticationService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper,
            ITokenService tokenService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<AuthenticationOutPut> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user != null)
            {
                var result = await _signInManager
                    .CheckPasswordSignInAsync(user, loginDTO.Password, false);

                if (result.Succeeded)
                {

                    var appUser = await _userManager.Users
                           .FirstOrDefaultAsync(u => u.NormalizedEmail == user.Email.ToUpper());

                    var token = _tokenService.GenerateJwtToken(appUser).Result;
                    var userToReturn = _mapper.Map<AuthenticationOutPut>(appUser);
                    userToReturn.Token = token;

                    return userToReturn;
                }

            }
            //TODO
            return null;
        }

        public async Task<AuthenticationOutPut> Register(RegisterDTO registerDTO)
        {
            var user = await _userManager.FindByEmailAsync(registerDTO.Email);

            if (user == null)
            {
                user = new User(registerDTO.Email, DateTime.Now, registerDTO.Email);
                var result = await _userManager.CreateAsync(user, registerDTO.Password);

                if (result.Succeeded)
                {
                    var appUser = await _userManager.Users
                     .FirstOrDefaultAsync(u => u.NormalizedUserName == user.UserName.ToUpper());


                    var token = _tokenService.GenerateJwtToken(appUser).Result;
                    var userToReturn = _mapper.Map<AuthenticationOutPut>(appUser);
                    userToReturn.Token = token;
                    return userToReturn;
                }
            }
            //TODO
            return null;
        }
    }
}
