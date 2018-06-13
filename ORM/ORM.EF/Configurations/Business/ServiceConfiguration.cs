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
    internal class ServiceConfiguration : EntityTypeConfiguration<Service>, IEntityConfiguration
    {
        public ServiceConfiguration()
        {
            ToTable("Services");

            HasKey(x => x.ID);

            Property(p => p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0)
                .HasColumnName("ID")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            Property(p => p.Name)
                .HasColumnOrder(1)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Description)
                .HasColumnOrder(2)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(1000)
                .IsRequired();

            Property(p => p.MinimumOrderQuantity)
                .HasColumnOrder(3)
                .HasColumnName("MinimumOrderQuantity")
                .HasColumnType("DECIMAL")
                .IsRequired();

            Property(p => p.PriceEXCL)
                .HasColumnOrder(4)
                .HasColumnName("PriceEXCL")
                .HasColumnType("DECIMAL")
                .IsRequired();

            Property(p => p.PriceINCL)
                .HasColumnOrder(5)
                .HasColumnName("PriceINCL")
                .HasColumnType("DECIMAL")
                .IsRequired();

            Property(p => p.PriceMustChange)
                .HasColumnOrder(6)
                .HasColumnName("PriceMustChange")
                .HasColumnType("BIT")
                .IsRequired();

            Property(p => p.PriceExpiryDate)
                .HasColumnOrder(7)
                .HasColumnName("PriceExpiryDate")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            Property(p => p.HasExpiryDate)
                .HasColumnOrder(8)
                .HasColumnName("HasExpiryDate")
                .HasColumnType("BIT")
                .IsRequired();

            Property(p => p.ExpiryDate)
                .HasColumnOrder(9)
                .HasColumnName("ExpiryDate")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsOptional();

            //HasOptional(x => x.Supplier)
            //    .WithMany()
            //    .HasForeignKey(x => x.Supplier.Id); ;

            Property(p => p.Created)
                .HasColumnOrder(10)
                .HasColumnName("Created")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.CreatedBy)
               .WithRequiredPrincipal();

            Property(p => p.Modified)
                .HasColumnOrder(12)
                .HasColumnName("Modified")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.ModifiedBy)
                .WithRequiredPrincipal();

            Property(p => p.IsActive)
                .HasColumnName("IsActive")
                .HasColumnOrder(13)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Service_IsActive") { IsClustered = false, IsUnique = false }))
                .HasColumnType("BIT")
                .IsConcurrencyToken()
                .IsRequired();

            Property(p => p.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnOrder(14)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Service_IsDeleted") { IsClustered = false, IsUnique = false }))
                .HasColumnType("BIT")
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}