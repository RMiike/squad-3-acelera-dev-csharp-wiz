using CentralDeErro.Core.Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralDeErro.Tests.Entities.DTOs
{
    [TestClass]
    public class LoginCreateDTOTest
    {
        #region private
        private readonly string _email = "teste@teste.com";
        private readonly string _password = "12345678";
        #endregion

        [TestMethod]
        public void Check_Email_Is_Invalid()
        {
            var loginCreateDTO = new LoginCreateDTO
            {
                Email = "email",
                Password = _password
            };

            loginCreateDTO.Validate();

            Assert.IsTrue(loginCreateDTO.Invalid);
        }
        [TestMethod]
        public void Check_Email_Is_Valid()
        {
            var loginCreateDTO = new LoginCreateDTO
            {
                Email = _email,
                Password = _password
            };

            loginCreateDTO.Validate();

            Assert.IsTrue(loginCreateDTO.Valid);
        }
        [TestMethod]
        public void Check_Password_Is_Valid()
        {
            var loginCreateDTO = new LoginCreateDTO
            {
                Email = _email,
                Password = _password
            };

            loginCreateDTO.Validate();

            Assert.IsTrue(loginCreateDTO.Valid);
        }
        [TestMethod]
        public void Check_Password_Greater_Than_7_Chars()
        {
            var loginCreateDTO = new LoginCreateDTO
            {
                Email = _email,
                Password = "1234567"
            };

            loginCreateDTO.Validate();

            Assert.IsTrue(loginCreateDTO.Invalid);
        }
        [TestMethod]
        public void Check_Password_Smaller_or_Equals_100_Chars()
        {
            var loginCreateDTO = new LoginCreateDTO
            {
                Email = _email,
                Password = new string('*', 101)
            };

            loginCreateDTO.Validate();

            Assert.IsTrue(loginCreateDTO.Invalid);
        }
    }
}
