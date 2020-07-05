using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralDeErro.Tests.Entities
{
    [TestClass]
    public class Error_Tests
    {
        #region props
        private readonly int _id = 1;
        private readonly string _token = "Token";
        private readonly string _title = "Title";
        private readonly string _details = "Details";
        private readonly Level _level = Level.Error;
        private readonly DateTime _createdAt = DateTime.UtcNow;
        private readonly int _sourceId = 1;
        #endregion
        //var errors = new Faker<Error>("pt_br")
        //       .RuleFor(e => e.Id, f => f.Random.Int())
        //       .RuleFor(e => e.Token, f => f.Random.Guid().ToString())
        //       .RuleFor(e => e.Title, f => f.Lorem.Sentence(3))
        //       .RuleFor(e => e.Details, f => f.Lorem.Paragraphs(3, "\n\n"))
        //       .RuleFor(e => e.Level, Core.Enums.Level.Debug)
        //       .RuleFor(e => e.CreatedAt, f => f.Date.Recent(1))
        //       .RuleFor(e => e.SourceId, 1)
        //       .Generate(3);
        #region New Error
        [TestMethod]
        [TestCategory("New Error")]
        public void O_Id_Do_Novo_Error_Deve_Ser_1()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level,  _sourceId);

            Assert.AreEqual(1,_newError.Id);
        }
     
        [TestMethod]
        [TestCategory("New Error")]
        public void O_Token_Do_Novo_Error_Deve_Ser_Token()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            Assert.AreEqual("Token", _newError.Token);
        }
        [TestMethod]
        [TestCategory("New Error")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void O_Token_Vazio_Retornar_ArgumentNullException()
        {
           Error.Create(_id, "", _title, _details, _level, _sourceId);
        }
        [TestMethod]
        [TestCategory("New Error")]
        public void O_Titulo_Do_Novo_Error_Deve_Ser_Title()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            Assert.AreEqual("Title", _newError.Title);
        }
        [TestMethod]
        [TestCategory("New Error")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void O_Titulo_Vazio_Retornar_ArgumentNullException()
        {
           Error.Create(_id, _token, "", _details, _level, _sourceId);
        }
        [TestMethod]
        [TestCategory("New Error")]
        public void O_Detalhe_Do_Novo_Error_Deve_Ser_Detail()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            Assert.AreEqual("Details", _newError.Details);
        }
        [TestMethod]
        [TestCategory("New Error")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void O_Detalhe_Vazio_Retornar_ArgumentNullException()
        {
            Error.Create(_id, _token, _title, "", _level, _sourceId);
        }
        [TestMethod]
        [TestCategory("New Error")]
        public void O_Level_Do_Novo_Error_Deve_Ser_Error()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            Assert.AreEqual("Error", _newError.Level.ToString());
        }
      
        [TestMethod]
        [TestCategory("New Error")]
        public void O_CreatedAt_Do_Novo_Error_Deve_Ser_O_Horario_DeAgora()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level,  _sourceId);
          
            Assert.AreEqual(_createdAt.Date, _newError.CreatedAt.Date);
        }
        [TestMethod]
        [TestCategory("New Error")]
        public void O_SourceId_Do_Novo_Error_Deve_Ser_1()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level,  _sourceId);

            Assert.AreEqual(1, _newError.SourceId);
        }
        [TestMethod]
        [TestCategory("New Error")]
        public void Novo_Error_Tem_Que_Estar_Desarquivado()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level,  _sourceId);

            Assert.IsFalse(_newError.Archived);
        }

        [TestMethod]
        [TestCategory("New Error")]
        public void Novo_Error_Nao_Pode_Que_Estar_Deletado()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level,  _sourceId);

            Assert.IsFalse(_newError.Deleted);
        }

        [TestMethod]
        [TestCategory("New Error")]
        public void Possivel_Arquivar_Novo_Error()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level,  _sourceId);

            _newError.Archive();

            Assert.IsTrue(_newError.Archived);
        }


        [TestMethod]
        [TestCategory("New Error")]
        public void Possivel_Deletar_Um_Novo_Error()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level,  _sourceId);

            _newError.Delete();

            Assert.IsTrue(_newError.Deleted);
        }

        #endregion
        [TestMethod]
        public void Possivel_Desarquivar_Um_Error_Arquivado()
        {
            var _newError = Error.Create(1, _token, _title, _details, _level,  _sourceId);

            _newError.Archive();
            _newError.Unarchive();

            Assert.IsFalse(_newError.Archived);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Arquivar_ErrorId_Igual_Zero_Joga_Um_ArgumentNullException()
        {
            var _newError = Error.Create(0, _token, _title, _details, _level,  _sourceId);
            _newError.Archive();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Desarquivar_Um_Error_Desarquivado_Joga_Um_InvalidOperationException()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level,  _sourceId);
            _newError.Unarchive();
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Arquivar_Um_Error_Arquivado_Joga_Um_InvalidOperationException()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level,  _sourceId);
            _newError.Archive();
            _newError.Archive();
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Deletar_Um_Error_Deletado_Joga_Um_InvalidOperationException()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level,  _sourceId);
            _newError.Delete();
            _newError.Delete();
        }
    }
}
