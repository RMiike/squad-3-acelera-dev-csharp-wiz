using CentralDeErro.Core.Contracts.Repositories;
using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Core.Enums;
using CentralDeErro.Tests._3_InfrastructureTests.Data;
using CentralDeErro.WebAPI.Controllers.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErro.Tests._1_PresentationTests.Controllers.v1
{
    [TestClass]
    public class ErrorControllerTests
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Deve_estar_ok_quando_encontra_id(int id)
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);


            var result = controller.GetErrorById(fakeService, id);
            var expected = fakeService.Get(id);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var actual = (result.Result as OkObjectResult).Value as ErrorReadDTO;
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
        }
        [DataTestMethod]
        [DataRow(22)]
        [DataRow(222)]
        public void Nao_Deve_estar_ok_quando_nao_encontra_id(int id)
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var expected = fakeService.Get(id);
            var result = controller.GetErrorById(fakeService, id);
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult));

            var actual = (result.Result as NotFoundObjectResult).Value;

            Assert.IsNull(expected);
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void Deve_Retornar_Todos_os_Errors()
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var expected = fakeService.Get().ToList();

            var result = controller.GetAll(fakeService);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var actual = (result.Result as OkObjectResult).Value as List<ErrorReadDTO>;

            for (var i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
        }
        //public int Id { get; }
        //public string Title { get; set; }
        //public string Details { get; set; }
        //public int SourceId { get; set; }
        //public Level Level { get; set; }
        //public string Token { get; private set; }

        [DataTestMethod]
        [DataRow("Title", "Details", 1, Level.Debug, "Token")]
        [DataRow("Titles", "Detailss", 2, Level.Error, "Token")]
        public void Deve_EstaR_Ok_ao_realizar_post(string title, string details, int sourceId, Level level, string token)
        {

            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var newError = new ErrorCreateDTO { Title = title, Details = details, SourceId = sourceId, Level = level };

            var result = controller.Register(fakeService, newError, token);

            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtRouteResult));

            var actual = (result.Result as CreatedAtRouteResult).Value as ResultDTO;
            Assert.AreEqual(true, actual.Success);
            Assert.AreEqual("Succesfully registred the error.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("Ti", "Details", 1, Level.Debug, "Token")]
        [DataRow("Titles", "Deta", 2, Level.Error, "Token")]
        public void Deve_Falhar_ao_realizar_post_Com_ErrorCreateDTO_Invalido(string title, string details, int sourceId, Level level, string token)
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var newError = new ErrorCreateDTO { Title = title, Details = details, SourceId = sourceId, Level = level };

            var result = controller.Register(fakeService, newError, token);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual("An error ocurred.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("Titles", "Details", 22, Level.Debug, "Token")]
        [DataRow("Titles", "Details", 77, Level.Error, "Token")]
        public void Deve_Falhar_ao_realizar_post_De_Source_Inexistente(string title, string details, int sourceId, Level level, string token)
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var newError = new ErrorCreateDTO { Title = title, Details = details, SourceId = sourceId, Level = level };

            var result = controller.Register(fakeService, newError, token);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual("Invalid Source Id.", actual.Message);
            Assert.IsNull(actual.Data);
        }
        [DataTestMethod]
        [DataRow(1)]
        public void Deve_Arquivar_Error(int id)
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var result = controller.Archive(fakeService, id);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var actual = (result as OkObjectResult).Value as ResultDTO;
            Assert.AreEqual(true, actual.Success);
            Assert.AreEqual("Successfuly archived.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow(21)]
        public void Deve_Falhar_Ao_tentar_Arquivar_Error_Com_Id_Ivalido(int id)
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var result = controller.Archive(fakeService, id);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            var actual = (result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual($"Error id: {id} not found.", actual.Message);
            Assert.IsNull(actual.Data);
        }
        [DataTestMethod]
        [DataRow(3)]
        public void Deve_Falhar_Ao_tentar_Arquivar_Error_Arquivado(int id)
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var result = controller.Archive(fakeService, id);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            var actual = (result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual($"Error id: {id} already archived.", actual.Message);
            Assert.IsNull(actual.Data);
        }
        [DataTestMethod]
        [DataRow(2)]
        public void Deve_Desarquivar_Error(int id)
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var result = controller.Unarchive(fakeService, id);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var actual = (result as OkObjectResult).Value as ResultDTO;
            Assert.AreEqual(true, actual.Success);
            Assert.AreEqual("Successfuly unarchived.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }
        [DataTestMethod]
        [DataRow(21)]
        public void Deve_Falhar_Ao_tentar_Desarquivar_Error_Com_Id_Ivalido(int id)
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var result = controller.Unarchive(fakeService, id);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            var actual = (result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual($"Error id: {id} not found.", actual.Message);
            Assert.IsNull(actual.Data);
        }
        [DataTestMethod]
        [DataRow(1)]
        public void Deve_Falhar_Ao_tentar_Desarquivar_Error_Arquivado(int id)
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var result = controller.Unarchive(fakeService, id);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            var actual = (result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual($"Error id: {id} already unarchived.", actual.Message);
            Assert.IsNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow(1)]
        public void Deve_Deletar_Error(int id)
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var result = controller.Delete(fakeService, id);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var actual = (result as OkObjectResult).Value as ResultDTO;
            Assert.AreEqual(true, actual.Success);
            Assert.AreEqual("Successfuly deleted.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow(21)]
        public void Deve_Falhar_Ao_tentar_Deletar_Error_Com_Id_Ivalido(int id)
        {
            IErrorRepository fakeService;
            ErrorController controller;
            CreateController(out fakeService, out controller);

            var result = controller.Delete(fakeService, id);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            var actual = (result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual($"Error id: {id} not found.", actual.Message);
            Assert.IsNull(actual.Data);
        }

        private static void CreateController(out IErrorRepository fakeService, out ErrorController controller)
        {
            var fakeContext = new FakeContext("SourceControllerTests");
            fakeService = fakeContext.FakeErrorRepository().Object;
            controller = new ErrorController();
        }
    }
}
