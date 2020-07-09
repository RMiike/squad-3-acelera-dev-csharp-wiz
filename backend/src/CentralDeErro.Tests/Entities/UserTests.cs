using CentralDeErro.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralDeErro.Tests.Entities
{
    [TestClass]
    public class User_Tests
    {

        #region props
        private readonly string _fullName = "Full Name";
        private readonly string _email = "Email";
        private readonly DateTime _createdAt = DateTime.UtcNow;
        private readonly string _userName = "Email";
        #endregion

        [TestMethod]
        [TestCategory("New User")]
        public void FullName_Must_Be_Full_Name()
        {
            var user = User.Create(_fullName, _email, _userName);

            Assert.AreEqual("Full Name", user.FullName);
        }

        [TestMethod]
        [TestCategory("New User")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FullName_Cant_Be_Empty_Or_Null()
        {
            User.Create("", _email,  _userName);
        }
        [TestMethod]
        [TestCategory("New User")]
        public void Email_Must_Be_Email()
        {
            var user = User.Create(_fullName, _email, _userName);

            Assert.AreEqual("Email", user.Email);
        }
        [TestMethod]
        [TestCategory("New User")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Email_Cant_Be_Empty_Or_Null()
        {
            User.Create(_fullName,"",_userName);
        }
        [TestMethod]
        [TestCategory("New User")]
        public void UserName_Must_Be_User_Name()
        {
            var user = User.Create(_fullName, _email,  _userName);

            Assert.AreEqual("Email", user.UserName);
        }

        [TestMethod]
        [TestCategory("New User")]
        public void CreatedAt_Must_Be_UTC_Now()
        {
            var user = User.Create(_fullName, _email, _userName);

            Assert.AreEqual(_createdAt.Date, user.CreatedAt.Date);
        }
    }
}
