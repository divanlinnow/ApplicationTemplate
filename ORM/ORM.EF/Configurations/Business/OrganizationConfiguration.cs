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
    internal class OrganizationConfiguration : EntityTypeConfiguration<Organization>, IEntityConfiguration
    {
        public OrganizationConfiguration()
        {
            ToTable("Organizations");

            HasKey(x => x.ID);

            Property(p => p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0)
                .HasColumnName("ID")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            Property(p => p.RegisteredName)
                .HasColumnOrder(1)
                .HasColumnName("RegisteredName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.PrintName)
                .HasColumnOrder(2)
                .HasColumnName("PrintName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            HasMany(x => x.Branches);

            Property(p => p.Created)
                .HasColumnOrder(4)
                .HasColumnName("Created")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.CreatedBy)
                .WithRequiredPrincipal();

            Property(p => p.Modified)
                .HasColumnOrder(6)
                .HasColumnName("Modified")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.ModifiedBy)
                .WithRequiredPrincipal();

            Property(p => p.IsRegistered)
                .HasColumnOrder(8)
                .HasColumnName("IsRegistered")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Organization_IsRegistered") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.IsActive)
                .HasColumnOrder(9)
                .HasColumnName("IsActive")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Organization_IsActive") { IsClustered = false, IsUnique = false }))
                .IsConcurrencyToken()
                .IsRequired();

            Property(p => p.IsDeleted)
                .HasColumnOrder(10)
                .HasColumnName("IsDeleted")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Organization_IsDeleted") { IsClustered = false, IsUnique = false }))
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}