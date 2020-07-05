using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralDeErro.Tests.Entities
{
    [TestClass]
    public class Source_Tests
    {
        #region props
        private readonly int _id = 1;
        private readonly string _address = "Address";
        private readonly _Environment _environment = _Environment.Development;
        #endregion

        [TestMethod]
        [TestCategory("New Source")]
        public void O_Id_Do_Novo_Source_Deve_Ser_1()
        {
            var _newSource = Source.Create(_id, _address, _environment);

            Assert.AreEqual(1, _newSource.Id);
        }

       

        [TestMethod]
        [TestCategory("New Source")]
        public void O_Endereco_Do_Novo_Source_Deve_Ser_Address()
        {
            var _newSource = Source.Create(_id, _address, _environment);

            Assert.AreEqual("Address", _newSource.Address);
        }

        [TestMethod]
        [TestCategory("New Source")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void O_Endereco_Vazio_Retorna_ArgumentNullException()
        {
            Source.Create(_id, "", _environment);
        }

        [TestMethod]
        [TestCategory("New Source")]
        public void O_Ambiente_Do_Novo_Source_Deve_Ser_Development()
        {
            var _newSource = Source.Create(_id, _address, _environment);

            Assert.AreEqual("Development", _newSource.Environment.ToString());
        }

        [TestMethod]
        [TestCategory("New Source")]
        public void Novo_Source_Nao_Pode_Que_Estar_Deletado()
        {
            var _newSource = Source.Create(_id, _address, _environment);

            Assert.IsFalse(_newSource.Deleted);
        }

        [TestMethod]
        [TestCategory("New Source")]
        public void Novo_Source_Pode_Ser_Deletado()
        {
            var _newSource = Source.Create(_id, _address, _environment);
            _newSource.Delete();

            Assert.IsTrue(_newSource.Deleted);
        }

        [TestMethod]
        [TestCategory("New Source")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Source_Deletado_Nao_Pode_Ser_Deletado_InvalidOperationException()
        {
            var _newSource = Source.Create(_id, _address, _environment);
            _newSource.Delete();
            _newSource.Delete();
        }
    }
}
