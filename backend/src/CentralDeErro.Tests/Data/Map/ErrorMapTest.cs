using CentralDeErro.Core.Enums;
using CentralDeErro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralDeErro.Tests.Data.Map
{
    [TestClass]
    public class ErrorMapTest : CentralDeErrorContextTest
    {

        public ErrorMapTest()
             : base(new CentralDeErrorContext(new DbContextOptionsBuilder<CentralDeErrorContext>()
               .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True")
               .Options))
        {
            Model = "CentralDeErro.Core.Entities.Error";
            Table = "Error";
        }
            

        [TestMethod]
        public void Should_Have_Table()
        {
            Check_Table();
        }

        [TestMethod]
        public void Should_Have_Primary_Key()
        {
            Check_Primary_Key("Id");
        }

        [DataTestMethod]
        [DataRow("Id", false, typeof(int), null)]
        [DataRow("Token", false, typeof(string), 450)]
        [DataRow("Title", false, typeof(string), 60)]
        [DataRow("Details", false, typeof(string), 1024)]
        [DataRow("CreatedAt", false, typeof(DateTime), null)]
        [DataRow("SourceId", false, typeof(int), null)]
        [DataRow("Level", false, typeof(Level), null)]
        [DataRow("Archived", false, typeof(bool), null)]
        [DataRow("Deleted", false, typeof(bool), null)]
        public void Should_Have_Field(string fieldName, bool isNullable, Type fieldType, int? fieldSize)
        {
            Check_Column(fieldName, isNullable, fieldType, fieldSize);
        }

        [DataTestMethod]
        [DataRow("SourceId", "Source", false, "Id")]
        public void Should_Have_Foreign_Key(string fieldName, string relatedTable, bool isNullable, string relatedKey)
        {
            Check_Foreign_Key(fieldName, relatedTable, !isNullable, relatedKey);
        }
    }
}
