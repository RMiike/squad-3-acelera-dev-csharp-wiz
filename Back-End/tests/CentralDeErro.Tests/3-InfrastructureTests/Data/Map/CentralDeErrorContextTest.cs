using CentralDeErro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErro.Tests._3_InfrastructureTests.Data.Map
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

        public void Check_Table()
        {
            var entity = Check_Entity();
            Assert.IsNotNull(entity);
            var actual = this.Get_TableName(entity);
            Assert.AreEqual(Table, actual);
        }

        public IEntityType Check_Entity()
        {
            return _context.Model.FindEntityType(Model);
        }
        protected string Get_TableName(IEntityType entity)
        {
            var annotation = entity.FindAnnotation("Relational:TableName");
            return annotation?.Value?.ToString();
        }


        public void Check_Primary_Key(params string[] keys)
        {
            var entity = Check_Entity();
            Assert.IsNotNull(entity);

            var actualKeys = Get_Primary_Key(entity);
            Assert.IsNotNull(actualKeys);
            Assert.AreEqual(keys[0], actualKeys.FirstOrDefault());
        }

        protected IEnumerable<string> Get_Primary_Key(IEntityType entity)
        {
            var keys = entity.FindPrimaryKey();
            return keys?.Properties.
                Select(x => this.Get_ColumnName(x)).
                ToList();
        }
        protected string Get_ColumnName(IProperty property)
        {
            var annotation = property.FindAnnotation("Relational:ColumnName");
            return annotation?.Value?.ToString();
        }

        public void Check_Column(string fieldName, bool isNullable, Type fieldType, int? fieldSize)
        {
            var entity = Check_Entity();
            Assert.IsNotNull(entity);
            Assert.AreEqual(fieldName, entity.FindProperty(fieldName).Name);

            var property = Find_Field(entity, fieldName);
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
                size = fieldSize.HasValue ? Get_Field_Size(property) : 0
            }.ToString();
            Assert.AreEqual(expected, actual);
        }

        protected IEnumerable<string> Get_Column(IEntityType entity)
        {
            var properties = entity.GetProperties();
            return properties.Select(x => this.Get_ColumnName(x));
        }
        protected IProperty Find_Field(IEntityType entity, string fieldName)
        {
            var properties = entity.GetProperties();
            return properties.FirstOrDefault(x => this.Get_ColumnName(x) == fieldName);
        }
        protected int Get_Field_Size(IProperty property)
        {
            return property.GetMaxLength().Value;
        }

        public void Check_Foreign_Key(string fieldName, string expectedRelatedTable, bool required, params string[] expectedKeys)
        {
            var entity = Check_Entity();
            Assert.IsNotNull(entity);

            var relatedEntity = Check_Entity(expectedRelatedTable);
            Assert.IsNotNull(relatedEntity);

            var property = Find_Field(entity, fieldName);
            Assert.IsNotNull(property);

            var foreignKey = entity.FindForeignKeys(property).
                FirstOrDefault(x => x.PrincipalEntityType == relatedEntity);
            Assert.IsNotNull(foreignKey);

            Assert.AreEqual(required, foreignKey.IsRequired);

            var actualKeys = foreignKey.PrincipalKey.Properties.Select(x => Get_ColumnName(x));
            Assert.AreEqual(expectedKeys[0], actualKeys.FirstOrDefault());
        }

        private IEntityType Check_Entity(string tableName)
        {
            return _context.Model.GetEntityTypes().
                FirstOrDefault(x => Get_TableName(x) == tableName);
        }
        public void Check_Child_Access(string navigationTable)
        {
            var entity = Check_Entity();
            Assert.IsNotNull(entity);

            var relatedEntity = Check_Entity(navigationTable);
            Assert.IsNotNull(relatedEntity);

            var navigation = entity.GetNavigations().
                FirstOrDefault(x => x.ForeignKey.DeclaringEntityType == relatedEntity);

            Assert.IsNotNull(navigation);
            Assert.IsTrue(typeof(IEnumerable).IsAssignableFrom(navigation.ClrType));
        }

    }
}
