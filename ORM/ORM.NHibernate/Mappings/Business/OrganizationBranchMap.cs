using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class OrganizationBranchMap : ClassMap<OrganizationBranch>
    {
        public OrganizationBranchMap()
        {
            Table("OrganizationBranches");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("INT")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            HasOne(x => x.Organization);

            HasMany(x => x.Departments);

            Map(x => x.Name)
                .Column("Name");

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
            
            Map(x => x.IsDeleted)
                .Column("IsDeleted")
                .CustomSqlType("BIT")
                .Index("OrganizationBranch_IsDeleted")
                .Not.Nullable();
        }
    }
}