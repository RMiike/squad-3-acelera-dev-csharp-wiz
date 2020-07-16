using CentralDeErro.Core.Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralDeErro.Tests._2_CoreTests.DTOs
{

    [TestClass]
    public class RegisterCreateDTOTest
    {

        [DataTestMethod]
        [DataRow("Ana Maria", "ana@maria.com", "12345678", "12345678")]
        [DataRow("Maria Joaquina", "Maria@Joaquina.com", "asdasdsad", "asdasdsad")]
        [DataRow("Joaquina Ferreira", "Joaquina@Ferreira.com", "asd123qasd", "asd123qasd")]
        public void Check_Register_Is_Valid(string fullName, string email, string password, string confirmPassword)
        {
            RegisterCreateDTO registerCreateDTO = new RegisterCreateDTO();
            Assert.IsNull(registerCreateDTO.Email);
            Assert.IsNull(registerCreateDTO.FullName);
            Assert.IsNull(registerCreateDTO.Password);
            Assert.IsNull(registerCreateDTO.ConfirmPassword);

            registerCreateDTO.FullName = fullName;
            registerCreateDTO.Email = email;
            registerCreateDTO.Password = password;
            registerCreateDTO.ConfirmPassword = confirmPassword;

            Assert.IsNotNull(registerCreateDTO.Email);
            Assert.IsNotNull(registerCreateDTO.FullName);
            Assert.IsNotNull(registerCreateDTO.Password);
            Assert.IsNotNull(registerCreateDTO.ConfirmPassword);

            Assert.AreEqual(fullName, registerCreateDTO.FullName);
            Assert.AreEqual(email, registerCreateDTO.Email);
            Assert.AreEqual(password, registerCreateDTO.Password);
            Assert.AreEqual(confirmPassword, registerCreateDTO.ConfirmPassword);
            Assert.AreEqual(registerCreateDTO.ConfirmPassword, registerCreateDTO.ConfirmPassword);

            registerCreateDTO.Validate();

            Assert.IsTrue(registerCreateDTO.Valid);
        }

        [DataTestMethod]
        [DataRow("An", "ana@maria.com", "12345678", "12345678")]
        public void Check_FullName_Greater_Than_2_Chars(string fullName, string email, string password, string confirmPassword)
        {
            var _registerCreateDTO = CreateRegister(fullName, email, password, confirmPassword);

            Assert.IsTrue(_registerCreateDTO.Invalid);

        }



        [DataTestMethod]
        [DataRow("ana@maria.com", "12345678", "12345678")]
        public void Check_FullName_Smaller_Than_Or_Equals_100(string email, string password, string confirmPassword)
        {
            RegisterCreateDTO _registerCreateDTO = CreateRegister(new string('*', 101), email, password, confirmPassword);

            Assert.IsTrue(_registerCreateDTO.Invalid);

        }

        [DataTestMethod]
        [DataRow("Ana Maria", "anamaria.com", "12345678", "12345678")]
        public void Check_Email_Is_Valid(string fullName, string email, string password, string confirmPassword)
        {
            RegisterCreateDTO _registerCreateDTO = CreateRegister(fullName, email, password, confirmPassword);


            Assert.IsTrue(_registerCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow("Ana Maria", "ana@maria.com", "12345678", "1234567")]
        [DataRow("Ana Maria", "ana@maria.com", "1234567", "12345678")]
        public void Check_Password_Greater_Than_7_Chars(string fullName, string email, string password, string confirmPassword)
        {
            RegisterCreateDTO _registerCreateDTO = CreateRegister(fullName, email, password, confirmPassword);

            Assert.IsTrue(_registerCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow("Ana Maria", "ana@maria.com", "12345678")]
        public void Check_Password_Smaller_Than_101_Chars(string fullName, string email, string confirmPassword)
        {
            RegisterCreateDTO _registerCreateDTO = CreateRegister(fullName, email, new string('*', 101), confirmPassword);

            Assert.IsTrue(_registerCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow("Ana Maria", "ana@maria.com", "12345678")]
        public void Check_ConfirmPassowrd_Greater_Than_7_Chars(string fullName, string email, string password)
        {
            RegisterCreateDTO _registerCreateDTO = CreateRegister(fullName, email, password, new string('*', 101));

            Assert.IsTrue(_registerCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow("Ana Maria", "ana@maria.com", "12345678", "12345678")]
        public void Check_ConfirmPassword_Smaller_Than_Or_Equals_100_Chars(string fullName, string email, string password, string confirmPassword)
        {
            RegisterCreateDTO _registerCreateDTO = CreateRegister(fullName, email, password, confirmPassword);

            if (_registerCreateDTO.Valid)
                Assert.AreEqual(_registerCreateDTO.Password, _registerCreateDTO.ConfirmPassword);
        }


        private static RegisterCreateDTO CreateRegister(string fullName, string email, string password, string confirmPassword)
        {
            var registerCreateDTO = new RegisterCreateDTO
            {
                FullName = fullName,
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            registerCreateDTO.Validate();
            return registerCreateDTO;
        }
    }
}
