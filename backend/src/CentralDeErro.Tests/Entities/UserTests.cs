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
        public void FullName_MustBe_Full_Name()
        {
            var user = User.Create(_fullName, _email, _createdAt, _userName);

            Assert.AreEqual("Full Name", user.FullName);
        }

        [TestMethod]
        [TestCategory("New User")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FullName_CantBe_Null_Or_Empty()
        {
            User.Create("", _email, _createdAt, _userName);

        }
        [TestMethod]
        [TestCategory("New User")]
        public void Email_MustBe_Email()
        {
            var user = User.Create(_fullName, _email, _createdAt, _userName);

            Assert.AreEqual("Email", user.Email);
        }
        [TestMethod]
        [TestCategory("New User")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Email_CantBe_Null_Or_Empty()
        {
            User.Create(_fullName,"",_createdAt,_userName);
        }
        [TestMethod]
        [TestCategory("New User")]
        public void UserName_Deve_Ser_User_Name()
        {
            var user = User.Create(_fullName, _email, _createdAt, "User Name");

            Assert.AreEqual("User Name", user.UserName);
        }
        [TestMethod]
        [TestCategory("New User")]
        public void CreatedAt_MustBe_Equals_DateTime_UTCNow()
        {
            var user = User.Create(_fullName, _email, _createdAt, _userName);

            Assert.AreEqual(_createdAt, user.CreatedAt);
        }
    }
}
