using CentralDeErro.Core.Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralDeErro.Tests.Entities.DTOs
{
    [TestClass]

    public class ForgotPasswordDTOTest
    {
        [TestMethod]
        public void Email_Invalido_Nao_Passa()
        {
            var forgotPasswordDto = new ForgotPasswordDTO { Email = "email" };

            forgotPasswordDto.Validate();
            Assert.IsTrue(forgotPasswordDto.Invalid);
        }
        [TestMethod]
        public void Email_Deve_Ser_Um_Email_Valido()
        {
            var forgotPasswordDto = new ForgotPasswordDTO { Email = "teste@teste.com" };

            forgotPasswordDto.Validate();
            Assert.IsFalse(forgotPasswordDto.Invalid);
        }
        [TestMethod]
        public void Email_Deve_Ser_Um_testeArrobaTestePontoCom()
        {
            var forgotPasswordDto = new ForgotPasswordDTO { Email = "teste@teste.com" };

            Assert.AreEqual("teste@teste.com",forgotPasswordDto.Email);
        }
    }
}
