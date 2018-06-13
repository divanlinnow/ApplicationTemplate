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
    internal class AddressConfiguration : EntityTypeConfiguration<Address>, IEntityConfiguration
    {
        public AddressConfiguration()
        {
            ToTable("Addresses");

            HasKey(x => x.ID);

            Property(p => p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0)
                .HasColumnName("ID")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            Property(p => p.Type)
                .HasColumnOrder(1)
                .HasColumnName("Type")
                .HasColumnType("INT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Address_Type") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.AddressLine1)
                .HasColumnOrder(2)
                .HasColumnName("AddressLine1")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.AddressLine2)
                .HasColumnOrder(3)
                .HasColumnName("AddressLine2")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.AddressLine3)
                .HasColumnOrder(4)
                .HasColumnName("AddressLine3")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.Suburb)
                .HasColumnOrder(5)
                .HasColumnName("Suburb")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsOptional();

            HasRequired(x => x.City)
                .WithRequiredPrincipal();

            //HasRequired(x => x.Province)
            //    .WithRequiredPrincipal();

            //HasRequired(x => x.Country)
            //    .WithRequiredPrincipal();

            Property(p => p.PostalCode)
                .HasColumnOrder(9)
                .HasColumnName("PostalCode")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20)
                .IsOptional();

            Property(p => p.Latitude)
                .HasColumnOrder(10)
                .HasColumnName("Latitude")
                .HasColumnType("DECIMAL")
                .HasPrecision(9, 3)
                .IsOptional();

            Property(p => p.Longitude)
                .HasColumnOrder(11)
                .HasColumnName("Longitude")
                .HasColumnType("DECIMAL")
                .HasPrecision(9, 3)
                .IsOptional();

            Property(p => p.PriorityOrder)
                .HasColumnOrder(12)
                .HasColumnName("PriorityOrder")
                .HasColumnType("SMALLINT")
                .IsOptional();

            Property(p => p.Created)
                .HasColumnOrder(13)
                .HasColumnName("Created")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.CreatedBy)
                .WithRequiredPrincipal();

            Property(p => p.Modified)
                .HasColumnOrder(15)
                .HasColumnName("Modified")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.ModifiedBy)
                .WithRequiredPrincipal();

            Property(p => p.IsDeleted)
                .HasColumnOrder(17)
                .HasColumnName("IsDeleted")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Address_IsDeleted") { IsClustered = false, IsUnique = false }))
                .IsConcurrencyToken()
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}