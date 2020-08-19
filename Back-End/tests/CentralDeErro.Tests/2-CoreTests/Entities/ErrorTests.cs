using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralDeErro.Tests._2_CoreTests.Entities
{
    [TestClass]
    public class ErrorTests
    {
        private readonly DateTime _createdAt = DateTime.UtcNow;

        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        public void NewError_ShouldHaveIdEquals_1(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);

            Assert.AreEqual(1, _newError.Id);
        }

        [DataTestMethod]
        [DataRow(1, "UserId", "Title", "Details", Level.Debug, 1)]
        public void NewError_Token_Should_Be_Token(int id, string userId, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, userId, title, details, level, sourceId);

            Assert.AreEqual("UserId", _newError.UserId);
        }

        [DataTestMethod]
        [DataRow(1, "Token", "", "Details", Level.Debug, 1)]
        [DataRow(1, "", "Title", "Details", Level.Debug, 1)]
        [DataRow(1, "Token", "Title", "", Level.Debug, 1)]

        [ExpectedException(typeof(ArgumentNullException))]
        public void Empty_Argument_ShouldReturn_ArgumentNullException(int id, string token, string title, string details, Level level, int sourceId)
        {
            Error.Create(id, token, title, details, level, sourceId);
        }

        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        public void NewError_Title_ShouldBeTitle(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);

            Assert.AreEqual("Title", _newError.Title);
        }



        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        public void NewError_Detail_ShouldBeDetail(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);

            Assert.AreEqual("Details", _newError.Details);
        }


        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Error, 1)]
        public void NewError_Level_ShouldBe_Error(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);

            Assert.AreEqual("Error", _newError.Level.ToString());
        }

        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        public void NewError_CreatedAt_ShouldBe_UTCNow(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);

            Assert.AreEqual(_createdAt.Date, _newError.CreatedAt.Date);
        }

        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        public void NewError_SourceId_ShouldBe_Equals_1(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);

            Assert.AreEqual(1, _newError.SourceId);
        }

        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        public void NewError_ShouldBe_Unarchived(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);

            Assert.IsFalse(_newError.Archived);
        }

        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        public void NewError_ShouldNotBe_DeletedTrue(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);

            Assert.IsFalse(_newError.Deleted);
        }

        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        public void Can_Archive_NewError(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);

            _newError.Archive();

            Assert.IsTrue(_newError.Archived);
        }

        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        public void Can_Delete_NewError(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);

            _newError.Delete();

            Assert.IsTrue(_newError.Deleted);
        }

        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        public void ArchivedError_CanBe_Unarchived(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);

            _newError.Archive();
            _newError.Unarchive();

            Assert.IsFalse(_newError.Archived);
        }

        [DataTestMethod]
        [DataRow(0, "Token", "Title", "Details", Level.Debug, 1)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Archive_Error_WithIdZero_Should_Throw_ArgumentNullException(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);
            _newError.Archive();
        }


        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UnarchivedError_Should_Throw_InvalidOperationException_When_Unarchived(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);
            _newError.Unarchive();
        }


        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ArchivedError_Should_Throw_InvalidOperationException_When_Archived(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);
            _newError.Archive();
            _newError.Archive();
        }


        [DataTestMethod]
        [DataRow(1, "Token", "Title", "Details", Level.Debug, 1)]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeletedError_Should_Throw_InvalidOperationException_When_Deleted(int id, string token, string title, string details, Level level, int sourceId)
        {
            var _newError = Error.Create(id, token, title, details, level, sourceId);
            _newError.Delete();
            _newError.Delete();
        }
    }
}
