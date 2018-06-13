using Domain.Entities.Core;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Core
{
    internal class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("Addresses");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("UNIQUEIDENTIFIER")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.Type)
                .Column("Type")
                .CustomSqlType("SMALLINT")
                .Index("Address_Type")
                .Not.Nullable();

            Map(x => x.AddressLine1)
                .Column("AddressLine1")
                .CustomSqlType("NVARCHAR(100)")
                .Not.Nullable();

            Map(x => x.AddressLine2)
                .Column("AddressLine2")
                .CustomSqlType("NVARCHAR(100)")
                .Nullable();

            Map(x => x.AddressLine3)
                .Column("AddressLine3")
                .CustomSqlType("NVARCHAR(100)")
                .Nullable();

            Map(x => x.Suburb)
                .Column("Suburb")
                .CustomSqlType("NVARCHAR(100)")
                .Nullable();

            HasOne(x => x.City);

            HasOne(x => x.Province);

            HasOne(x => x.Country);

            Map(x => x.PostalCode)
                .Column("PostalCode")
                .CustomSqlType("NVARCHAR(20)")
                .Nullable();

            Map(x => x.Longitude)
                .Column("Longitude")
                .CustomSqlType("DECIMAL(9,3)")
                .Nullable();

            Map(x => x.Latitude)
                .Column("Latitude")
                .CustomSqlType("DECIMAL(9,3)")
                .Nullable();

            Map(x => x.PriorityOrder)
                .Column("PriorityOrder")
                .CustomSqlType("SMALLINT")
                .Nullable();

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

            Map(x => x.IsDeleted)
                .Column("IsDeleted")
                .CustomSqlType("BIT")
                .Index("Address_IsDeleted")
                .Not.Nullable();
        }
    }
}