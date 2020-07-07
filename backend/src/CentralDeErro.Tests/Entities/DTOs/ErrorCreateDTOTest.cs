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
        public void O_Titulo_Deve_Ser_Title()
        {

            Assert.AreEqual("Title", errorCreateDTO.Title);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void O_Token_Null_Retorna_ArgumentNullException()
        {
            errorCreateDTO.AddToken(null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void O_Token_Vazio_Retorna_ArgumentNullException()
        {
            errorCreateDTO.AddToken("");
        }
        [TestMethod]
        public void O_Token_Deve_Ser_Token()
        {
            errorCreateDTO.AddToken("Token");

            Assert.AreEqual("Token", errorCreateDTO.Token);
        }
        [TestMethod]
        public void O_Titulo_Deve_Ter_Pelo_Menos_3_Chars()
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
        public void O_Titulo_Deve_Ser_Menor_Ou_Igual_A_100()
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
        public void O_Detalhe_Deve_Ser_Details()
        {

            Assert.AreEqual("Details", errorCreateDTO.Details);
        }

        [TestMethod]
        public void O_Detalhe_Deve_Ter_Pelo_Menos_6_Chars()
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
        public void O_Detalhe_Deve_Ser_Menor_Ou_Igual_A_1024()
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
        public void O_SourceId_Deve_Ser_1()
        {
            Assert.AreEqual(1, errorCreateDTO.SourceId);
        }
      
        [TestMethod]
        public void O_SourceId_Deve_Ser_Entre_1_e_100()
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
        public void O_Level_Deve_Ser_Error()
        {
            Assert.AreEqual("Error", errorCreateDTO.Level.ToString());
        }
        [TestMethod]
        public void O_Level_Deve_Ser_Valido_Entre_0_E_Max()
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
