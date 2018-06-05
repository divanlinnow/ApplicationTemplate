using Domain.Entities.Core;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Core
{
    internal class NotificationTemplateMap : ClassMap<NotificationTemplate>
    {
        public NotificationTemplateMap()
        {
            Table("NotificationTemplates");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("UNIQUEIDENTIFIER")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.Name)
                .Column("Name")
                .CustomSqlType("NVARCHAR(50)")
                .Not.Nullable();

            Map(x => x.SubjectHeader)
                .Column("SubjectHeader")
                .CustomSqlType("NVARCHAR(50)")
                .Nullable();

            Map(x => x.Body)
                .Column("SubjectHeader")
                .CustomSqlType("NVARCHAR(1000)")
                .Not.Nullable();

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
                .Index("NotificationTemplate_IsActive")
                .Not.Nullable();

            Map(x => x.IsDeleted)
                .Column("IsDeleted")
                .CustomSqlType("BIT")
                .Index("NotificationTemplate_IsDeleted")
                .Not.Nullable();
        }
    }
}