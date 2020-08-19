using CentralDeErro.Core.Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralDeErro.Tests._2_CoreTests.DTOs
{
    [TestClass]
    public class ChangePasswordDTOTest
    {

        private readonly string giantpass = new string('x', 101);

        [DataTestMethod]
        [DataRow("Old Password", "New Password", "New Password")]
        public void OldPassword_Must_Be_Old_Password(string oldPassword, string newPassword, string confirmPassword)
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword = confirmPassword
            };

            Assert.AreEqual("Old Password", user.OldPassword);
        }

        [DataTestMethod]
        [DataRow("1234567", "New Password", "New Password")]
        public void OldPassword_Must_Have_At_Least_8_Chars(string oldPassword, string newPassword, string confirmPassword)
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword = confirmPassword
            };

            user.Validate();

            Assert.IsTrue(user.Invalid, "Old password must have at least 8 chars");
        }

        [DataTestMethod]
        [DataRow("New Password", "New Password")]
        public void OldPassowrd_Must_Be_Shorter_Or_Equal_Than_100_Chars(string newPassword, string confirmPassword)
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = giantpass,
                NewPassword = newPassword,
                ConfirmPassword = confirmPassword
            };

            user.Validate();

            Assert.IsTrue(user.Invalid, "Old password must shorter or equal than 100 chars");
        }

        [DataTestMethod]
        [DataRow("Old Password", "New Password", "New Password")]
        public void NewPassowrd_Must_Be_NewPassword(string oldPassword, string newPassword, string confirmPassword)
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword = confirmPassword
            };

            Assert.AreEqual("New Password", user.NewPassword);
        }

        [DataTestMethod]
        [DataRow("Old Password", "1234567", "New Password")]
        public void NewPassword_Must_Have_At_Least_8_Chars(string oldPassword, string newPassword, string confirmPassword)
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword = confirmPassword
            };

            user.Validate();

            Assert.IsTrue(user.Invalid, "New Password must have at least 8 chars");
        }

        [DataTestMethod]
        [DataRow("Old Password", "New Password")]
        public void NewPassword_Must_Be_Shorter_Or_Equal_Than_100_Chars(string oldPassword, string confirmPassword)
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = oldPassword,
                NewPassword = new string('x', 101),
                ConfirmPassword = confirmPassword
            };

            user.Validate();

            Assert.IsTrue(user.Invalid, "New Password must be shorter or equal than 100 chars");
        }

        [DataTestMethod]
        [DataRow("Old Password", "New Password", "New Password")]
        public void ConfirmPassword_Must_Be_New_Password(string oldPassword, string newPassword, string confirmPassword)
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword = confirmPassword
            };

            Assert.AreEqual("New Password", user.ConfirmPassword);
        }

        [DataTestMethod]
        [DataRow("Old Password", "New Password", "1234567")]
        public void ConfirmPassword_Must_Have_At_Least_8_Chars(string oldPassword, string newPassword, string confirmPassword)
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword = confirmPassword
            };

            user.Validate();

            Assert.IsTrue(user.Invalid, "Confirm password must have at least 8 chars");
        }

        [DataTestMethod]
        [DataRow("Old Password", "New Password")]
        public void ConfirmPassword_Must_Be_Shorter_Or_Equal_Than_100_Chars(string oldPassword, string newPassword)
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword = new string('x', 101)
            };

            user.Validate();

            Assert.IsTrue(user.Invalid, "Confirm password must shorter or equal than 100 chars");
        }

        [DataTestMethod]
        [DataRow("Old Password", "New Password", "New Password")]
        public void ConfirmPassword_Must_Be_Equals_NewPassword(string oldPassword, string newPassword, string confirmPassword)
        {
            var user = new ChangePasswordDTO
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword = confirmPassword
            };

            user.Validate();

            Assert.AreEqual(user.NewPassword, user.ConfirmPassword);
        }
    }
}
