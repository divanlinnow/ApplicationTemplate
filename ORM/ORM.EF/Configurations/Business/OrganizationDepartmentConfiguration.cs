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
    internal class OrganizationDepartmentConfiguration : EntityTypeConfiguration<OrganizationDepartment>, IEntityConfiguration
    {
        public OrganizationDepartmentConfiguration()
        {
            ToTable("OrganizationDepartments");

            HasKey(x => x.ID);

            HasRequired(x => x.Organization)
                 .WithRequiredPrincipal();

            HasRequired(x => x.Branch)
                .WithRequiredPrincipal();

            HasMany(x => x.Employees);

            HasOptional(x => x.Address);

            HasRequired(x => x.CreatedBy)
               .WithRequiredPrincipal();

            HasRequired(x => x.ModifiedBy)
                .WithRequiredPrincipal();

            Property(p => p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .IsRequired();

            Property(p => p.Name)
                .HasColumnOrder(1)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Created)
                .HasColumnOrder(6)
                .HasColumnName("Created")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            Property(p => p.Modified)
                .HasColumnOrder(8)
                .HasColumnName("Modified")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            Property(p => p.IsActive)
                .HasColumnName("IsActive")
                .HasColumnOrder(10)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("OrganizationDepartment_IsActive") { IsClustered = false, IsUnique = false }))
                .HasColumnType("BIT")
                .IsConcurrencyToken()
                .IsRequired();

            Property(p => p.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnOrder(11)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("OrganizationDepartment_IsDeleted") { IsClustered = false, IsUnique = false }))
                .HasColumnType("BIT")
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}