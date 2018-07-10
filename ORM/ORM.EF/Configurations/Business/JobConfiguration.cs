using Domain.Entities.Business;
using ORM.EF.Contexts;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace ORM.EF.Configurations.Business
{
    [Export(typeof(IEntityConfiguration))]
    internal class JobConfiguration : EntityTypeConfiguration<Job>, IEntityConfiguration
    {
        public JobConfiguration()
        {
            ToTable("Jobs");

            HasKey(x => x.ID);
            
            Property(p => p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .IsRequired();

            HasRequired(x => x.Organization)
                .WithRequiredPrincipal();

            HasRequired(x => x.Branch)
                .WithRequiredPrincipal();

            HasRequired(x => x.Department)
               .WithRequiredPrincipal();

            Property(p => p.Title)
                .HasColumnOrder(4)
                .HasColumnName("Title")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            HasRequired(x => x.Role)
                .WithRequiredPrincipal();

            Property(p => p.Created)
                .HasColumnOrder(6)
                .HasColumnName("Created")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.CreatedBy)
                .WithRequiredPrincipal();

            Property(p => p.Modified)
                .HasColumnOrder(8)
                .HasColumnName("Modified")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.ModifiedBy)
                .WithRequiredPrincipal();

            Property(p => p.IsActive)
                .HasColumnOrder(10)
                .HasColumnName("IsActive")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Job_IsActive") { IsClustered = false, IsUnique = false }))
                .IsConcurrencyToken()
                .IsRequired();

            Property(p => p.IsDeleted)
                .HasColumnOrder(11)
                .HasColumnName("IsDeleted")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Job_IsDeleted") { IsClustered = false, IsUnique = false }))
                .IsConcurrencyToken()
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}