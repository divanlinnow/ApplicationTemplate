using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class TaskStatusMap : ClassMap<TaskStatus>
    {
        public TaskStatusMap()
        {
            Table("TaskStatuses");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("UNIQUEIDENTIFIER")
                .GeneratedBy.Assigned()
                .Not.Nullable();
        }
    }
}