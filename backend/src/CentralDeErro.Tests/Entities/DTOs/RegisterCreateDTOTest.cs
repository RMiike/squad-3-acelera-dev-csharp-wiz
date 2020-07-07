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
        public void Registro_Valido_Deve_Passar()
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
        public void Nome_Completo_Deve_ter_Pelo_menos_3_chars()
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
        public void Nome_Completo_Deve_ter_ate_100_chars()
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
        public void Email_deve_ser_valido()
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
        public void Password_Deve_ter_Pelo_menos_8_chars()
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
        public void Password_Deve_ter_ate_100_chars()
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
        public void Confirm_Password_Deve_ter_Pelo_menos_8_chars()
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
        public void Confirm_Password_Deve_ter_ate_100_chars()
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
