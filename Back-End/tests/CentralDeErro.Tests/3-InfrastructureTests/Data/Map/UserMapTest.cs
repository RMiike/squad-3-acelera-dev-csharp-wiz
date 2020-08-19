using CentralDeErro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CentralDeErro.Tests._3_InfrastructureTests.Data.Map
{
    [TestClass]
    public class UserMapTest : CentralDeErrorContextTest
    {

        public UserMapTest()
             : base(new CentralDeErrorContext(new DbContextOptionsBuilder<CentralDeErrorContext>()
               .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True")
               .Options))
        {
            Model = "CentralDeErro.Core.Entities.User";
            Table = "AspNetUsers";
        }
        [TestMethod]
        public void Should_Have_Table()
        {
            Check_Table();
        }
      
        [DataTestMethod]
        [DataRow("FullName", false, typeof(string), 60)]
        [DataRow("Email", false, typeof(string), 60)]
        [DataRow("CreatedAt", false, typeof(DateTime), null)]
        public void Should_Have_Field(string fieldName, bool isNullable, Type fieldType, int? fieldSize)
        {
            Check_Column(fieldName, isNullable, fieldType, fieldSize);
        }
    }
}
