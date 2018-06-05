using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("Employees");

            HasOne(x => x.User);

            HasOne(x => x.Organization);

            HasOne(x => x.Branch);

            HasOne(x => x.Department);

            HasOne(x => x.Job);
        }
    }
}