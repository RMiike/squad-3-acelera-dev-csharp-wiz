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
        public void Email_deve_ser_Valido()
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
        public void Email_valido_deve_Passar()
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
        public void Password_valido_deve_Passar()
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
        public void Email_deve_ter_pelo_menos_8_chars()
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
        public void Email_deve_ser_menor_ou_igual_a_100()
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
