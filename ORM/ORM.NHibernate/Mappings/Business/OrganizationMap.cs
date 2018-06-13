using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class OrganizationMap : ClassMap<Organization>
    {
        public OrganizationMap()
        {
            Table("Organizations");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("UNIQUEIDENTIFIER")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.RegisteredName)
                .Column("RegisteredName")
                .CustomSqlType("NVARCHAR(50)")
                .Not.Nullable();

            Map(x => x.PrintName)
                .Column("PrintName")
                .CustomSqlType("NVARCHAR(50)")
                .Not.Nullable();

            HasMany(x => x.Branches);

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

            Map(x => x.IsRegistered)
                .Column("IsRegistered")
                .CustomSqlType("BIT")
                .Index("Organization_IsRegistered")
                .Not.Nullable();

            Map(x => x.IsActive)
                .Column("IsActive")
                .CustomSqlType("BIT")
                .Index("Organization_IsActive")
                .Not.Nullable();

            Map(x => x.IsDeleted)
                .Column("IsDeleted")
                .CustomSqlType("BIT")
                .Index("Organization_IsDeleted")
                .Not.Nullable();
        }
    }
}