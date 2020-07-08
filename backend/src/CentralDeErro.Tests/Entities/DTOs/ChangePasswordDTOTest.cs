using CentralDeErro.Core.Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralDeErro.Tests.Entities.DTOs
{
    [TestClass]
    public class ChangePasswordDTOTest
    {

        #region props
        private readonly string _oldPassword = "OldPassword";
        private readonly string _newPassword = "NewPassword";
        private readonly string _confirmPassword = "NewPassword";
        #endregion

        [TestMethod]
        public void O_Antigo_Password_Deve_Ser_OldPassword()
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = _oldPassword,
                NewPassword = _newPassword,
                ConfirmPassword = _confirmPassword
            };

            Assert.AreEqual("OldPassword", user.OldPassword);
        }
        [TestMethod]
        public void O_Antigo_Password_Deve_Ter_Mais_De_8_Chars()
        {
            var user = new ChangePasswordDTO{ 
                OldPassword = "1234567",
                NewPassword = _newPassword,
                ConfirmPassword = _confirmPassword
            };

            user.Validate();

            Assert.IsTrue(user.Invalid, "Old password must have at least 8 chars");
        }
        [TestMethod]
        public void O_Antigo_Password_Deve_Ter_Menos_De_100_Chars()
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = new string('x', 101),
                NewPassword = _newPassword,
                ConfirmPassword = _confirmPassword
            };

            user.Validate();

            Assert.IsTrue(user.Invalid, "Old password must shorter or equal than 100 chars");
        }

        [TestMethod]
        public void O_Novo_Password_Deve_Ser_NewPassword()
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = _oldPassword,
                NewPassword = _newPassword,
                ConfirmPassword = _confirmPassword
            };

            Assert.AreEqual("NewPassword", user.NewPassword);
        }
        [TestMethod]
        public void O_Novo_Password_Deve_Ter_Mais_De_8_Chars()
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = _oldPassword,
                NewPassword = "1234567",
                ConfirmPassword = _confirmPassword
            };

            user.Validate();

            Assert.IsTrue(user.Invalid, "New Password must have at least 8 chars");
        }
        [TestMethod]
        public void O_Novo_Password_Deve_Ter_Menos_De_100_Chars()
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = _oldPassword,
                NewPassword = new string('x', 101),
                ConfirmPassword = _confirmPassword
            };

            user.Validate();

            Assert.IsTrue(user.Invalid, "New Password must shorter or equal than 100 chars");
        }
        [TestMethod]
        public void A_Confirmacao_Password_Deve_Ser_NewPassword()
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = _oldPassword,
                NewPassword = _newPassword,
                ConfirmPassword = _confirmPassword
            };

            Assert.AreEqual("NewPassword", user.ConfirmPassword);
        }
        [TestMethod]
        public void A_Confirmacao_De_Password_Deve_Ter_Mais_De_8_Chars()
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = _oldPassword,
                NewPassword = _newPassword,
                ConfirmPassword = "1234567"
            };

            user.Validate();

            Assert.IsTrue(user.Invalid, "Confirm password must have at least 8 chars");
        }
        [TestMethod]
        public void A_Confirmacao_De_Password_Deve_Ter_Menos_De_100_Chars()
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = _oldPassword,
                NewPassword = _newPassword,
                ConfirmPassword = new string('x', 101)
            };

            user.Validate();

            Assert.IsTrue(user.Invalid, "Confirm password must shorter or equal than 100 chars");
        }
        [TestMethod]
        public void A_Confirmacao_De_Password_Deve_Ser_Igual_A_Nova_Senha()
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = _oldPassword,
                NewPassword = _newPassword,
                ConfirmPassword = _confirmPassword
            };

            user.Validate();

            Assert.AreEqual(user.NewPassword, user.ConfirmPassword);
        }
    }
}
