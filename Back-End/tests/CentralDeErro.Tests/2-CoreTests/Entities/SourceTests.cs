using CentralDeErro.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Environment = CentralDeErro.Core.Enums.Environment;

using System;

namespace CentralDeErro.Tests._2_CoreTests.Entities
{
    [TestClass]
    public class SourceTests
    {

        [DataTestMethod]
        [DataRow(1, "Address", Environment.Development)]
        public void NewSource_ShouldHaveIdEquals_1(int id, string address, Environment environment)
        {
            var _newSource = Source.Create(id, address, environment);

            Assert.AreEqual(1, _newSource.Id);
        }

        [DataTestMethod]
        [DataRow(1, "Address", Environment.Development)]
        public void NewSource_Address_ShouldBeAddress(int id, string address, Environment environment)
        {
            var _newSource = Source.Create(id, address, environment);

            Assert.AreEqual("Address", _newSource.Address);
        }

        [DataTestMethod]
        [DataRow(1, "", Environment.Development)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Empty_Address_ShouldReturn_ArgumentNullException(int id, string address, Environment environment)
        {
            Source.Create(id, address, environment);
        }

        [DataTestMethod]
        [DataRow(1, "Address", Environment.Development)]
        public void NewSource_Environment_ShouldBeDefault(int id, string address, Environment environment)
        {
            var _newSource = Source.Create(id, address, environment);

            Assert.AreEqual("Development", _newSource.Environment.ToString());
        }

        [DataTestMethod]
        [DataRow(1, "Address", Environment.Development)]
        public void NewSource_Deleted_ShouldBeEquals_False(int id, string address, Environment environment)
        {
            var _newSource = Source.Create(id, address, environment);

            Assert.IsFalse(_newSource.Deleted);
        }

        [DataTestMethod]
        [DataRow(1, "Address", Environment.Development)]
        public void NewSource_CanBe_Deleted(int id, string address, Environment environment)
        {
            var _newSource = Source.Create(id, address, environment);
            _newSource.Delete();

            Assert.IsTrue(_newSource.Deleted);
        }

        [DataTestMethod]
        [DataRow(1, "Address", Environment.Development)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeletedSource_ShouldThrow_InvalidOperationException_When_Deleted(int id, string address, Environment environment)
        {
            var _newSource = Source.Create(id, address, environment);
            _newSource.Delete();
            _newSource.Delete();
        }
    }
}
