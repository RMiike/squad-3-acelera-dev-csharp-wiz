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
        public void NewSource_ShouldHaveIdEquals_1()
        {
            var _newSource = Source.Create(_id, _address, _environment);

            Assert.AreEqual(1, _newSource.Id);
        }

        [TestMethod]
        [TestCategory("New Source")]
        public void NewSource_Address_ShouldBeAddress()
        {
            var _newSource = Source.Create(_id, _address, _environment);

            Assert.AreEqual("Address", _newSource.Address);
        }

        [TestMethod]
        [TestCategory("New Source")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Empty_Address_ShouldReturn_ArgumentNullException()
        {
            Source.Create(_id, "", _environment);
        }

        [TestMethod]
        [TestCategory("New Source")]
        public void NewSource_Environment_ShouldBeDefault()
        {
            var _newSource = Source.Create(_id, _address, _environment);

            Assert.AreEqual("Development", _newSource.Environment.ToString());
        }

        [TestMethod]
        [TestCategory("New Source")]
        public void NewSource_Deleted_ShouldBeEquals_False()
        {
            var _newSource = Source.Create(_id, _address, _environment);

            Assert.IsFalse(_newSource.Deleted);
        }

        [TestMethod]
        [TestCategory("New Source")]
        public void NewSource_CanBe_Deleted()
        {
            var _newSource = Source.Create(_id, _address, _environment);
            _newSource.Delete();

            Assert.IsTrue(_newSource.Deleted);
        }

        [TestMethod]
        [TestCategory("New Source")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeletedSource_ShouldThrow_InvalidOperationException_When_Deleted()
        {
            var _newSource = Source.Create(_id, _address, _environment);
            _newSource.Delete();
            _newSource.Delete();
        }
    }
}
