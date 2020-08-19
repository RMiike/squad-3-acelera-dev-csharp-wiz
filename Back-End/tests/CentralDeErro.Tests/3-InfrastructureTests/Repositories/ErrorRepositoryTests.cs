using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Core.Enums;
using CentralDeErro.Infrastructure.Context;
using CentralDeErro.Infrastructure.Repository;
using CentralDeErro.Tests._3_InfrastructureTests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Security.Claims;

namespace CentralDeErro.Tests._3_InfrastructureTests.Repositories
{
    [TestClass]

    public class ErrorRepositoryTests
    {

        [TestMethod]
        public void Deve_Obter_Todos_Os_Errors()
        {
            var fakeContext = CreateAndFillContextWithError();

            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);
                var actual = service.Get().ToList();

                Assert.IsNotNull(actual);
                var expectedNumbers = context.Errors.Count();
                Assert.AreEqual(expectedNumbers, actual.ToList().Count());

                for (var i = 0; i < actual.ToList().Count(); i++)
                {
                    Assert.IsNotNull(actual[i].Id);
                    Assert.IsNotNull(actual[i].UserId);
                    Assert.IsNotNull(actual[i].FullName);
                    Assert.IsNotNull(actual[i].Title);
                    Assert.IsNotNull(actual[i].Details);
                    Assert.IsNotNull(actual[i].CreatedAt);
                    Assert.IsNotNull(actual[i].Level);
                    Assert.IsNotNull(actual[i].Environment);
                    Assert.IsNotNull(actual[i].Address);
                    Assert.IsNotNull(actual[i].Archived);
                    Assert.AreEqual(actual[i].Id, (1 + i));
                }
            }

        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Deve_Obter_O_Source_De_Id_Correto(int id)
        {
            FakeContext fakeContext = CreateAndFillContextWithError();

            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var atual = service.Get(id);
                Assert.IsNotNull(atual);

                Assert.AreEqual(id, atual.Id);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parametro_Vazio_deve_retornar_Exception_ao_tentar_realizar_Post()
        {
            var fakeContext = CreateAndFillContextWithError();

            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                service.Create(null, null);
            }
        }

