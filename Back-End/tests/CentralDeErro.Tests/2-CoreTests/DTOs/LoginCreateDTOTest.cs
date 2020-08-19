using CentralDeErro.Core.Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralDeErro.Tests._2_CoreTests.DTOs
{
    [TestClass]
    public class LoginCreateDTOTest
    {

        [DataTestMethod]
        [DataRow("teste@teste.com", "12345678")]
        public void LoginCreate_Valid_Should_Pass(string email, string password)
        {
            var loginCreateDTO = new LoginCreateDTO();

            Assert.IsNull(loginCreateDTO.Email);
            Assert.IsNull(loginCreateDTO.Password);

            loginCreateDTO.Email = email;
            loginCreateDTO.Password = password;

            Assert.IsNotNull(loginCreateDTO);
            Assert.AreEqual(email, loginCreateDTO.Email);
            Assert.AreEqual(password, loginCreateDTO.Password);

            loginCreateDTO.Validate();

            Assert.IsTrue(loginCreateDTO.Valid);
        }


        [DataTestMethod]
        [DataRow("testeteste.com", "12345678")]
        public void Check_Email_Is_Invalid(string email, string password)
        {
            var loginCreateDTO = new LoginCreateDTO
            {
                Email = email,
                Password = password

            };

            loginCreateDTO.Validate();

            Assert.IsTrue(loginCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow("teste@teste.com", "12345678")]
        public void Check_Email_Is_Valid(string email, string password)
        {
            var loginCreateDTO = new LoginCreateDTO
            {
                Email = email,
                Password = password
            };

            loginCreateDTO.Validate();

            Assert.IsTrue(loginCreateDTO.Valid);
        }

        [DataTestMethod]
        [DataRow("teste@teste.com", "12345678")]
        public void Check_Password_Is_Valid(string email, string password)
        {
            var loginCreateDTO = new LoginCreateDTO
            {
                Email = email,
                Password = password
            };

            loginCreateDTO.Validate();

            Assert.IsTrue(loginCreateDTO.Valid);
        }

        [DataTestMethod]
        [DataRow("testeteste.com", "1234567")]
        public void Check_Password_Greater_Than_7_Chars(string email, string password)
        {
            var loginCreateDTO = new LoginCreateDTO
            {
                Email = email,
                Password = password
            };

            loginCreateDTO.Validate();

            Assert.IsTrue(loginCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow("testeteste.com")]
        public void Check_Password_Smaller_or_Equals_100_Chars(string email)
        {
            var loginCreateDTO = new LoginCreateDTO
            {
                Email = email,
                Password = new string('*', 101)
            };

            loginCreateDTO.Validate();

            Assert.IsTrue(loginCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow("token")]
        public void Deve_Adicionar_Token(string token)
        {
            var loginReadDTO = new LoginReadDTO();

            loginReadDTO.AddToken(token);

            Assert.IsNotNull(loginReadDTO.Token);
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Deve_falhar_se_nao_houver_token()
        {
            var loginReadDTO = new LoginReadDTO();

            loginReadDTO.AddToken(null);

        }
    }
}
