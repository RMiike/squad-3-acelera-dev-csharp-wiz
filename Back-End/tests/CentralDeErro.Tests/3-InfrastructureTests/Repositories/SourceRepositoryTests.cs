using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Infrastructure.Context;
using CentralDeErro.Infrastructure.Repository;
using CentralDeErro.Tests._3_InfrastructureTests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Environment = CentralDeErro.Core.Enums.Environment;

namespace CentralDeErro.Tests._3_InfrastructureTests.Repositories
{
    [TestClass]

    public class SourceRepositoryTests
    {

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        public void Deve_Obter_O_Source_De_Id_Correto(int id)
        {
            FakeContext fakeContext = CreateAndFillContextWithSource();

            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var atual = service.Get(id);
                Assert.IsNotNull(atual);

                Assert.AreEqual(id, atual.Id);
            }
        }

        [TestMethod]
        public void Deve_Obter_Todos_Os_Sources()
        {
            FakeContext fakeContext = CreateAndFillContextWithSource();

            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var atual = service.Get().ToList();

                Assert.IsNotNull(atual);

                for (var i = 0; i < atual.ToList().Count(); i++)
                {
                    Assert.IsNotNull(atual[i].Id);
                    Assert.IsNotNull(atual[i].Address);
                    Assert.IsNotNull(atual[i].Environment);
                    Assert.AreEqual(atual[i].Id, (1 + i));
                }
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parametro_Vazio_deve_retornar_Exception_ao_tentar_realizar_Post()
        {
            var fakeContext = new FakeContext("SourceRepositoryTests");
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);
                service.Create(null);
            }
        }


        [DataTestMethod]
        [DataRow("Back-End", 0)]
        [DataRow("Front-End", 2)]
        public void Deve_Falhar_Ao_Postar_Source_Com_Endereco_E_Ambiente_Ja_Existente(string address, Environment environment)
        {
            FakeContext fakeContext = CreateAndFillContextWithSource();
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var newSource = new SourceCreateDTO { Address = address, Environment = environment };

                var result = service.Create(newSource);

                Assert.AreEqual(false, result.Success);
                Assert.AreEqual("Source already existis.", result.Message);
                Assert.AreEqual(null, result.Data);
            }
        }


        [DataTestMethod]
        [DataRow("New-Address", 0)]
        [DataRow("New-Address", 1)]
        public void Deve_Realizar_Post(string address, Environment environment)
        {
            FakeContext fakeContext = CreateAndFillContextWithSource();
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var newSource = new SourceCreateDTO { Address = address, Environment = environment };

                Assert.IsNotNull(newSource);

                Assert.IsNull(service.Get().Where(x => x.Environment == newSource.Environment.ToString() && x.Address == newSource.Address).FirstOrDefault());

                var savedSource = service.Create(newSource);

                if (savedSource.Success == false)
                {
                    Assert.AreEqual(false, savedSource.Success);
                    Assert.AreEqual("Fail", savedSource.Message);
                    Assert.IsNull(savedSource.Data);
                }
                else
                {

                    Assert.AreEqual(true, savedSource.Success);
                    Assert.AreEqual("Succesfully registred the source.", savedSource.Message);
                    Assert.IsNotNull(savedSource.Data);
                }
            }
        }

        [DataTestMethod]
        [DataRow(11)]
        [DataRow(21)]

        public void Deve_Falhar_Ao_Tentar_Deletar_Source_Inexistente(int id)
        {
            FakeContext fakeContext = CreateAndFillContextWithSource();

            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var result = service.Delete(id);

                var resultFail = new ResultDTO(false, $"Source id: {id} not found.", null);

                Assert.AreEqual(new { resultFail.Success, resultFail.Message, resultFail.Data },
                                    new { result.Success, result.Message, result.Data });
            }

        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]

        public void Deve_Realizar_Source_Delete(int id)
        {
            FakeContext fakeContext = CreateAndFillContextWithSource();
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var result = service.Delete(id);

                var resultNotFail = new ResultDTO(true, "Successfuly deleted", result.Data);

                Assert.AreEqual(new { resultNotFail.Success, resultNotFail.Message },
                             new { result.Success, result.Message });
                Assert.IsNotNull(result.Data);

            }
        }
        private static FakeContext CreateAndFillContextWithSource()
        {
            var fakeContext = new FakeContext("SourceRepositoryTests");

            fakeContext.FillWithAllSource();
            return fakeContext;
        }
        private static SourceRepository CreateService(FakeContext fakeContext, CentralDeErrorContext context)
            => new SourceRepository(context, fakeContext._mapper);
    }
}
