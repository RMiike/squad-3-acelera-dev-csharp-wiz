using CentralDeErro.Core.Enums;
using CentralDeErro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErro.Tests.Data.Map
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
        public void Deve_ter_tabela()
        {
            VerificarTabela();
        }
        [TestMethod]
        public void Deve_ter_Chave_Primaria()
        {
            VerificarChavePrimaria("Id");
        }
        [DataTestMethod]
        [DataRow("Id", false, typeof(int), null)]
        [DataRow("Address", false, typeof(string), 60)]
        [DataRow("Environment", false, typeof(_Environment), 50)]
        [DataRow("Deleted", false, typeof(bool), null)]
        public void Deve_ter_Campo(string fieldName, bool isNullable, Type fieldType, int? fieldSize)
        {
            VerificarCampo(fieldName, isNullable, fieldType, fieldSize);
        }

        [DataTestMethod]
        [DataRow("Error")]
        public void Should_Has_Children_Navigation(string childrenTable)
        {
            VerificaAcessoFilha(childrenTable);
        }
    }
}
