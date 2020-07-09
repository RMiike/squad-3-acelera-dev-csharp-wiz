using CentralDeErro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErro.Tests.Data.Map
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
        public void Deve_ter_tabela()
        {
            VerificarTabela();
        }
      
        [DataTestMethod]
        [DataRow("FullName", false, typeof(string), 60)]
        [DataRow("Email", false, typeof(string), 60)]
        [DataRow("CreatedAt", false, typeof(DateTime), null)]
        public void Deve_ter_Campo(string fieldName, bool isNullable, Type fieldType, int? fieldSize)
        {
            VerificarCampo(fieldName, isNullable, fieldType, fieldSize);
        }
    }
}
