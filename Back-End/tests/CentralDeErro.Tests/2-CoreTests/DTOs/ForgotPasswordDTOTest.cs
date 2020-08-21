using CentralDeErro.Core.Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralDeErro.Tests._2_CoreTests.DTOs
{
    [TestClass]

    public class ForgotPasswordDTOTest
    {
      
        [DataTestMethod]
        [DataRow("Email")]
        public void Check_Invalid_Email(string email)
        {
            var forgotPasswordDto = new ForgotPasswordDTO { Email = email };

            forgotPasswordDto.Validate();
            Assert.IsTrue(forgotPasswordDto.Invalid);
        }

        [DataTestMethod]
        [DataRow("teste@teste.com")]
        public void Check_Email_Is_Valid(string email)
        {
            var forgotPasswordDto = new ForgotPasswordDTO { Email = email };

            forgotPasswordDto.Validate();
            Assert.IsTrue(forgotPasswordDto.Valid);
        }

        [DataTestMethod]
        [DataRow("Email")]
        public void Check_Email(string email)
        {
            var forgotPasswordDto = new ForgotPasswordDTO();
            Assert.IsNull(forgotPasswordDto.Email);

            forgotPasswordDto.Email = email;

            Assert.AreEqual(email, forgotPasswordDto.Email);

            forgotPasswordDto.Validate();
            Assert.IsTrue(forgotPasswordDto.Invalid);
        }
        [DataTestMethod]
        [DataRow("teste@teste.com")]
        public void Email_Deve_Ser_Um_testeArrobaTestePontoCom(string email)
        {
            var forgotPasswordDto = new ForgotPasswordDTO { Email = email };

            Assert.AreEqual(email, forgotPasswordDto.Email);
        }
    }
}
