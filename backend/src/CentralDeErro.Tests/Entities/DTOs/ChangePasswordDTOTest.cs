using CentralDeErro.Core.Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralDeErro.Tests.Entities.DTOs
{
    [TestClass]
    public class ChangePasswordDTOTest
    {

        #region props
        private readonly string _oldPassword = "Old Password";
        private readonly string _newPassword = "New Password";
        private readonly string _confirmPassword = "New Password";
        #endregion

        [TestMethod]
        public void OldPassword_Must_Be_Old_Password()
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = _oldPassword,
                NewPassword = _newPassword,
                ConfirmPassword = _confirmPassword
            };

            Assert.AreEqual("Old Password", user.OldPassword);
        }
        [TestMethod]
        public void OldPassword_Must_Have_At_Least_8_Chars()
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
        public void OldPassowrd_Must_Be_Shorter_Or_Equal_Than_100_Chars()
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
        public void NewPassowrd_Must_Be_NewPassword()
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
        public void NewPassword_Must_Have_At_Least_8_Chars()
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
        public void NewPassword_Must_Be_Shorter_Or_Equal_Than_100_Chars()
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
        public void ConfirmPassword_Must_Be_New_Password()
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
        public void ConfirmPassword_Must_Have_At_Least_8_Chars()
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
        public void ConfirmPassword_Must_Be_Shorter_Or_Equal_Than_100_Chars()
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
        public void ConfirmPassword_Must_Be_Equals_NewPassword()
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
