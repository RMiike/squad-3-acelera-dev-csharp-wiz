using AutoMapper;
using CentralDeErro.Core.Contracts.Services;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErro.ApplicationServices.Services
{
    public class AuthenticationService
        : IAuthenticationService
    {
        #region controler and private
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;
        public AuthenticationService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper,
            ITokenService tokenService,
             IConfiguration configuration,
            IMailService mailService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenService = tokenService;
            _configuration = configuration;
            _mailService = mailService;
        }
        #endregion

        #region Register
        public async Task<ResultDTO> Register(RegisterCreateDTO registerDTO)
        {
            var user = await _userManager.FindByEmailAsync(registerDTO.Email);

            if (user != null)
                return new ResultDTO(false, "User already exist!", null);

            user = User.Create(registerDTO.FullName, registerDTO.Email, registerDTO.Email);

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
                return new ResultDTO(false, result.ToString(), null);

            await CreateAndSendEmailConfirm(registerDTO, user).ConfigureAwait(false);

            return new ResultDTO(true, "User account created sucessfully, please confirm your email.", null);
        }

        #region CreateAndSendEmailConfirm
        private async Task CreateAndSendEmailConfirm(RegisterCreateDTO registerDTO, User user)
        {
            var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            string validToken = EncodeToken(confirmEmailToken);

            string url = $"{_configuration["AppUrl"]}/v1/confirmemail?userEmail={user.Email}&token={validToken}";
            //TODO
            await _mailService.SendEmailAsync(
                registerDTO.Email,
                "Confirm your email.",
                "<h1>Welcome to JarvisLogApi. </h1>" +
                $"<p>Please, confirm your email by <a href='{url}'> Clicking here.</a> </p>");
        }
        #endregion

        #region ConfirmEmail
        public async Task<ResultDTO> ConfirmEmail(string userMail, string token)
        {
            var user = await _userManager.FindByEmailAsync(userMail);

            if (user == null)
                return new ResultDTO(false, "User not found.", user);

            string validToken = DecodeToken(token);

            var result = await _userManager.ConfirmEmailAsync(user, validToken);

            if (!result.Succeeded)
                return new ResultDTO(false, "Email did not confirm.", result.Errors.Select(error => error.Description));

            return new ResultDTO(true, "Email confirmed successfuly.", null);
        }
        #endregion

        #endregion

        #region Login
        public async Task<ResultDTO> Login(LoginCreateDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
                return new ResultDTO(false, "Please, confirm your email, verify your password, verify your user name and try again.", user);

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!result.Succeeded)
                return new ResultDTO(false, "Please, confirm your email, verify your password, verify your user name and try again.", result);



            var token = _tokenService.GenerateJwtToken(user).Result;
            var userToReturn = _mapper.Map<LoginReadDTO>(user);
            userToReturn.AddToken(token);

            return new ResultDTO(true, "User authenticated.", userToReturn);
        }

        #endregion

        #region ForgotPass
        public async Task<ResultDTO> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDTO.Email);

            if (user == null)
                return new ResultDTO(false, "User not found", user);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await ResetPassword(user, token).ConfigureAwait(false);

            if (result.Success == false)
                return result;

            //TODO
            await _mailService.SendEmailAsync(
               forgotPasswordDTO.Email,
               "Forgot password.",
               "<h1>Acess with your new password and change. </h1>" +
               $"<p>Your new password is: {result.Data} </p>");

            return new ResultDTO(true, $"A new password has been sent to the email: {forgotPasswordDTO.Email}", null);

        }
        #endregion

        #region ResetPassword
        private async Task<ResultDTO> ResetPassword(User user, string token)
        {
            if (user == null || string.IsNullOrWhiteSpace(token))
                return new ResultDTO(false, "User not found or invalid token", null);


            var randomPassword = Guid.NewGuid().ToString();

            var result = await _userManager.ResetPasswordAsync(user,
                     token, randomPassword);

            if (!result.Succeeded)
                return new ResultDTO(false, "User not found or invalid token", result.Errors.Select(error => error.Description));

            return new ResultDTO(true, "Password has been succesfuly reseted.", randomPassword);
        }
        #endregion

        #region Private Methods
        private static string EncodeToken(string token)
        {
            var bytesToken = Encoding.UTF8.GetBytes(token);
            return WebEncoders.Base64UrlEncode(bytesToken);
        }
        private static string DecodeToken(string token)
        {
            var encodedToken = WebEncoders.Base64UrlDecode(token);

            return Encoding.UTF8.GetString(encodedToken);
        }
        #endregion

    }
}
