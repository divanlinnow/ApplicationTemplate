using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class OrganizationDepartmentMap : ClassMap<OrganizationDepartment>
    {
        public OrganizationDepartmentMap()
        {
            Table("OrganizationDepartments");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("UNIQUEIDENTIFIER")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.Name)
                .Column("Name")
                .CustomSqlType("NVARCHAR(50)")
                .Not.Nullable();

            HasOne(x => x.Organization);

            HasOne(x => x.Branch);

            HasMany(x => x.Employees);

            HasOne(x => x.Address);

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
                .Index("OrganizationDepartment_IsActive")
                .Not.Nullable();

            Map(x => x.IsDeleted)
                .Column("IsDeleted")
                .CustomSqlType("BIT")
                .Index("OrganizationDepartment_IsDeleted")
                .Not.Nullable();
        }
    }
}