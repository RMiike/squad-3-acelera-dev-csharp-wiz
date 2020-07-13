using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralDeErro.Tests.Entities.DTOs
{
    [TestClass]
    public class ErrorCreateDTOTest
    {
        private readonly ErrorCreateDTO errorCreateDTO = new ErrorCreateDTO
        {
            Title = "Title",
            Details = "Details",
            SourceId = 1,
            Level = Level.Error
        };

        [TestMethod]
        public void Check_Title_Equals_Title()
        {
            Assert.AreEqual("Title", errorCreateDTO.Title);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Token_Throws_ArgumentNullException()
        {
            errorCreateDTO.AddToken(null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Empty_Token_Throws_ArgumentNullException()
        {
            errorCreateDTO.AddToken("");
        }
        [TestMethod]
        public void Check_Token_Equals_Token()
        {
            errorCreateDTO.AddToken("Token");

            Assert.AreEqual("Token", errorCreateDTO.Token);
        }
        [TestMethod]
        public void Check_Title_Bigger_Than_3_Chars()
        {
            var newErrorCreateDTO = new ErrorCreateDTO
            {
                Title = "Ti",
                Details = "Details",
                SourceId = 1,
                Level = Level.Error
            };

            newErrorCreateDTO.Validate();

            Assert.IsTrue(newErrorCreateDTO.Invalid);
        }
        [TestMethod]
        public void Check_Title_Smaller_Or_Equals_100_Chars()
        {
            var newErrorCreateDTO = new ErrorCreateDTO
            {
                Title = new string('*', 101),
                Details = "Details",
                SourceId = 1,
                Level = Level.Error
            };

            newErrorCreateDTO.Validate();

            Assert.IsTrue(newErrorCreateDTO.Invalid);
        }
        [TestMethod]
        public void Check_Detail_Equals_Details()
        {
            Assert.AreEqual("Details", errorCreateDTO.Details);
        }

        [TestMethod]
        public void Check_Detail_Bigger_Than_6_Chars()
        {
            var newErrorCreateDTO = new ErrorCreateDTO
            {
                Title = "Title",
                Details = "Detai",
                SourceId = 1,
                Level = Level.Error
            };

            newErrorCreateDTO.Validate();

            Assert.IsTrue(newErrorCreateDTO.Invalid);
        }
        [TestMethod]
        public void Check_Detail_Smaller_or_Equals_1024()
        {
            var newErrorCreateDTO = new ErrorCreateDTO
            {
                Title = "Title",
                Details = new string('*', 1025),
                SourceId = 1,
                Level = Level.Error
            };

            newErrorCreateDTO.Validate();

            Assert.IsTrue(newErrorCreateDTO.Invalid);
        }

        [TestMethod]
        public void Check_SourceId_Equals_1()
        {
            Assert.AreEqual(1, errorCreateDTO.SourceId);
        }
      
        [TestMethod]
        public void Check_SourceId_Between_1_and_100()
        {
            var newErrorCreateDTO = new ErrorCreateDTO
            {
                Title = "Title",
                Details = "Details",
                SourceId = 101,
                Level = Level.Error
            };

            newErrorCreateDTO.Validate();

            Assert.IsTrue(newErrorCreateDTO.Invalid);
        }
        [TestMethod]
        public void Check_Level_Equals_Error()
        {
            Assert.AreEqual("Error", errorCreateDTO.Level.ToString());
        }
        [TestMethod]
        public void Check_Valid_Level_Between_0_and_Max()
        {
            var max = (Level.GetNames(typeof(Level)).Length);

            var newErrorCreateDTO = new ErrorCreateDTO
            {
                Title = "Title",
                Details = "Detai",
                SourceId = 1,
                Level = (Level)max 
            };

            newErrorCreateDTO.Validate();

            Assert.IsTrue(newErrorCreateDTO.Invalid, $"Max level should be {(max - 1)}");
        }

    }
}
