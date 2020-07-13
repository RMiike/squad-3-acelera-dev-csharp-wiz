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
        public void Check_Address_Equals_Address()
        {
            _sourceCreateDTO.Validate();

            Assert.AreEqual("Address", _sourceCreateDTO.Address);
        }
        [TestMethod]
        public void Check_Address_Bigger_Than_6_Chars()
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
        public void Check_Address_Smaller_Than_Or_Equals_1024_Chars()
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
        public void Check_Environment_Equals_Development()
        {
            Assert.AreEqual("Development", _sourceCreateDTO.Environment.ToString());
        }

        [TestMethod]
        public void Check_Valid_Environment_Between_0_and_Max()
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
