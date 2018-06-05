using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class WorkflowProcessMap : ClassMap<Workflow>
    {
        public WorkflowProcessMap()
        {
            Table("WorkflowProcesses");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("UNIQUEIDENTIFIER")
                .GeneratedBy.Assigned()
                .Not.Nullable();
        }
    }
}