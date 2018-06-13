using Domain.Entities.Business;
using ORM.EF.Contexts;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace ORM.EF.Configurations.Business
{
    [Export(typeof(IEntityConfiguration))]
    internal class WorkflowProcessConfiguration : EntityTypeConfiguration<Workflow>, IEntityConfiguration
    {
        public WorkflowProcessConfiguration()
        {
            ToTable("WorkflowProcesses");

            HasKey(x => x.ID);

            Property(p => p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0)
                .HasColumnName("ID")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}