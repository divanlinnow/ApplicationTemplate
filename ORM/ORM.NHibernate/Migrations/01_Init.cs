using FluentMigrator;
using System;

namespace ORM.NHibernate.Migrations
{
    [Migration(01)]
    public class _01_Init : Migration
    {
        public override void Up()
        {
            Create.Table("Category")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(255);

            Create.Table("Product")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("CategoryId").AsInt32().ForeignKey("Category", "Id")
                .WithColumn("Name").AsString(255)
                .WithColumn("Price").AsDecimal();
        }

        public override void Down()
        {
            Delete.Table("Product");
            Delete.Table("Category");
        }
    }
}