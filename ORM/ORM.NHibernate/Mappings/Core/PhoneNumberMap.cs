using Domain.Entities.Core;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Core
{
    internal class PhoneNumberMap : ClassMap<PhoneNumber>
    {
        public PhoneNumberMap()
        {
            Table("PhoneNumbers");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("UNIQUEIDENTIFIER")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.Type)
                .Column("Type")
                .CustomSqlType("SMALLINT")
                .Index("PhoneNumber_Type")
                .Not.Nullable();

            Map(x => x.Number)
                .Column("Number")
                .CustomSqlType("VARCHAR(15)")
                .Index("PhoneNumber")
                .Not.Nullable();

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

            Map(x => x.IsActive)
                .Column("IsActive")
                .CustomSqlType("BIT")
                .Not.Nullable();

            Map(x => x.IsDeleted)
                .Column("IsDeleted")
                .CustomSqlType("BIT")
                .Index("PhoneNumber_IsDeleted")
                .Not.Nullable();
        }
    }
}