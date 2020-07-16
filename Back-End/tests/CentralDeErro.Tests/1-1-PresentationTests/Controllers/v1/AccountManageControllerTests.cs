using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Tests._3_InfrastructureTests.Data;
using CentralDeErro.WebAPI.Controllers.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace CentralDeErro.Tests._1_PresentationTests.Controllers.v1
{
    [TestClass]
    public class AccountManageControllerTests
    {
        [DataTestMethod]
        [DataRow("waeqweqweasd", "12345678", "12345678")]
        public void Deve_Resetar_A_senha(string oldPassword, string newPassword, string confirmPassword)
        {
            Task<IActionResult> result = CriarControllerEObterResultado(oldPassword, newPassword, confirmPassword);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var actual = (result.Result as OkObjectResult).Value as ResultDTO;
            Assert.AreEqual("Password was changed successfully.", actual.Message);
            Assert.IsNotNull(actual);
        }



        [DataTestMethod]
        [DataRow("waeqwe", "12345678", "12345678")]
        [DataRow("waeqweqweasd", "1234567", "12345678")]
        [DataRow("waeqweqweasd", "12345678", "1234568")]
        public void Deve_Falhar_Ao_Tentar_Resetar_A_senha_Com_ChangePasswordDTO_Invalido(string oldPassword, string newPassword, string confirmPassword)
        {
            Task<IActionResult> result = CriarControllerEObterResultado(oldPassword, newPassword, confirmPassword);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual("An error ocurred.", actual.Message);
            Assert.IsNotNull(actual);
        }

        [DataTestMethod]
        [DataRow("waeqweqweasd", "successfail", "successfail")]
        public void Deve_Falhar_Se_Nao_Alterar_Senha(string oldPassword, string newPassword, string confirmPassword)
        {
            Task<IActionResult> result = CriarControllerEObterResultado(oldPassword, newPassword, confirmPassword);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual("An error ocurred.", actual.Message);
            Assert.IsNotNull(actual);
        }
        [DataTestMethod]
        [DataRow("waeqweqweasd", "nouserautenticated", "nouserautenticated")]
        public void Deve_Falhar_Com_Usuario_Invalido(string oldPassword, string newPassword, string confirmPassword)
        {
            Task<IActionResult> result = CriarControllerEObterResultado(oldPassword, newPassword, confirmPassword);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual("User data not found!", actual.Message);
            Assert.IsNotNull(actual);
        }
        private static Task<IActionResult> CriarControllerEObterResultado(string oldPassword, string newPassword, string confirmPassword)
        {
            var fakeContext = new FakeContext("AccountManagerControllerTests");
            var fakeService = fakeContext.FakeAccountManagerRepository().Object;
            var controller = new AccountManageController();

            var changePasswordDTO = new ChangePasswordDTO { OldPassword = oldPassword, NewPassword = newPassword, ConfirmPassword = confirmPassword };

            var result = controller.ChangePassword(fakeService, changePasswordDTO);
            return result;
        }
    }
}
