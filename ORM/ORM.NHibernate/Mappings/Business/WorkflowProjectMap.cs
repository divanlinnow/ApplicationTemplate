using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class WorkflowProjectMap : ClassMap<WorkflowProject>
    {
        public WorkflowProjectMap()
        {
            Table("WorkflowProjects");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("UNIQUEIDENTIFIER")
                .GeneratedBy.Assigned()
                .Not.Nullable();
        }
    }
}