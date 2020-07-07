using AutoMapper;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
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
        public void NewError_ShouldHaveIdEquals_1()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            Assert.AreEqual(1, _newError.Id);
        }

        [TestMethod]
        [TestCategory("New Error")]
        public void NewError_Token_Should_Be_Token()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            Assert.AreEqual("Token", _newError.Token);
        }

        [TestMethod]
        [TestCategory("New Error")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Empty_Token_ShouldReturn_ArgumentNullException()
        {
            Error.Create(_id, "", _title, _details, _level, _sourceId);
        }

        [TestMethod]
        [TestCategory("New Error")]
        public void NewError_Title_ShouldBeTitle()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            Assert.AreEqual("Title", _newError.Title);
        }

        [TestMethod]
        [TestCategory("New Error")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyTitle_ShouldReturn_ArgumentNullException()
        {
            Error.Create(_id, _token, "", _details, _level, _sourceId);
        }
        [TestMethod]
        [TestCategory("New Error")]
        public void NewError_Detail_ShouldBeDetail()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            Assert.AreEqual("Details", _newError.Details);
        }
        [TestMethod]
        [TestCategory("New Error")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyDetail_ShouldReturn_ArgumentNullException()
        {
            Error.Create(_id, _token, _title, "", _level, _sourceId);
        }

        [TestMethod]
        [TestCategory("New Error")]
        public void NewError_Level_ShouldBe_Error()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            Assert.AreEqual("Error", _newError.Level.ToString());
        }

        [TestMethod]
        [TestCategory("New Error")]
        public void NewError_CreatedAt_ShouldBe_UTCNow()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);
<<<<<<< HEAD
<<<<<<< HEAD

=======
=======
>>>>>>> 4a9d2406de5740a73e120ae1ad05ff19edf02fb0
          
>>>>>>> 4a9d2406de5740a73e120ae1ad05ff19edf02fb0
            Assert.AreEqual(_createdAt.Date, _newError.CreatedAt.Date);
        }
        [TestMethod]
        [TestCategory("New Error")]
        public void NewError_SourceId_ShouldBe_Equals_1()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            Assert.AreEqual(1, _newError.SourceId);
        }
        [TestMethod]
        [TestCategory("New Error")]
        public void NewError_ShouldBe_Unarchived()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            Assert.IsFalse(_newError.Archived);
        }

        [TestMethod]
        [TestCategory("New Error")]
        public void NewError_ShouldNotBe_DeletedTrue()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            Assert.IsFalse(_newError.Deleted);
        }

        [TestMethod]
        [TestCategory("New Error")]
        public void Can_Archive_NewError()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            _newError.Archive();

            Assert.IsTrue(_newError.Archived);
        }


        [TestMethod]
        [TestCategory("New Error")]
        public void Can_Delete_NewError()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);

            _newError.Delete();

            Assert.IsTrue(_newError.Deleted);
        }

        #endregion
        [TestMethod]
        public void ArchivedError_CanBe_Unarchived()
        {
            var _newError = Error.Create(1, _token, _title, _details, _level, _sourceId);

            _newError.Archive();
            _newError.Unarchive();

            Assert.IsFalse(_newError.Archived);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Archive_Error_WithIdZero_Should_Throw_ArgumentNullException()
        {
            var _newError = Error.Create(0, _token, _title, _details, _level, _sourceId);
            _newError.Archive();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UnarchivedError_Should_Throw_InvalidOperationException_When_Unarchived()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);
            _newError.Unarchive();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ArchivedError_Should_Throw_InvalidOperationException_When_Archived()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);
            _newError.Archive();
            _newError.Archive();
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeletedError_Should_Throw_InvalidOperationException_When_Deleted()
        {
            var _newError = Error.Create(_id, _token, _title, _details, _level, _sourceId);
            _newError.Delete();
            _newError.Delete();
        }
    }
}
