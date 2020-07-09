﻿using CentralDeErro.Core.Enums;
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
        [DataRow("Token", false, typeof(string), 450)]
        [DataRow("Title", false, typeof(string), 60)]
        [DataRow("Details", false, typeof(string), 1024)]
        [DataRow("CreatedAt", false, typeof(DateTime), null)]
        [DataRow("SourceId", false, typeof(int), null)]
        [DataRow("Level", false, typeof(Level), null)]
        [DataRow("Archived", false, typeof(bool), null)]
        [DataRow("Deleted", false, typeof(bool), null)]
        public void Deve_ter_Campo(string fieldName, bool isNullable, Type fieldType, int? fieldSize)
        {
            VerificarCampo(fieldName, isNullable, fieldType, fieldSize);
        }

        [DataTestMethod]
        [DataRow("SourceId", "Source", false, "Id")]
        public void Deve_Ter_Chave_Estrangeira(string fieldName, string relatedTable, bool isNullable, string relatedKey)
        {
            VerificaChaveEstrangeira(fieldName, relatedTable, !isNullable, relatedKey);
        }
    }
}
