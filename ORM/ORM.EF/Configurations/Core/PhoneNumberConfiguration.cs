using Domain.Entities.Core;
using ORM.EF.Contexts;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace ORM.EF.Configurations.Core
{
    [Export(typeof(IEntityConfiguration))]
    internal class PhoneNumberConfiguration : EntityTypeConfiguration<PhoneNumber>, IEntityConfiguration
    {
        public PhoneNumberConfiguration()
        {
            ToTable("PhoneNumbers");

            HasKey(x => x.ID);

            Property(p => p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .IsRequired();

            Property(p => p.Type)
                .HasColumnOrder(1)
                .HasColumnName("Type")
                .HasColumnType("INT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("PhoneNumber_Type") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.Number)
                .HasColumnOrder(2)
                .HasColumnName("Number")
                .HasColumnType("VARCHAR")
                .HasMaxLength(15)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("PhoneNumber") { IsClustered = false, IsUnique = false }))
                .IsOptional();

            Property(p => p.PriorityOrder)
                .HasColumnOrder(3)
                .HasColumnName("PriorityOrder")
                .HasColumnType("SMALLINT")
                .IsOptional();

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

            Property(p => p.IsDeleted)
                .HasColumnOrder(8)
                .HasColumnName("IsDeleted")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("PhoneNumber_IsDeleted") { IsClustered = false, IsUnique = false }))
                .IsConcurrencyToken()
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}