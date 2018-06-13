using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class JobMap : ClassMap<Job>
    {
        public JobMap()
        {
            Table("Jobs");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("UNIQUEIDENTIFIER")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            HasOne(x => x.Organization);

            HasOne(x => x.Branch);

            HasOne(x => x.Department);

            Map(x => x.Title)
                .Column("Title")
                .CustomSqlType("NVARCHAR(50)")
                .Not.Nullable();

            HasOne(x => x.Role);

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
                .Index("Job_IsActive")
                .Not.Nullable();

            Map(x => x.IsDeleted)
                .Column("IsDeleted")
                .CustomSqlType("BIT")
                .Index("Job_IsDeleted")
                .Not.Nullable();
        }
    }
}