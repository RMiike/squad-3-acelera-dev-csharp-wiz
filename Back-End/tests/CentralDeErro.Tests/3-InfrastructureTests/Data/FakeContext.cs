using AutoMapper;
using CentralDeErro.ApplicationServices.Services;
using CentralDeErro.Core.Contracts.Repositories;
using CentralDeErro.Core.Contracts.Services;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace CentralDeErro.Tests._3_InfrastructureTests.Data
{
    class FakeContext
    {
        public DbContextOptions<CentralDeErrorContext> FakeOptions { get; }
        public readonly IMapper _mapper;
        public readonly IConfiguration _configuration;
        public readonly ITokenService _tokenService;
        public readonly IMailService _mailService;

        private Dictionary<Type, string> DataFileNames { get; } =
            new Dictionary<Type, string>();
        private string FileName<T>() { return DataFileNames[typeof(T)]; }

        public FakeContext(string testName)
        {
            FakeOptions = new DbContextOptionsBuilder<CentralDeErrorContext>()
                .UseInMemoryDatabase(databaseName: $"NewError_{testName}")
                .Options;

            AddData();
            _mapper = ConfigureMap().CreateMapper();
            _configuration = CreateConfigs();

            _mailService = new MailService(_configuration);
            _tokenService = new TokenService(_configuration,FakeUserManager().Object);
        }

       

        public List<T> Get<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public Mock<ISourceRepository> FakeSourceRepository()
        {
            var service = new Mock<ISourceRepository>();

            service.Setup(x => x.Get(It.IsAny<int>()))
                .Returns((int id) => Get<SourceReadDTO>().FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.Get())
                .Returns(() => Get<SourceReadDTO>().ToList());

            service.Setup(x => x.Create(It.IsAny<SourceCreateDTO>()))
                .Returns((SourceCreateDTO source) =>
                {

                    if (source.Address == "Back-End" && source.Environment == Core.Enums.Environment.Homologation)
                    {
                        return new ResultDTO(false, "Source already existis.", null);
                    }
                    SourceReadDTO newSorce = new SourceReadDTO(66, source.Address, source.Environment.ToString());
                    return new ResultDTO(true, "Succesfully registred the source.", newSorce);
                });

            service.Setup(x => x.Delete(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var sourceDataBase = Get<SourceReadDTO>().FirstOrDefault(x => x.Id == id);
                    if (sourceDataBase == null)
                        return new ResultDTO(false, $"Source id: {id} not found.", null);

                    return new ResultDTO(true, "Successfuly deleted.", sourceDataBase);

                });

            return service;
        }
        public Mock<IErrorRepository> FakeErrorRepository()
        {
            var service = new Mock<IErrorRepository>();

            service.Setup(x => x.Get(It.IsAny<int>()))
                .Returns((int id) => Get<ErrorReadDTO>().FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.Get())
                .Returns(() => Get<ErrorReadDTO>().ToList());

            service.Setup(x => x.Create(It.IsAny<ErrorCreateDTO>(), It.IsAny<ClaimsPrincipal>()))
                .Returns((ErrorCreateDTO e, ClaimsPrincipal claimsPrincipal) =>
                {
         
                    if (Get<SourceReadDTO>().Where(x => x.Id == e.SourceId).FirstOrDefault() == null)
                        return new ResultDTO(false, "Invalid Source Id.", null);

                    var result = Get<RegisterCreateDTO>().FirstOrDefault();
                    var user = User.Create(result.FullName, result.Email, result.Email);
                    var newError = Error.Create(22, user.Id, e.Title, e.Details, e.Level, e.SourceId);
                    return new ResultDTO(true, "Succesfully registred the error.", newError);
                });


            service.Setup(x => x.Archive(It.IsAny<int>()))
               .Returns((int id) =>
               {
                   var errorDataBase = Get<ErrorReadDTO>().FirstOrDefault(x => x.Id == id);
                   if (errorDataBase == null)
                       return new ResultDTO(false, $"Error id: {id} not found.", null);

                   if (errorDataBase.Id == 3)
                       return new ResultDTO(false, $"Error id: {id} already archived.", null);

                   return new ResultDTO(true, "Successfuly archived.", errorDataBase);

               });

            service.Setup(x => x.Unarchive(It.IsAny<int>()))
               .Returns((int id) =>
               {
                   var errorDataBase = Get<ErrorReadDTO>().FirstOrDefault(x => x.Id == id);

                   if (errorDataBase == null)
                       return new ResultDTO(false, $"Error id: {id} not found.", null);

                   if (errorDataBase.Id == 1)
                       return new ResultDTO(false, $"Error id: {id} already unarchived.", null);

                   return new ResultDTO(true, "Successfuly unarchived.", errorDataBase);

               });
            service.Setup(x => x.Delete(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    var errorDataBase = Get<ErrorReadDTO>().FirstOrDefault(x => x.Id == id);
                    if (errorDataBase == null)
                        return new ResultDTO(false, $"Error id: {id} not found.", null);

                    return new ResultDTO(true, "Successfuly deleted.", errorDataBase);

                });

            return service;
        }
        public Mock<IAccountManagerService> FakeAccountManagerRepository()
        {
            var service = new Mock<IAccountManagerService>();

            service.Setup(x => x.ChangePassword(It.IsAny<ChangePasswordDTO>(), It.IsAny<ClaimsPrincipal>()))
                .ReturnsAsync((ChangePasswordDTO changePasswordDTO, ClaimsPrincipal claims) =>
                {
                    changePasswordDTO.Validate();

                    if (changePasswordDTO.Invalid)
                        return new ResultDTO(false, "An error ocurred.", changePasswordDTO.Notifications);

                    if (changePasswordDTO.NewPassword == "nouserautenticated")
                        return new ResultDTO(false, "User data not found!", null);

                    if (changePasswordDTO.NewPassword == "successfail")
                        return new ResultDTO(false, "An error ocurred.", null);

                    return new ResultDTO(true, "Password was changed successfully.", null);
                });

            return service;
        }
        public Mock<IAuthenticationService> FakeAuthenticationRepository()
        {
            var service = new Mock<IAuthenticationService>();

            service.Setup(x => x.Register(It.IsAny<RegisterCreateDTO>()))
                .ReturnsAsync((RegisterCreateDTO registerCreateDTO) =>
                {
                    registerCreateDTO.Validate();
                    if (registerCreateDTO.Invalid)
                        return new ResultDTO(false, "Invalid field.", registerCreateDTO.Notifications);

                    var user = Get<RegisterCreateDTO>().Find(x => x.Email == registerCreateDTO.Email);

                    if (user != null)
                        return new ResultDTO(false, "User already exist!", null);


                    return new ResultDTO(true, "User account created sucessfully, please confirm your email.", null);
                });

            service.Setup(x => x.Login(It.IsAny<LoginCreateDTO>()))
               .ReturnsAsync((LoginCreateDTO loginCreateDTO) =>
               {
                   loginCreateDTO.Validate();

                   if (loginCreateDTO.Invalid)
                       return new ResultDTO(false, "Invalid field.", loginCreateDTO.Notifications);

                   var result = Get<LoginCreateDTO>().Find(x => x.Email == loginCreateDTO.Email);

                   if (result == null)
                       return new ResultDTO(false, "Please, confirm your email, verify your password, verify your user name and try again.", null);

                   if (result.Password != loginCreateDTO.Password)
                       return new ResultDTO(false, "Please, confirm your email, verify your password, verify your user name and try again.", result);

                   var user = User.Create(loginCreateDTO.Email, loginCreateDTO.Email, loginCreateDTO.Email);
                   var userToReturn = _mapper.Map<LoginReadDTO>(user);
                   userToReturn.AddToken("Token");

                   return new ResultDTO(true, "User authenticated.", userToReturn);
               });

            service.Setup(x => x.ConfirmEmail(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((string email, string token) =>
                {
                    if (String.IsNullOrEmpty(email) && String.IsNullOrEmpty(token))
                        return new ResultDTO(false, "Wrong email or invalid token", null);

                    var user = Get<LoginCreateDTO>().Where(x => x.Email == email).FirstOrDefault();

                    if (user == null)
                        return new ResultDTO(false, "User not found.", null);

                    if (token == "emailnaoconfirmado")
                        return new ResultDTO(false, "Email did not confirm.", null);

                    return new ResultDTO(true, "Email confirmed successfuly.", null);
                });

            service.Setup(x => x.ForgotPassword(It.IsAny<ForgotPasswordDTO>()))
                .ReturnsAsync((ForgotPasswordDTO forgotPasswordDTO) =>
                {
                    forgotPasswordDTO.Validate();

                    if (forgotPasswordDTO.Invalid)
                        return new ResultDTO(false, "Wrong email, please verify and try again.", forgotPasswordDTO.Notifications);

                    var result = Get<ForgotPasswordDTO>().Where(x => x.Email == forgotPasswordDTO.Email).FirstOrDefault();

                    if (result == null)
                        return new ResultDTO(false, "User not found", result);

                    return new ResultDTO(true, $"A new password has been sent to the email: {forgotPasswordDTO.Email}", null);
                });

            return service;
        }

        public Mock<FakeUserManager> FakeUserManager()
        {
            var service = new Mock<FakeUserManager>();

            service.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
                .ReturnsAsync((ClaimsPrincipal claimsPrincipal) =>
                {
                    var result = Get<RegisterCreateDTO>().Where( x=> x.Email == claimsPrincipal.Claims.FirstOrDefault().Value).FirstOrDefault();
                   
                    if(result==null)
                        return null;

                    var user = User.Create(result.FullName, result.Email, result.Email);
                    return user;

                });
    
            service.Setup(x => x.ChangePasswordAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((User user, string oldPassword, string newPassword) =>
                {
                    var dataUser = Get<RegisterCreateDTO>().Where(x => x.Email == user.Email).FirstOrDefault();

                    if (dataUser == null)
                        return IdentityResult.Failed(new IdentityError());

                    if (oldPassword != dataUser.Password)
                        return IdentityResult.Failed(new IdentityError());

                    return IdentityResult.Success;
                });

            service.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((string email) =>
                {
                    var result = Get<RegisterCreateDTO>().Where(x => x.Email == email).FirstOrDefault();

                    if (result == null)
                        return null;

                    var user = User.Create(result.FullName, result.Email, result.Email);
                    return user;
                });

            service.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync((User user, string password) =>
                {
                    var result = Get<RegisterCreateDTO>().Where(x => x.Email == user.Email).FirstOrDefault();

                    if (password == "!@#$%¨&**(**&")
                        return IdentityResult.Failed(new IdentityError());

                    return IdentityResult.Success;
                });

            service.Setup(x => x.GenerateEmailConfirmationTokenAsync(It.IsAny<User>()))
                .ReturnsAsync(() =>
                {
                    return "token";
                });

            service.Setup(x => x.ConfirmEmailAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync((User user, string token) =>
                {
                    var result = Get<RegisterCreateDTO>().Where(x => x.Email == user.Email).FirstOrDefault();

                    result.Validate();
                    if (result.Invalid)
                        return IdentityResult.Failed(new IdentityError());

                    return IdentityResult.Success;

                });

            service.Setup(x => x.GetRolesAsync(It.IsAny<User>()))
                 .ReturnsAsync((User user) =>
                 {
                     var result = Get<RegisterCreateDTO>().Where(x => x.Email == user.Email).FirstOrDefault(); 
                     return new List<string>();
                 });

            service.Setup(x => x.GeneratePasswordResetTokenAsync(It.IsAny<User>()))
                .ReturnsAsync(() =>
                {

                    return "token";
                });

            service.Setup(x => x.ResetPasswordAsync(It.IsAny<User>(),It.IsAny<string>(), It.IsAny<string>()))
               .ReturnsAsync((User user, string token, string newPassword) =>
               {
                   if (user.Email == "Falha@Falha.com")
                       return IdentityResult.Failed(new IdentityError());

                   return IdentityResult.Success;
               });

            return service;

        }

        public Mock<FakeSignInManager> FakeSigninManager()
        {
            var service = new Mock<FakeSignInManager>();

            service.Setup(x => x.CheckPasswordSignInAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync((User user, string password, bool lockotOnFail) =>
                {
                    var result = Get<RegisterCreateDTO>().Where(x => x.Email == user.Email).FirstOrDefault();
                    if (result.Password != password)
                        return SignInResult.Failed;

                    return SignInResult.Success;
                });

            return service;
        }
        public void FillWithAllErrors()
        {
            FillWithAllSource();
            FillWithAllUsers();
            using (var context = new CentralDeErrorContext(FakeOptions))
            {
                if (context.Errors.Count() == 0)
                {
                    foreach (var item in Get<ErrorCreateDTO>())
                    {
                        var user = context.Users.FirstOrDefault();
                        item.AddUserId(user.Id);
                        var error = Error.Create(item.Id, item.UserId, item.Title, item.Details, item.Level, item.SourceId);
                        context.Add(error);
                        context.SaveChanges();
                    }
                }
            }
        }
        public void FillWithAllSource()
        {
            using (var context = new CentralDeErrorContext(FakeOptions))
            {
                if (context.Sources.Count() == 0)
                {
                    foreach (var item in Get<SourceCreateDTO>())
                    {
                        var source = Source.Create(item.Id, item.Address, item.Environment);
                        context.Add(source);
                        context.SaveChanges();
                    }
                }
            }
        }

        public void FillWithAllUsers()
        {
            using (var context = new CentralDeErrorContext(FakeOptions))
            {
                if (context.Users.Count() == 0)
                {
                    foreach (var item in Get<RegisterCreateDTO>())
                    {
                        var user = User.Create(item.FullName, item.Email, item.Email);
                        context.Add(user);
                        context.SaveChanges();
                    }
                }
            }
        }
        private static MapperConfiguration ConfigureMap()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, LoginReadDTO>();
                cfg.CreateMap<Error, ErrorCreateDTO>().ReverseMap().ConvertUsing(s => Error.Create(s.Id, s.UserId, s.Title, s.Details, s.Level, s.SourceId));
                cfg.CreateMap<Source, SourceCreateDTO>().ReverseMap().ConvertUsing(s => Source.Create(s.Id, s.Address, s.Environment));
            });
        }
        private void AddData()
        {
            DataFileNames.Add(typeof(SourceReadDTO), $"../../../3-InfrastructureTests/Data/FakeData{Path.DirectorySeparatorChar}FakeSources.json");
            DataFileNames.Add(typeof(SourceCreateDTO), $"../../../3-InfrastructureTests/Data/FakeData{Path.DirectorySeparatorChar}FakeSources.json");
            DataFileNames.Add(typeof(Source), $"../../../Data/FakeData{Path.DirectorySeparatorChar}FakeSources.json");
            DataFileNames.Add(typeof(ErrorReadDTO), $"../../../3-InfrastructureTests/Data/FakeData{Path.DirectorySeparatorChar}FakeErrors.json");
            DataFileNames.Add(typeof(ErrorCreateDTO), $"../../../3-InfrastructureTests/Data/FakeData{Path.DirectorySeparatorChar}FakeErrors.json");
            DataFileNames.Add(typeof(Error), $"../../../3-InfrastructureTests/Data/FakeData{Path.DirectorySeparatorChar}FakeErrors.json");
            DataFileNames.Add(typeof(User), $"../../../3-InfrastructureTests/Data/FakeData{Path.DirectorySeparatorChar}FakeUser.json");
            DataFileNames.Add(typeof(RegisterCreateDTO), $"../../../3-InfrastructureTests/Data/FakeData{Path.DirectorySeparatorChar}FakeUser.json");
            DataFileNames.Add(typeof(LoginCreateDTO), $"../../../3-InfrastructureTests/Data/FakeData{Path.DirectorySeparatorChar}FakeUser.json");
            DataFileNames.Add(typeof(LoginReadDTO), $"../../../3-InfrastructureTests/Data/FakeData{Path.DirectorySeparatorChar}FakeUser.json");
            DataFileNames.Add(typeof(ForgotPasswordDTO), $"../../../3-InfrastructureTests/Data/FakeData{Path.DirectorySeparatorChar}FakeForgotPasswor.json");
        }
        private static IConfigurationRoot CreateConfigs()
        {
              var config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json", optional: true).Build();
            return config;
        }
    }
}
