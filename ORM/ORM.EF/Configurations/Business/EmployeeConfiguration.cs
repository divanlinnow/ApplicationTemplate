using Domain.Entities.Business;
using ORM.EF.Contexts;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace ORM.EF.Configurations.Business
{
    //[Export(typeof(IEntityConfiguration))]
    //internal class EmployeeConfiguration : EntityTypeConfiguration<Employee>, IEntityConfiguration
    //{
    //    public EmployeeConfiguration()
    //    {
    //        ToTable("Employees");

    //        HasKey(x => new { x.User.ID });

    //        HasRequired(x => x.User)
    //            .WithRequiredPrincipal();

    //        HasRequired(x => x.Organization)
    //            .WithRequiredPrincipal();

    //        HasRequired(x => x.Branch)
    //            .WithRequiredPrincipal();

    //        HasRequired(x => x.Department)
    //           .WithRequiredPrincipal();

    //        HasRequired(x => x.Job)
    //            .WithRequiredPrincipal();
    //    }

    //    public void AddConfiguration(ConfigurationRegistrar registrar)
    //    {
    //        registrar.Add(this);
    //    }
    //}
}