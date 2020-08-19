using CentralDeErro.Core.Entities.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Environment = CentralDeErro.Core.Enums.Environment;

namespace CentralDeErro.Tests._2_CoreTests.DTOs
{
    [TestClass]
    public class SourceCreateDTOTest
    {

        [DataTestMethod]
        [DataRow("Address", Environment.Development)]
        public void Check_Address_Equals_Address(string address, Environment environment)
        {
            SourceCreateDTO sourceCreateDTO = new SourceCreateDTO
            {
                Address = address,
                Environment = environment
            };

            sourceCreateDTO.Validate();

            Assert.AreEqual("Address", sourceCreateDTO.Address);
        }


        [DataTestMethod]
        [DataRow("Addre", Environment.Development)]
        public void Check_Address_Bigger_Than_6_Chars(string address, Environment environment)
        {
            var sourceCreateDTO = new SourceCreateDTO
            {
                Address = address,
                Environment = environment
            };

            sourceCreateDTO.Validate();

            Assert.IsTrue(sourceCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow(Environment.Development)]
        public void Check_Address_Smaller_Than_Or_Equals_1024_Chars(Environment environment)
        {
            var sourceCreateDTO = new SourceCreateDTO
            {
                Address = new string('*', 1025),
                Environment = environment
            };

            sourceCreateDTO.Validate();

            Assert.IsTrue(sourceCreateDTO.Invalid);
        }


        [DataTestMethod]
        [DataRow("Address", Environment.Development)]
        [DataRow("Address", Environment.Homologation)]
        [DataRow("Address", Environment.Production)]
        public void Check_Environment_Equals_Development(string address, Environment environment)
        {
            var sourceCreateDTO = new SourceCreateDTO
            {
                Address = address,
                Environment = environment
            };

            Assert.AreEqual(environment.ToString(), sourceCreateDTO.Environment.ToString());
        }

        [DataTestMethod]
        [DataRow("Address")]
        public void Check_Valid_Environment_Between_0_and_Max(string address)
        {
            var max = (Environment.GetNames(typeof(Environment)).Length);

            var sourceCreateDTO = new SourceCreateDTO
            {
                Address = address,
                Environment = (Environment)max
            };

            sourceCreateDTO.Validate();

            Assert.IsTrue(sourceCreateDTO.Invalid, $"Max level should be {(max - 1)}");
        }
    }
}
