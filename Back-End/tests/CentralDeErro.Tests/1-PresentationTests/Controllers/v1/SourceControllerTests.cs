using CentralDeErro.Core.Contracts.Repositories;
using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Tests._3_InfrastructureTests.Data;
using CentralDeErro.WebAPI.Controllers.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Environment = CentralDeErro.Core.Enums.Environment;

namespace CentralDeErro.Tests._1_PresentationTests.Controllers.v1
{
    [TestClass]
    public class SourceControllerTests
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Deve_estar_ok_quando_encontra_id(int id)
        {
            ISourceRepository fakeService;
            SourceController controller;
            CreateController(out fakeService, out controller);


            var result = controller.GetSourceById(fakeService, id);
            var expected = fakeService.Get(id);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var actual = (result.Result as OkObjectResult).Value as SourceReadDTO;
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
        }
        [DataTestMethod]
        [DataRow(8)]
        [DataRow(9)]
        public void Nao_Deve_estar_ok_quando_nao_encontra_id(int id)
        {
            ISourceRepository fakeService;
            SourceController controller;
            CreateController(out fakeService, out controller);

            var expected = fakeService.Get(id);
            var result = controller.GetSourceById(fakeService, id);
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult));

            var actual = (result.Result as NotFoundObjectResult).Value;

            Assert.IsNull(expected);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void Deve_Retornar_Todos_os_Sources()
        {
            ISourceRepository fakeService;
            SourceController controller;
            CreateController(out fakeService, out controller);

            var expected = fakeService.Get().ToList();

            var result = controller.GetAll(fakeService);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var actual = (result.Result as OkObjectResult).Value as List<SourceReadDTO>;

            for (var i = 0; i < expected.Count(); i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
        }


        [DataTestMethod]
        [DataRow("Adress", 1)]
        public void Deve_EstaR_Ok_ao_realizar_post(string address, Environment environment)
        {
            ISourceRepository fakeService;
            SourceController controller;
            CreateController(out fakeService, out controller);
            var newSource = new SourceCreateDTO { Address = address, Environment = environment };
            var result = controller.Register(fakeService, newSource);
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtRouteResult));

            var actual = (result.Result as CreatedAtRouteResult).Value as ResultDTO;
            Assert.AreEqual(true, actual.Success);
            Assert.AreEqual("Succesfully registred the source.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("Ad", 1)]
        [DataRow("Address", 626)]
        public void Deve_Falhar_ao_realizar_post_Com_SourceCreateDTO_Invalido(string address, Environment environment)
        {
            ISourceRepository fakeService;
            SourceController controller;
            CreateController(out fakeService, out controller);
            var newSource = new SourceCreateDTO { Address = address, Environment = environment };
            var result = controller.Register(fakeService, newSource);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual("An error ocurred.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow("Back-End", 1)]
        public void Deve_Falhar_ao_realizar_post_De_Source_Repetido(string address, Environment environment)
        {
            ISourceRepository fakeService;
            SourceController controller;
            CreateController(out fakeService, out controller);
            var newSource = new SourceCreateDTO { Address = address, Environment = environment };
            var result = controller.Register(fakeService, newSource);
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));

            var actual = (result.Result as BadRequestObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual("Source already existis.", actual.Message);
            Assert.IsNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow(1)]
        public void Deve_Deletar_Source(int id)
        {
            ISourceRepository fakeService;
            SourceController controller;
            CreateController(out fakeService, out controller);

            var result = controller.Delete(fakeService, id);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var actual = (result as OkObjectResult).Value as ResultDTO;
            Assert.AreEqual(true, actual.Success);
            Assert.AreEqual("Successfuly deleted.", actual.Message);
            Assert.IsNotNull(actual.Data);
        }

        [DataTestMethod]
        [DataRow(11)]
        public void Deve_Falhar_Ao_Tentar_Deletar_Source_Inexistente(int id)
        {
            ISourceRepository fakeService;
            SourceController controller;
            CreateController(out fakeService, out controller);

            var result = controller.Delete(fakeService, id);

            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));

            var actual = (result as NotFoundObjectResult).Value as ResultDTO;
            Assert.AreEqual(false, actual.Success);
            Assert.AreEqual($"Source id: {id} not found.", actual.Message);
            Assert.IsNull(actual.Data);
        }
        private static void CreateController(out ISourceRepository fakeService, out SourceController controller)
        {
            var fakeContext = new FakeContext("SourceControllerTests");
            fakeService = fakeContext.FakeSourceRepository().Object;
            controller = new SourceController();
        }
    }
}
