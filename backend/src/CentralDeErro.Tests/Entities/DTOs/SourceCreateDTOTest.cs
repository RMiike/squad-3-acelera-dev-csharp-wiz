using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentralDeErro.Tests.Entities.DTOs
{
    [TestClass]
    public class SourceCreateDTOTest
    {
        #region props
        private readonly _Environment _environment = _Environment.Development;
        #endregion
        private readonly SourceCreateDTO _sourceCreateDTO = new SourceCreateDTO
        {
            Address = "Address",
            Environment =  _Environment.Development
        };


        [TestMethod]
        public void Endereco_deve_ser_Address()
        {
            _sourceCreateDTO.Validate();

            Assert.AreEqual("Address", _sourceCreateDTO.Address);
        }
        [TestMethod]
        public void Endereco_deve_ter_no_minimo_6_chars()
        {
            var sourceCreateDTO = new SourceCreateDTO
            {
                Address = "12345",
                Environment = _environment
            };

            sourceCreateDTO.Validate();

            Assert.IsTrue(sourceCreateDTO.Invalid);
        }
        [TestMethod]
        public void Endereco_deve_ter_no_maximos_1024_chars()
        {
            var sourceCreateDTO = new SourceCreateDTO
            {
                Address = new string('*',1025),
                Environment = _environment
            };

            sourceCreateDTO.Validate();

            Assert.IsTrue(sourceCreateDTO.Invalid);
        }
        [TestMethod]
        public void O_Environment_Deve_Ser_Development()
        {
            Assert.AreEqual("Development", _sourceCreateDTO.Environment.ToString());
        }

        [TestMethod]
        public void O_Environment_Deve_Ser_Valido_Entre_0_E_Max()
        {
            var max = (_Environment.GetNames(typeof(_Environment)).Length);

            var sourceCreateDTO = new SourceCreateDTO
            {
                Address = new string('*', 1025),
                Environment = (_Environment)max
            };

            sourceCreateDTO.Validate();

            Assert.IsTrue(sourceCreateDTO.Invalid, $"Max level should be {(max - 1)}");
        }
    }
}