        [DataTestMethod]
        [DataRow("Title", "Details", 22, Level.Debug )]
        [DataRow("Title", "Details", 55, Level.Debug )]
        [DataRow("Title", "Details", 80, Level.Debug )]
        public void Deve_Falhar_Ao_Postar_Error_Com_Source_Invalido(string title, string details, int sourceId, Level level)
        {
            FakeContext fakeContext = CreateAndFillContextWithError();
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var newSource = new ErrorCreateDTO { Title = title, Details = details, SourceId = sourceId, Level = level };
                var service = CreateService(fakeContext, context);

                Assert.IsNotNull(newSource);
                var user = context.Users.FirstOrDefault();

                var identity = new[] { new Claim("Name", user.Id) };
                var result = service.Create(newSource, new ClaimsPrincipal(new ClaimsIdentity(identity)));

                Assert.AreEqual(false, result.Success);
                Assert.AreEqual("Invalid Source Id.", result.Message);
                Assert.AreEqual(null, result.Data);
            }
        }


        [DataTestMethod]
        [DataRow("Title", "Details", 1, Level.Debug)]
        [DataRow("Title", "Details", 2, Level.Debug)]
        [DataRow("Title", "Details", 3, Level.Debug)]
        public void Deve_Realizar_Post(string title, string details, int sourceId, Level level)
        {
            FakeContext fakeContext = CreateAndFillContextWithError();
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var newError = new ErrorCreateDTO { Title = title, Details = details, SourceId = sourceId, Level = level };

                Assert.IsNotNull(newError);

                Assert.IsNull(service.Get().Where(x => x.Id == newError.Id).FirstOrDefault());

                var user = context.Users.FirstOrDefault();

                var identity = new[] { new Claim("id", user.Id) };

                var savedError = service.Create(newError, new ClaimsPrincipal(new ClaimsIdentity(identity)));

                if (savedError.Success == false)
                {
                    Assert.AreEqual(false, savedError.Success);
                    Assert.AreEqual("Fail", savedError.Message);
                    Assert.IsNull(savedError.Data);
                }
                else
                {

                    Assert.AreEqual(true, savedError.Success);
                    Assert.AreEqual("Succesfully registred the error.", savedError.Message);
                    Assert.IsNotNull(savedError.Data);
                }
            }
        }


        [DataTestMethod]
        [DataRow(13)]
        [DataRow(23)]
        public void Deve_Falhar_Ao_Realizar_Error_Archive_Com_Id_inexistente(int id)
        {
            FakeContext fakeContext = CreateAndFillContextWithError();
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var result = service.Archive(id);

                var resultFail = new ResultDTO(false, $"Error id: {id} not found.", null);

                Assert.AreEqual(new { resultFail.Success, resultFail.Message },
                             new { result.Success, result.Message });

                Assert.IsNull(result.Data);

            }
        }

        [DataTestMethod]
        [DataRow(1)]
        public void Deve_Falhar_Ao_Realizar_Error_Archive_Error_Arquivado(int id)
        {
            FakeContext fakeContext = CreateAndFillContextWithError();
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                service.Archive(id);

                var result = service.Archive(id);

                var resultFail = new ResultDTO(false, $"Error id: {id} already archived.", null);

                Assert.AreEqual(new { resultFail.Success, resultFail.Message },
                             new { result.Success, result.Message });

                Assert.IsNull(result.Data);

            }
        }

        [DataTestMethod]
        [DataRow(2)]

        public void Deve_Realizar_Error_Archive(int id)
        {
            FakeContext fakeContext = CreateAndFillContextWithError();
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var result = service.Archive(id);

                var resultNotFail = new ResultDTO(true, "Successfuly archived", result.Data);
                Assert.AreEqual(new { resultNotFail.Success, resultNotFail.Message },
                             new { result.Success, result.Message });
                Assert.IsNotNull(result.Data);

            }
        }
        [DataTestMethod]
        [DataRow(43)]
        [DataRow(63)]
        public void Deve_Falhar_Ao_Realizar_Error_Unarchive_Com_Id_inexistente(int id)
        {
            FakeContext fakeContext = CreateAndFillContextWithError();
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var result = service.Unarchive(id);

                var resultFail = new ResultDTO(false, $"Error id: {id} not found.", null);

                Assert.IsNull(result.Data);
                Assert.AreEqual(new { resultFail.Success, resultFail.Message },
                             new { result.Success, result.Message });

            }
        }
        [DataTestMethod]
        [DataRow(3)]
        public void Deve_Falhar_Ao_Realizar_Error_Unarchive_Error_Desarquivado(int id)
        {
            FakeContext fakeContext = CreateAndFillContextWithError();
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var result = service.Unarchive(id);

                var resultFail = new ResultDTO(false, $"Error id: {id} already unarchived.", null);

                Assert.AreEqual(new { resultFail.Success, resultFail.Message },
                             new { result.Success, result.Message });

                Assert.IsNull(result.Data);

            }
        }

        [DataTestMethod]
        [DataRow(4)]
        public void Deve_Realizar_Error_Unarchive(int id)
        {
            FakeContext fakeContext = CreateAndFillContextWithError();
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                service.Archive(id);

                var result = service.Unarchive(id);

                var resultNotFail = new ResultDTO(true, "Successfuly unarchived", result.Data);
                Assert.AreEqual(new { resultNotFail.Success, resultNotFail.Message },
                             new { result.Success, result.Message });
                Assert.IsNotNull(result.Data);

            }
        }

        [DataTestMethod]
        [DataRow(13)]
        [DataRow(23)]
        public void Deve_Falhar_Ao_Realizar_Error_Delete_Com_Id_inexistente(int id)
        {
            FakeContext fakeContext = CreateAndFillContextWithError();
            using (var context = new CentralDeErrorContext(fakeContext.FakeOptions))
            {
                var service = CreateService(fakeContext, context);

                var result = service.Delete(id);

                var resultFail = new ResultDTO(false, $"Error id: {id} not found.", null);

                Assert.AreEqual(new { resultFail.Success, resultFail.Message },
                             new { result.Success, result.Message });

                Assert.IsNull(result.Data);
            }
        }

        [DataTestMethod]
        [DataRow(5)]
        public void Deve_Realizar_Error_Delete(int id)
        {
            FakeContext fakeContext = CreateAndFillContextWithError();
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

        private static FakeContext CreateAndFillContextWithError()
        {
            var fakeContext = new FakeContext("ErrorRepositoryTests");

            fakeContext.FillWithAllErrors();
            return fakeContext;
        }
        private static ErrorRepository CreateService(FakeContext fakeContext, CentralDeErrorContext context)
            => new ErrorRepository(context, fakeContext._mapper);
    }
}
