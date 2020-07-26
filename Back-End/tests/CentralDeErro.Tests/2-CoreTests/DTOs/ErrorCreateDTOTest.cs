using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralDeErro.Tests._2_CoreTests.DTOs
{
    [TestClass]
    public class ErrorCreateDTOTest
    {

        [DataTestMethod]
        [DataRow("Title", "Details", 1, Level.Error, "userId")]
        public void Novo_Erro_Deve_Ser_Valido(string title, string details, int sourceId, Level level, string userId)
        {
            ErrorCreateDTO errorCreateDTO = new ErrorCreateDTO
            {
                Title = title,
                Details = details,
                SourceId = sourceId,
                Level = level
            };

            Assert.IsNotNull(errorCreateDTO);

            errorCreateDTO.Validate();

            Assert.IsTrue(errorCreateDTO.Valid);

            errorCreateDTO.AddUserId(userId);
            errorCreateDTO.Validate();

            Assert.IsTrue(errorCreateDTO.Valid);

            Assert.AreEqual(userId, errorCreateDTO.UserId);
        }
        [DataTestMethod]
        [DataRow("Title", "Details", 1, Level.Error)]
        public void Check_Title_Equals_Title(string title, string details, int sourceId, Level level)
        {
            ErrorCreateDTO errorCreateDTO = new ErrorCreateDTO
            {
                Title = title,
                Details = details,
                SourceId = sourceId,
                Level = level
            };

            Assert.AreEqual("Title", errorCreateDTO.Title);
        }

        [DataTestMethod]
        [DataRow("Title", "Details", 1, Level.Error, null)]
        [DataRow("Title", "Details", 1, Level.Error, "")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Token_Throws_ArgumentNullException(string title, string details, int sourceId, Level level, string token)
        {

            ErrorCreateDTO errorCreateDTO = new ErrorCreateDTO
            {
                Title = title,
                Details = details,
                SourceId = sourceId,
                Level = level
            };


            errorCreateDTO.AddUserId(token);
        }

        [DataTestMethod]
        [DataRow("Title", "Details", 1, Level.Error, "UserId")]
        public void Check_Token_Equals_Token(string title, string details, int sourceId, Level level, string userId)
        {

            ErrorCreateDTO errorCreateDTO = new ErrorCreateDTO
            {
                Title = title,
                Details = details,
                SourceId = sourceId,
                Level = level
            };

            errorCreateDTO.AddUserId(userId);

            Assert.AreEqual("UserId", errorCreateDTO.UserId);
        }

        [DataTestMethod]
        [DataRow("Ti", "Details", 1, Level.Error)]
        public void Check_Title_Bigger_Than_3_Chars(string title, string details, int sourceId, Level level)
        {
            var newErrorCreateDTO = new ErrorCreateDTO
            {
                Title = title,
                Details = details,
                SourceId = sourceId,
                Level = level
            };

            newErrorCreateDTO.Validate();

            Assert.IsTrue(newErrorCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow("Details", 1, Level.Error)]
        public void Check_Title_Smaller_Or_Equals_100_Chars(string details, int sourceId, Level level)
        {
            var newErrorCreateDTO = CreateErrorDTO(new string('*', 101), details, sourceId, level);

            Assert.IsTrue(newErrorCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow("Title", "Details", 1, Level.Error)]
        public void Check_Detail_Equals_Details(string title, string details, int sourceId, Level level)
        {
            ErrorCreateDTO errorCreateDTO = CreateErrorDTO(title, details, sourceId, level);

            Assert.IsTrue(errorCreateDTO.Valid);

            Assert.AreEqual("Details", errorCreateDTO.Details);
        }

        [DataTestMethod]
        [DataRow("Title", "Detai", 1, Level.Error)]
        public void Check_Detail_Bigger_Than_6_Chars(string title, string details, int sourceId, Level level)
        {
            ErrorCreateDTO newErrorCreateDTO = CreateErrorDTO(title, details, sourceId, level);

            Assert.IsTrue(newErrorCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow("Title", 1, Level.Error)]
        public void Check_Detail_Smaller_or_Equals_1024(string title, int sourceId, Level level)
        {
            var newErrorCreateDTO = CreateErrorDTO(title, new string('*', 1025), sourceId, level);

            Assert.IsTrue(newErrorCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow("Title", "Details", 1, Level.Error)]
        public void Check_SourceId_Equals_1(string title, string details, int sourceId, Level level)
        {
            ErrorCreateDTO errorCreateDTO = CreateErrorDTO(title, details, sourceId, level);

            Assert.IsTrue(errorCreateDTO.Valid);

            Assert.AreEqual(1, errorCreateDTO.SourceId);
        }

        [DataTestMethod]
        [DataRow("Title", "Details", 101, Level.Error)]
        public void Check_SourceId_Between_1_and_100(string title, string details, int sourceId, Level level)
        {
            var newErrorCreateDTO = CreateErrorDTO(title, details, sourceId, level);

            Assert.IsTrue(newErrorCreateDTO.Invalid);
        }

        [DataTestMethod]
        [DataRow("Title", "Details", 1, Level.Error)]
        public void Check_Level_Equals_Error(string title, string details, int sourceId, Level level)
        {
            ErrorCreateDTO errorCreateDTO = CreateErrorDTO(title, details, sourceId, level);

            Assert.IsTrue(errorCreateDTO.Valid);
            Assert.AreEqual("Error", errorCreateDTO.Level.ToString());
        }

        [DataTestMethod]
        [DataRow("Title", "Details", 1)]
        public void Check_Valid_Level_Between_0_and_Max(string title, string details, int sourceId)
        {
            var max = (Level.GetNames(typeof(Level)).Length);

            var newErrorCreateDTO = CreateErrorDTO(title, details, sourceId, (Level)max);

            Assert.IsTrue(newErrorCreateDTO.Invalid, $"Max level should be {(max - 1)}");
        }
        private static ErrorCreateDTO CreateErrorDTO(string title, string details, int sourceId, Level level)
        {
            var newErrorCreateDTO = new ErrorCreateDTO
            {
                Title = title,
                Details = details,
                SourceId = sourceId,
                Level = level
            };

            newErrorCreateDTO.Validate();
            return newErrorCreateDTO;
        }
    }
}
