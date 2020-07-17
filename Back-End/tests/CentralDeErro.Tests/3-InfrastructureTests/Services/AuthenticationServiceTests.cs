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
            Task<ResultDTO> result = CreateControlerAndUseService(fullName, email, confirmPassword, password);

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
            Task<ResultDTO> result = CreateControlerAndUseService(fullName, email, confirmPassword, password);

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
            Task<ResultDTO> result = CreateControlerAndUseService(fullName, email, confirmPassword, password);

            Assert.AreEqual("User already exist!", result.Result.Message);
            Assert.IsNull(result.Result.Data);
            Assert.IsFalse(result.Result.Success);
        }

        [DataTestMethod]
        [DataRow("Cardoso@Cardoso.com", "b15")]
        public void Deve_Confirmar_Email(string email, string token)
        {
            Task<ResultDTO> result = CreateControlerAndUseService(email:email, token:token);

            Assert.AreEqual("Email confirmed successfuly.", result.Result.Message);
            Assert.IsNull(result.Result.Data);
            Assert.IsTrue(result.Result.Success);

        }

        

        [DataTestMethod]
        [DataRow("Cardoso@hotmail.com", "b15")]
        public void Deve_Falhar_Confirmacao_De_Email_De_Usuario_Invalido(string email, string token)
        {
            Task<ResultDTO> result = CreateControlerAndUseService(email: email, token: token);

            Assert.AreEqual("User not found.", result.Result.Message);
            Assert.IsNull(result.Result.Data);
            Assert.IsFalse(result.Result.Success);

        }

        [DataTestMethod]
        [DataRow("Falha@Falha.com", "b15")]
        public void Deve_Falhar_Se_Nao_Conseguir_confirmar_Email(string email, string token)
        {
            Task<ResultDTO> result = CreateControlerAndUseService(email:email, token:token);

            Assert.AreEqual("Email did not confirm.", result.Result.Message);
            Assert.IsNotNull(result.Result.Data);
            Assert.IsFalse(result.Result.Success);

        }

        [DataTestMethod]
        [DataRow("Cardoso@Cardoso.com", "asd123123as-09(I")]
        public void Deve_Realizar_Login(string email, string password)
        {
            Task<ResultDTO> result = CreateControlerAndUseService(email:email, password:password);

            Assert.IsTrue(result.Result.Success);
            Assert.IsInstanceOfType(result.Result, typeof(ResultDTO));
            Assert.AreEqual("User authenticated.", result.Result.Message);
        }

      

        [DataTestMethod]
        [DataRow("Cardoso@hotmail.com", "asd123123as-09(I")]
        public void Deve_Falhar_Ao_tentar_Realizar_Login_Se_usuario_For_null(string email, string password)
        {
            Task<ResultDTO> result = CreateControlerAndUseService(email: email, password: password);


            Assert.IsFalse(result.Result.Success);
            Assert.IsNull(result.Result.Data);
            Assert.IsInstanceOfType(result.Result, typeof(ResultDTO));
            Assert.AreEqual("Please, confirm your email, verify your password, verify your user name and try again.", result.Result.Message);
        }

        [DataTestMethod]
        [DataRow("Cardoso@Cardoso.com", "a1sd123123as-09(I")]
        public void Deve_Falhar_Ao_Se_Senha_Estiver_Errada(string email, string password)
        {
            Task<ResultDTO> result = CreateControlerAndUseService(email: email, password: password);

            Assert.IsFalse(result.Result.Success);
            Assert.IsNotNull(result.Result.Data);
            Assert.AreEqual("Please, confirm your email, verify your password, verify your user name and try again.", result.Result.Message);
            Assert.IsInstanceOfType(result.Result, typeof(ResultDTO));
        }

        [DataTestMethod]
        [DataRow("Cardoso@Cardoso.com")]
        public void Deve_Realizar_Reset_De_Senha_E_Enviar_Email(string email)
        {
            Task<ResultDTO> result = CreateControlerAndUseService(email: email);


            Assert.IsTrue(result.Result.Success);
            Assert.IsNull(result.Result.Data);
            Assert.AreEqual($"A new password has been sent to the email: {email}", result.Result.Message);
            Assert.IsInstanceOfType(result.Result, typeof(ResultDTO));
        }


        [DataTestMethod]
        [DataRow("Ana@Cardoso.com")]
        public void Deve_Falhar_Com_Usuario_Invalido(string email)
        {
            Task<ResultDTO> result = CreateControlerAndUseService(email: email);


            Assert.IsFalse(result.Result.Success);
            Assert.IsNull(result.Result.Data);
            Assert.AreEqual("User not found", result.Result.Message);
            Assert.IsInstanceOfType(result.Result, typeof(ResultDTO));
        }

        [DataTestMethod]
        [DataRow("Falha@Falha.com")]
        public void Deve_Falhar_Se_Nao_Resetar_Senha(string email)
        {
            Task<ResultDTO> result = CreateControlerAndUseService(email:email);

            Assert.IsFalse(result.Result.Success);
            Assert.IsNotNull(result.Result.Data);
            Assert.AreEqual("User not found or invalid token", result.Result.Message);
            Assert.IsInstanceOfType(result.Result, typeof(ResultDTO));
        }

        private static Task<ResultDTO> CreateControlerAndUseService(
            string fullName = null, 
            string email = null, 
            string confirmPassword = null, 
            string password = null,
            string token = null
            )
        {
            var fakeContext = new FakeContext("AccountManagerServiceTests");
            var fakeUserManager = fakeContext.FakeUserManager().Object;
            var fakeSignInManager = fakeContext.FakeSigninManager().Object;

            var controller = new AuthenticationService(fakeUserManager, fakeSignInManager, fakeContext._mapper, fakeContext._tokenService, fakeContext._configuration, fakeContext._mailService);
            
            if(fullName != null)
            {
                var registerDTO = new RegisterCreateDTO { FullName = fullName, Email = email, Password = password, ConfirmPassword = confirmPassword }; ;
                return controller.Register(registerDTO);

            } else if( token != null)
            {
                var result = controller.ConfirmEmail(email, token);
                return result;
            } else if( password != null)
            {
                var loginDTO = new LoginCreateDTO { Email = email, Password = password };

                return controller.Login(loginDTO);
            } 
            
            var forgotPasswordDTO = new ForgotPasswordDTO { Email = email };
            return controller.ForgotPassword(forgotPasswordDTO);
        }

    }
}
