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
        public void Nome_Completo_Deve_Ser_Full_Name()
        {
            var user = User.Create(_fullName, _email, _createdAt, _userName);

            Assert.AreEqual("Full Name", user.FullName);
        }

        [TestMethod]
        [TestCategory("New User")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Nome_Completo_Nao_Pode_Ser_Vazio_Ou_Null()
        {
            User.Create("", _email, _createdAt, _userName);
        }
        [TestMethod]
        [TestCategory("New User")]
        public void Email_Deve_Ser_Email()
        {
            var user = User.Create(_fullName, _email, _createdAt, _userName);

            Assert.AreEqual("Email", user.Email);
        }
        [TestMethod]
        [TestCategory("New User")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Email_Nao_Pode_Ser_Vazio_Ou_Null()
        {
            User.Create(_fullName,"",_createdAt,_userName);
        }
        [TestMethod]
        [TestCategory("New User")]
        public void User_Name_Deve_Ser_User_Name()
        {
            var user = User.Create(_fullName, _email, _createdAt, _userName);

            Assert.AreEqual("Email", user.UserName);
        }
        [TestMethod]
        [TestCategory("New User")]
        public void O_CreatedAt_Do_Novo_User_Deve_Ser_O_Horario_DeAgora()
        {
            var user = User.Create(_fullName, _email, _createdAt, _userName);

            Assert.AreEqual(_createdAt, user.CreatedAt);
        }
    }
}
