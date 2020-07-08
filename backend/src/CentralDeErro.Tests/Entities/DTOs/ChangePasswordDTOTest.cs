using Bogus;
using CentralDeErro.Core.Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public void OldPassword_MustHave_AtLeast_Eight_Chars()
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
        public void OldPassword_MustBe_ShortherThan_100_Chars()
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
    }
}
