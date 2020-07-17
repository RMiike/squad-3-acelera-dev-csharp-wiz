using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Infrastructure.Services;
using CentralDeErro.Tests._3_InfrastructureTests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErro.Tests._3_InfrastructureTests.Repositories
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        [DataTestMethod]
        [DataRow("Cardoso Silva","Cardoso@hotmail.com", "12345678", "12345678")]
        public void Deve_Registrar_Usuario(
          string fullName,
          string email,
          string confirmPassword,
          string password
          )
        {
            Task<ResultDTO> result = CreateControlerAndRegister(fullName, email, confirmPassword, password);

            Assert.AreEqual("User account created sucessfully, please confirm your email.", result.Result.Message);
            Assert.IsNull(result.Result.Data);
            Assert.IsTrue(result.Result.Success);
        }

        [DataTestMethod]
        [DataRow("Cardoso Silva", "Cardoso@hotmail.com", "!@#$%¨&**(**&", "!@#$%¨&**(**&")]
        public void Deve_Falhar_Se_A_Senha_Nova_Tiver_Caractere_Invalido(
          string fullName,
          string email,
          string confirmPassword,
          string password
          )
        {
            Task<ResultDTO> result = CreateControlerAndRegister(fullName, email, confirmPassword, password);

            Assert.AreEqual("Failed : ", result.Result.Message);
            Assert.IsNull(result.Result.Data);
            Assert.IsFalse(result.Result.Success);
        }

        [DataTestMethod]
        [DataRow("Cardoso Silva", "Cardoso@Cardoso.com", "12345678", "12345678")]
        public void Deve_Falhar_Se_Usuario_Existir(
          string fullName,
          string email,
          string confirmPassword,
          string password
          )
        {
            Task<ResultDTO> result = CreateControlerAndRegister(fullName, email, confirmPassword, password);

            Assert.AreEqual("User already exist!", result.Result.Message);
            Assert.IsNull(result.Result.Data);
            Assert.IsFalse(result.Result.Success);
        }

        [DataTestMethod]
        [DataRow("Cardoso@Cardoso.com", "b15")]
        public void Deve_Confirmar_Email(string email, string token)
        {
            var fakeContext = new FakeContext("AccountManagerServiceTests");
            var fakeUserManager = fakeContext.FakeUserManager().Object;
            var fakeSignInManager = fakeContext.FakeSigninManager().Object;

            var controller = new AuthenticationService(fakeUserManager, fakeSignInManager, fakeContext._mapper, fakeContext._tokenService, fakeContext._configuration, fakeContext._mailService);

            var result = controller.ConfirmEmail(email, token);

            Assert.AreEqual("Email confirmed successfuly.", result.Result.Message);
            Assert.IsNull(result.Result.Data);
            Assert.IsTrue(result.Result.Success);

        }

        [DataTestMethod]
        [DataRow("Cardoso@hotmail.com", "b15")]
        public void Deve_Falhar_Confirmacao_De_Email_De_Usuario_Invalido(string email, string token)
        {
            var fakeContext = new FakeContext("AccountManagerServiceTests");
            var fakeUserManager = fakeContext.FakeUserManager().Object;
            var fakeSignInManager = fakeContext.FakeSigninManager().Object;

            var controller = new AuthenticationService(fakeUserManager, fakeSignInManager, fakeContext._mapper, fakeContext._tokenService, fakeContext._configuration, fakeContext._mailService);

            var result = controller.ConfirmEmail(email, token);

            Assert.AreEqual("User not found.", result.Result.Message);
            Assert.IsNull(result.Result.Data);
            Assert.IsFalse(result.Result.Success);

        }

        [DataTestMethod]
        [DataRow("Falha@Falha.com", "b15")]
        public void Deve_Falhar_Se_Nao_Conseguir_confirmar_Email(string email, string token)
        {
            var fakeContext = new FakeContext("AccountManagerServiceTests");
            var fakeUserManager = fakeContext.FakeUserManager().Object;
            var fakeSignInManager = fakeContext.FakeSigninManager().Object;

            var controller = new AuthenticationService(fakeUserManager, fakeSignInManager, fakeContext._mapper, fakeContext._tokenService, fakeContext._configuration, fakeContext._mailService);

            var result = controller.ConfirmEmail(email, token);

            Assert.AreEqual("Email did not confirm.", result.Result.Message);
            Assert.IsNotNull(result.Result.Data);
            Assert.IsFalse(result.Result.Success);

        }




        private static Task<ResultDTO> CreateControlerAndRegister(string fullName, string email, string confirmPassword, string password)
        {
            var fakeContext = new FakeContext("AccountManagerServiceTests");
            var fakeUserManager = fakeContext.FakeUserManager().Object;
            var fakeSignInManager = fakeContext.FakeSigninManager().Object;

            var controller = new AuthenticationService(fakeUserManager, fakeSignInManager, fakeContext._mapper, fakeContext._tokenService, fakeContext._configuration, fakeContext._mailService);
            var registerDTO = new RegisterCreateDTO { FullName = fullName, Email = email, Password = password, ConfirmPassword = confirmPassword }; ;

            var result = controller.Register(registerDTO);
            return result;
        }
    }
}
