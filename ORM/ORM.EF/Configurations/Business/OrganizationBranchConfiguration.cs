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
    internal class OrganizationBranchConfiguration : EntityTypeConfiguration<OrganizationBranch>, IEntityConfiguration
    {
        public OrganizationBranchConfiguration()
        {
            ToTable("OrganizationBranches");

            HasKey(x => x.ID);
            
            Property(p => p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .IsRequired();

            HasRequired(x => x.Organization)
                .WithRequiredPrincipal();

            HasMany(x => x.Departments);

            Property(p => p.Name)
                .HasColumnOrder(3)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("OrganizationBranch_PrintName") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            HasOptional(x => x.Address);

            Property(p => p.Created)
                .HasColumnOrder(5)
                .HasColumnName("Created")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.CreatedBy)
                .WithRequiredPrincipal();

            Property(p => p.Modified)
                .HasColumnOrder(7)
                .HasColumnName("Modified")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.ModifiedBy)
                .WithRequiredPrincipal();

            Property(p => p.IsDeleted)
                .HasColumnOrder(9)
                .HasColumnName("IsDeleted")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("OrganizationBranch_IsDeleted") { IsClustered = false, IsUnique = false }))
                .IsConcurrencyToken()
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}