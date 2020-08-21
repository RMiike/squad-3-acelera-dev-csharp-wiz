using CentralDeErro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralDeErro.Tests._3_InfrastructureTests.Data.Map
{
    [TestClass]

    public class SourceMapTest : CentralDeErrorContextTest
    {
        public SourceMapTest()
            : base(new CentralDeErrorContext(new DbContextOptionsBuilder<CentralDeErrorContext>()
              .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True")
              .Options))
        {
            Model = "CentralDeErro.Core.Entities.Source";
            Table = "Source";
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
        [DataRow("Address", false, typeof(string), 60)]
        [DataRow("Environment", false, typeof(Core.Enums.Environment), 50)]
        [DataRow("Deleted", false, typeof(bool), null)]
        public void Should_Have_Field(string fieldName, bool isNullable, Type fieldType, int? fieldSize)
        {
            Check_Column(fieldName, isNullable, fieldType, fieldSize);
        }

        [DataTestMethod]
        [DataRow("Error")]
        public void Should_Have_Children_Navigation(string childrenTable)
        {
            Check_Child_Access(childrenTable);
        }
    }
}
