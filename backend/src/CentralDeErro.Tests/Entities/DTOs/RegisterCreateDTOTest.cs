using CentralDeErro.Core.Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErro.Tests.Entities.DTOs
{
    [TestClass]
    public class RegisterCreateDTOTest
    {

        #region private
        private readonly string _fullName = "Renato Alves";
        private readonly string _email = "miike@miike.com";
        private readonly string _password = "12345678";
        private readonly string _confirmPassword = "12345678";
        #endregion


        [TestMethod]
        public void Check_Register_Is_Valid()
        {
            RegisterCreateDTO _registerCreateDTO = new RegisterCreateDTO
            {
                FullName = _fullName,
                Email = _email,
                Password = _password,
                ConfirmPassword = _confirmPassword
            };

            _registerCreateDTO.Validate();

            Assert.IsTrue(_registerCreateDTO.Valid);
        }
        [TestMethod]
        public void Check_FullName_Greater_Than_2_Chars()
        {
            RegisterCreateDTO _registerCreateDTO = new RegisterCreateDTO
            {
                FullName = "ab",
                Email = _email,
                Password = _password,
                ConfirmPassword = _confirmPassword
            };
            _registerCreateDTO.Validate();

            Assert.IsTrue(_registerCreateDTO.Invalid);

        }
        [TestMethod]
        public void Check_FullName_Smaller_Than_Or_Equals_100()
        {
            RegisterCreateDTO _registerCreateDTO = new RegisterCreateDTO
            {
                FullName = new string('*',101),
                Email = _email,
                Password = _password,
                ConfirmPassword = _confirmPassword
            };

            _registerCreateDTO.Validate();

            Assert.IsTrue(_registerCreateDTO.Invalid);

        }
        [TestMethod]
        public void Check_Email_Is_Valid()
        {
            RegisterCreateDTO _registerCreateDTO = new RegisterCreateDTO
            {
                FullName = _fullName,
                Email = "email.com",
                Password = _password,
                ConfirmPassword = _confirmPassword
            };

            _registerCreateDTO.Validate();

            Assert.IsTrue(_registerCreateDTO.Invalid);
        }
        [TestMethod]
        public void Check_Password_Greater_Than_7_Chars()
        {
            RegisterCreateDTO _registerCreateDTO = new RegisterCreateDTO
            {
                FullName = _fullName,
                Email = _email,
                Password = "1234567",
                ConfirmPassword = _confirmPassword
            };

            _registerCreateDTO.Validate();

            Assert.IsTrue(_registerCreateDTO.Invalid);
        }
        [TestMethod]
        public void Check_Password_Smaller_Than_101_Chars()
        {
            RegisterCreateDTO _registerCreateDTO = new RegisterCreateDTO
            {
                FullName = _fullName,
                Email = _email,
                Password = new string('*',101),
                ConfirmPassword = _confirmPassword
            };

            _registerCreateDTO.Validate();

            Assert.IsTrue(_registerCreateDTO.Invalid);
        }
        [TestMethod]
        public void Check_ConfirmPassowrd_Greater_Than_7_Chars()
        {
            RegisterCreateDTO _registerCreateDTO = new RegisterCreateDTO
            {
                FullName = _fullName,
                Email = _email,
                Password = _password,
                ConfirmPassword = "1234567"
            };

            _registerCreateDTO.Validate();

            Assert.IsTrue(_registerCreateDTO.Invalid);
        }
        [TestMethod]
        public void Check_ConfirmPassword_Smaller_Than_Or_Equals_100_Chars()
        {
            RegisterCreateDTO _registerCreateDTO = new RegisterCreateDTO
            {
                FullName = _fullName,
                Email = _email,
                Password = _password,
                ConfirmPassword = new string('*', 101)
            };

            _registerCreateDTO.Validate();

            Assert.IsTrue(_registerCreateDTO.Invalid);
        }
        [TestMethod]
        public void Confirm_Password_Deve_Ser_Igual_A_Password()
        {
            RegisterCreateDTO _registerCreateDTO = new RegisterCreateDTO
            {
                FullName = _fullName,
                Email = _email,
                Password = _password,
                ConfirmPassword = _confirmPassword
            };

            _registerCreateDTO.Validate();

            if(_registerCreateDTO.Valid)
               Assert.AreEqual(_registerCreateDTO.Password, _registerCreateDTO.ConfirmPassword);
        }
    }
}
