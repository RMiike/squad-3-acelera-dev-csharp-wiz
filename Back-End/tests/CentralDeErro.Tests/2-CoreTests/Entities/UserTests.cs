using CentralDeErro.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralDeErro.Tests._2_CoreTests.Entities
{
    [TestClass]
    public class UserTests
    {
        private readonly DateTime _createdAt = DateTime.UtcNow;

        [DataTestMethod]
        [DataRow("Full Name", "Email", "Email")]
        public void FullName_Must_Be_Full_Name(string fullName, string email, string userName)
        {
            var user = User.Create(fullName, email, userName);

            Assert.AreEqual("Full Name", user.FullName);
        }

        [DataTestMethod]
        [DataRow("", "Email", "Email")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FullName_Cant_Be_Empty_Or_Null(string fullName, string email, string userName)
        {
            User.Create(fullName, email, userName);
        }

        [DataTestMethod]
        [DataRow("Full Name", "Email", "Email")]
        public void Email_Must_Be_Email(string fullName, string email, string userName)
        {
            var user = User.Create(fullName, email, userName);

            Assert.AreEqual("Email", user.Email);
        }

        [DataTestMethod]
        [DataRow("Full Name", "", "Email")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Email_Cant_Be_Empty_Or_Null(string fullName, string email, string userName)
        {
            User.Create(fullName, email, userName);
        }

        [DataTestMethod]
        [DataRow("Full Name", "Email", "Email")]
        public void UserName_Must_Be_User_Name(string fullName, string email, string userName)
        {
            var user = User.Create(fullName, email, userName);

            Assert.AreEqual("Email", user.UserName);
        }

        [DataTestMethod]
        [DataRow("Full Name", "Email", "Email")]
        public void CreatedAt_Must_Be_UTC_Now(string fullName, string email, string userName)
        {
            var user = User.Create(fullName, email, userName);

            Assert.AreEqual(_createdAt.Date, user.CreatedAt.Date);
        }
    }
}
