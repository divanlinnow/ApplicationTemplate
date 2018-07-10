using Domain.Entities.Core;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Core
{
    internal class PermissionMap : ClassMap<Permission>
    {
        public PermissionMap()
        {
            Table("Permissions");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("INT")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.Name)
                .Column("Name")
                .CustomSqlType("NVARCHAR(50)")
                .Index("Permission_Name")
                .Not.Nullable();

            Map(x => x.IsActive)
                .Column("IsActive")
                .CustomSqlType("BIT")
                .Index("Permission_IsActive")
                .Not.Nullable();

            Map(x => x.IsDeleted)
                .Column("IsDeleted")
                .CustomSqlType("BIT")
                .Index("Permission_IsDeleted")
                .Not.Nullable();
        }
    }
}