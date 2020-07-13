using CentralDeErro.Core.Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralDeErro.Tests.Entities.DTOs
{
    [TestClass]

    public class ForgotPasswordDTOTest
    {
        [TestMethod]
        public void Check_Invalid_Email()
        {
            var forgotPasswordDto = new ForgotPasswordDTO { Email = "email" };

            forgotPasswordDto.Validate();
            Assert.IsTrue(forgotPasswordDto.Invalid);
        }
        [TestMethod]
        public void Check_Email_Is_Valid()
        {
            var forgotPasswordDto = new ForgotPasswordDTO { Email = "teste@teste.com" };

            forgotPasswordDto.Validate();
            Assert.IsFalse(forgotPasswordDto.Invalid);
        }
        [TestMethod]
        public void Check_Email()
        {
            var forgotPasswordDto = new ForgotPasswordDTO { Email = "teste@teste.com" };

            Assert.AreEqual("teste@teste.com",forgotPasswordDto.Email);
        }
    }
}
