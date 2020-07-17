using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Infrastructure.Services;
using CentralDeErro.Tests._3_InfrastructureTests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CentralDeErro.Tests._3_InfrastructureTests.Repositories
{
    [TestClass]
    public class AccountManagerServiceTests
    {
        [DataTestMethod]
        [DataRow("asd123123as-09(I", "newPassword", "confirmPassword", "Cardoso@Cardoso.com")]
        public void Deve_Modificar_Senha(
            string oldPassword,
            string newPassword,
            string confirmPassword,
            string userEmail
            )
        {
            Task<ResultDTO> result = CreateControllerAndMakeChangePassword(oldPassword, newPassword, confirmPassword, userEmail);

            Assert.AreEqual("Password was changed successfully.", result.Result.Message);
            Assert.IsNull(result.Result.Data);
            Assert.IsTrue(result.Result.Success);
        }

        [DataTestMethod]
        [DataRow("asd123123as-09(I", "newPassword", "confirmPassword", "Cardoso@hotmail.com")]
        public void Deve_Falhar_Caso_Usuario_Nao_Exista(
           string oldPassword,
           string newPassword,
           string confirmPassword,
           string userEmail
           )
        {
            Task<ResultDTO> result = CreateControllerAndMakeChangePassword(oldPassword, newPassword, confirmPassword, userEmail);

            Assert.AreEqual("User  data not found!", result.Result.Message);
            Assert.IsNull(result.Result.Data);
            Assert.IsFalse(result.Result.Success);
        }
        [DataTestMethod]
        [DataRow("newPassword", "newPassword", "confirmPassword", "Cardoso@Cardoso.com")]
        public void Deve_Falhar_caso_senha_esteja_errada(
            string oldPassword,
            string newPassword,
            string confirmPassword,
            string userEmail
            )
        {
            Task<ResultDTO> result = CreateControllerAndMakeChangePassword(oldPassword, newPassword, confirmPassword, userEmail);

            Assert.AreEqual("An error ocurred.", result.Result.Message);
            Assert.IsNotNull(result.Result.Data);
            Assert.IsFalse(result.Result.Success);
        }

        private static Task<ResultDTO> CreateControllerAndMakeChangePassword(string oldPassword, string newPassword, string confirmPassword, string userEmail)
        {
            var fakeContext = new FakeContext("AccountManagerServiceTests");
            var fakeService = fakeContext.FakeUserManager().Object;
            var controller = new AccountManagerService(fakeService);

            var changePasswordDTO = new ChangePasswordDTO { OldPassword = oldPassword, NewPassword = newPassword, ConfirmPassword = confirmPassword };

            var userExistis = fakeContext.Get<RegisterCreateDTO>().Where(x => x.Email == userEmail).FirstOrDefault();

            var identity = new[] { new Claim("Name", userEmail) };
            var result = controller.ChangePassword(changePasswordDTO, new ClaimsPrincipal(new ClaimsIdentity(identity)));
            return result;
        }
    }
}
