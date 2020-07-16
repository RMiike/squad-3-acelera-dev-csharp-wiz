using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Tests._3_InfrastructureTests.Data;
using CentralDeErro.WebAPI.Controllers.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace CentralDeErro.Tests._1_PresentationTests.Controllers.v1
{
    [TestClass]
    public class AuthenticationControllerTests
    {
        [DataTestMethod]
        [DataRow("Full Name", "email@email.com", "12345678", "12345678")]
        public void Deve_Registrar_Um_Novo_Usuario(string fullName, string email, string password, string confirmPassword)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(fullName, email, password, confirmPassword);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var actual = (result.Result as OkObjectResult).Value as ResultDTO;
            Assert.AreEqual("User account created sucessfully, please confirm your email.", actual.Message);
            Assert.IsNotNull(actual);
        }

        [DataTestMethod]
        [DataRow("Full Name", "Joaquin@Joaquin.com", "12345678", "12345678")]
        [DataRow("Full Name", "Alen@Alen.com", "12345678", "12345678")]
        [DataRow("Full Name", "Maria@Maria.com", "12345678", "12345678")]
        public void Deve_Falhar_Ao_Registrar_Usuario_Existente(string fullName, string email, string password, string confirmPassword)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(fullName, email, password, confirmPassword);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual("User already exist!", actual.Message);
            Assert.IsNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("Fu", "Joaquin@Joaquin.com", "12345678", "12345678")]
        [DataRow("Full Name", "MariaMaria.com", "12345678", "12345678")]
        [DataRow("Full Name", "Alen@Alen.com", "1234567", "12345678")]
        [DataRow("Full Name", "Cardoso@Cardoso.com", "12345678", "1234567")]
        [DataRow("Full Name", "Cardoso@Cardoso.com", "123456781", "123456782")]

        public void Deve_Falhar_Ao_Tentar_Registrar_Com_RegisterDTO_Invalido(string fullName, string email, string password, string confirmPassword)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(fullName, email, password, confirmPassword);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual("Invalid field.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("Cardoso@Cardoso.com", "asd123123as-09(I")]
        public void Deve_Realizar_Login_De_Usuario(string email, string password)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(email: email, password: password);


            var actual = (result.Result as OkObjectResult).Value as ResultDTO;
            Assert.AreEqual("User authenticated.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("CardosoCardoso.com", "12345678")]
        [DataRow("Cardoso@Cardoso.com", "1234567")]
        public void Deve_Falhar_Ao_Realizar_Login_Com_LoginCreateDTO_Invalido(string email, string password)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(email: email, password: password);


            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual("Invalid field.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("email@email.com", "12345678")]
        public void Deve_Falhar_Ao_Realizar_Login_Sem_Cadastro(string email, string password)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(email: email, password: password);


            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual("Please, confirm your email, verify your password, verify your user name and try again.", actual.Message);
            Assert.IsNull(actual.Data);
        }
        [DataTestMethod]
        [DataRow("Cardoso@Cardoso.com", "12345678")]
        public void Deve_Falhar_Ao_Realizar_Login_De_Usuario_Com_senha_Invalida(string email, string password)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(email: email, password: password);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual("Please, confirm your email, verify your password, verify your user name and try again.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("Cardoso@Cardoso.com", "12345678")]
        public void Deve_Confirmar_Email(string userEmail, string token)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(email: userEmail, token: token);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var actual = (result.Result as OkObjectResult).Value as ResultDTO;
            Assert.AreEqual(true, actual.Success);
            Assert.AreEqual("Email confirmed successfuly.", actual.Message);
            Assert.IsNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("Cardoso@Cardoso.com", "")]
        [DataRow("", "12312312313")]
        public void Deve_Falhar_Ao_tentar_Confirmar_Email_Com_Campos_vazios(string userEmail, string token)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(email: userEmail, token: token);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual("Wrong email or invalid token", actual.Message);
            Assert.IsNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("Cardoso@hotmail.com", "12312313213")]
        public void Deve_Falhar_Ao_tentar_Confirmar_Email_De_Usuario_Inexistente(string userEmail, string token)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(email: userEmail, token: token);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual("User not found.", actual.Message);
            Assert.IsNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("Cardoso@Cardoso.com", "emailnaoconfirmado")]
        public void Deve_Falhar_Ao_Quando_Nao_Conseguir_Confirmar_email(string userEmail, string token)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(email: userEmail, token: token);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual("Email did not confirm.", actual.Message);
            Assert.IsNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("Cardoso@Cardoso.com")]
        public void Deve_Realizar_Esqueci_Senha(string email)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(email: email);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var actual = (result.Result as OkObjectResult).Value as ResultDTO;
            Assert.AreEqual(true, actual.Success);
            Assert.AreEqual($"A new password has been sent to the email: {email}", actual.Message);
            Assert.IsNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("CardosoCardoso.com")]
        public void Deve_Falhar_Ao_Realizar_Esqueci_Senha_Com_ForgotPasswordDTO_Invalido(string email)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(email: email);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual("Wrong email, please verify and try again.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("Cardoso@hotmail.com")]
        public void Deve_Falhar_Ao_Realizar_Esqueci_Senha_Com_Usuario_Nao_Cadastrado(string email)
        {
            Task<IActionResult> result = CriaControllerEUtilizaAService(email: email);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual("User not found", actual.Message);
            Assert.IsNull(actual.Data);
        }

        private static Task<IActionResult> CriaControllerEUtilizaAService(
            string fullName = null, string email = null, string password = null, string confirmPassword = null, string token = null)
        {
            var fakeContext = new FakeContext("AccountManagerControllerTests");
            var fakeService = fakeContext.FakeAuthenticationRepository().Object;
            var controller = new AuthenticationController();

            if (confirmPassword != null)
            {
                var registerCreateDTO = new RegisterCreateDTO
                {
                    FullName = fullName,
                    Email = email,
                    Password = password,
                    ConfirmPassword = confirmPassword
                };
                return controller.Register(fakeService, registerCreateDTO);
            }
            else if (token != null)
            {
                return controller.ConfirmEmail(fakeService, fakeContext._configuration, email, token);
            }
            else if (password != null && confirmPassword == null)
            {
                var loginCreateDTO = new LoginCreateDTO
                {
                    Email = email,
                    Password = password
                };
                return controller.SignIn(fakeService, loginCreateDTO);
            }
            else
            {
                var forgotPasswordDTO = new ForgotPasswordDTO
                {
                    Email = email
                };
                return controller.ForgotPassword(fakeService, forgotPasswordDTO);
            }

        }

    }
}
