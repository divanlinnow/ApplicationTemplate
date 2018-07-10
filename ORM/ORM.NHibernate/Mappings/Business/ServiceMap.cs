using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class ServiceMap : ClassMap<Service>
    {
        public ServiceMap()
        {
            Table("Services");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("INT")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.Name)
                .Column("Name")
                .CustomSqlType("NVARCHAR(50)")
                .Not.Nullable();

            Map(x => x.Description)
                .Column("Description")
                .CustomSqlType("NVARCHAR(1000)")
                .Nullable();

            Map(x => x.MinimumOrderQuantity)
                 .Column("MinimumOrderQuantity")
                 .CustomSqlType("DECIMAL")
                 .Nullable();

            Map(x => x.PriceEXCL)
                .Column("PriceEXCL")
                .CustomSqlType("DECIMAL")
                .Not.Nullable();

            Map(x => x.PriceINCL)
                .Column("PriceINCL")
                .CustomSqlType("DECIMAL")
                .Not.Nullable();

            Map(x => x.PriceMustChange)
                .Column("PriceMustChange")
                .CustomSqlType("BIT")
                .Not.Nullable();

            Map(x => x.PriceExpiryDate)
                .Column("PriceExpiryDate")
                .CustomSqlType("DATETIME2(0)")
                .Nullable();

            Map(x => x.HasExpiryDate)
                .Column("HasExpiryDate")
                .CustomSqlType("BIT")
                .Not.Nullable();

            Map(x => x.ExpiryDate)
                .Column("ExpiryDate")
                .CustomSqlType("DATETIME2(0)")
                .Nullable();

            HasOne(x => x.Supplier);

            Map(x => x.Created)
               .Column("Created")
               .CustomSqlType("DATETIME2(0)")
               .Not.Nullable();

            HasOne(x => x.CreatedBy);

            Map(x => x.Modified)
                .Column("Modified")
                .CustomSqlType("DATETIME2(0)")
                .Not.Nullable();

            HasOne(x => x.ModifiedBy);

            Map(x => x.IsActive)
                .Column("IsActive")
                .CustomSqlType("BIT")
                .Index("Service_IsActive")
                .Not.Nullable();

            Map(x => x.IsDeleted)
                .Column("IsDeleted")
                .CustomSqlType("BIT")
                .Index("Service_IsDeleted")
                .Not.Nullable();
        }
    }
}