using CentralDeErro.Infrastructure.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralDeErro.Tests.Data
{
    [TestClass]
    public class CentralDeErrorContextTest
    {
        private readonly CentralDeErrorContext _context;
        protected string Model { get; set; }
        protected string Table { get; set; }

        public CentralDeErrorContextTest(CentralDeErrorContext context)
        {
            _context = context;
        }

        public void VerificarTabela()
        {
            var entity = VerificarEntidade();
            Assert.IsNotNull(entity);
            var actual = this.ObterNomeDaTabela(entity);
            Assert.AreEqual(Table, actual);
        }

        public IEntityType VerificarEntidade()
        {
            return _context.Model.FindEntityType(Model);
        }
        protected string ObterNomeDaTabela(IEntityType entity)
        {
            var annotation = entity.FindAnnotation("Relational:TableName");
            return annotation?.Value?.ToString();
        }


        public void VerificarChavePrimaria(params string[] keys)
        {
            var entity = VerificarEntidade();
            Assert.IsNotNull(entity);

            var actualKeys = ObterChavePrimaria(entity);
            Assert.IsNotNull(actualKeys);
            Assert.AreEqual(keys[0], actualKeys.FirstOrDefault());
        }

        protected IEnumerable<string> ObterChavePrimaria(IEntityType entity)
        {
            var keys = entity.FindPrimaryKey();
            return keys?.Properties.
                Select(x => this.ObterNomeDoCampo(x)).
                ToList();
        }
        protected string ObterNomeDoCampo(IProperty property)
        {
            var annotation = property.FindAnnotation("Relational:ColumnName");
            return annotation?.Value?.ToString();
        }

        public void VerificarCampo(string fieldName, bool isNullable, Type fieldType, int? fieldSize)
        {
            var entity = VerificarEntidade();
            Assert.IsNotNull(entity);
            Assert.AreEqual(fieldName, entity.FindProperty(fieldName).Name);

            var property = BuscarCampo(entity, fieldName);
            var expected = new
            {
                type = fieldType,
                nullable = isNullable,
                size = fieldSize.HasValue ? fieldSize.Value : 0
            }.ToString();
            var actual = new
            {
                type = property.ClrType,
                nullable = property.IsColumnNullable(),
                size = fieldSize.HasValue ? ObterTamanhoDoCampo(property) : 0
            }.ToString();
            Assert.AreEqual(expected, actual);
        }

        protected IEnumerable<string> ObterNomeDosCampos(IEntityType entity)
        {
            var properties = entity.GetProperties();
            return properties.Select(x => this.ObterNomeDoCampo(x));
        }
        protected IProperty BuscarCampo(IEntityType entity, string fieldName)
        {
            var properties = entity.GetProperties();
            return properties.FirstOrDefault(x => this.ObterNomeDoCampo(x) == fieldName);
        }
        protected int ObterTamanhoDoCampo(IProperty property)
        {
            return property.GetMaxLength().Value;
        }

        public void AssertForeignKey(string fieldName, string expectedRelatedTable, bool required, params string[] expectedKeys)
        {
            var entity = VerificarEntidade();
            Assert.IsNotNull(entity);

            var relatedEntity = VerificarEntidade(expectedRelatedTable);
            Assert.IsNotNull(relatedEntity);

            var property = BuscarCampo(entity, fieldName);
            Assert.IsNotNull(property);

            var foreignKey = entity.FindForeignKeys(property).
                FirstOrDefault(x => x.PrincipalEntityType == relatedEntity);
            Assert.IsNotNull(foreignKey);

            Assert.AreEqual(required, foreignKey.IsRequired);

            var actualKeys = foreignKey.PrincipalKey.Properties.Select(x => ObterNomeDoCampo(x));
            Assert.AreEqual(expectedKeys[0], actualKeys.FirstOrDefault());
        }

        private IEntityType VerificarEntidade(string tableName)
        {
            return _context.Model.GetEntityTypes().
                FirstOrDefault(x => ObterNomeDaTabela(x) == tableName);
        }

    }
}
