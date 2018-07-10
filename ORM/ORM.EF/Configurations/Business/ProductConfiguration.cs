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
    internal class ProductConfiguration : EntityTypeConfiguration<Product>, IEntityConfiguration
    {
        public ProductConfiguration()
        {
            ToTable("Products");

            HasKey(x => x.ID);

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

            Property(p => p.Make)
                .HasColumnOrder(2)
                .HasColumnName("Make")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Model)
                .HasColumnOrder(3)
                .HasColumnName("Model")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Year)
                .HasColumnOrder(4)
                .HasColumnName("Year")
                .HasColumnType("INT")
                .IsRequired();

            Property(p => p.Description)
                .HasColumnOrder(5)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(1000)
                .IsRequired();

            Property(p => p.MinimumOrderQuantity)
                .HasColumnOrder(6)
                .HasColumnName("MinimumOrderQuantity")
                .HasColumnType("DECIMAL")
                .IsRequired();

            Property(p => p.PriceEXCL)
                .HasColumnOrder(7)
                .HasColumnName("PriceEXCL")
                .HasColumnType("DECIMAL")
                .IsRequired();

            Property(p => p.PriceINCL)
                .HasColumnOrder(8)
                .HasColumnName("PriceINCL")
                .HasColumnType("DECIMAL")
                .IsRequired();

            Property(p => p.PriceMustChange)
                .HasColumnOrder(9)
                .HasColumnName("PriceMustChange")
                .HasColumnType("BIT")
                .IsRequired();

            Property(p => p.PriceExpiryDate)
                .HasColumnOrder(10)
                .HasColumnName("PriceExpiryDate")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            Property(p => p.HasExpiryDate)
                .HasColumnOrder(11)
                .HasColumnName("HasExpiryDate")
                .HasColumnType("BIT")
                .IsRequired();

            Property(p => p.ExpiryDate)
                .HasColumnOrder(12)
                .HasColumnName("ExpiryDate")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsOptional();

            //HasOptional(x => x.Supplier)
            //    .WithMany()
            //    .HasForeignKey(x => x.Supplier.Id); ;

            Property(p => p.Created)
                .HasColumnOrder(14)
                .HasColumnName("Created")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.CreatedBy)
               .WithRequiredPrincipal();

            Property(p => p.Modified)
                .HasColumnOrder(16)
                .HasColumnName("Modified")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.ModifiedBy)
                .WithRequiredPrincipal();

            Property(p => p.IsActive)
                .HasColumnOrder(18)
                .HasColumnName("IsActive")
                .HasColumnType("BIT")
                .IsConcurrencyToken()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Product_IsActive") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.IsDeleted)
                .HasColumnOrder(19)
                .HasColumnName("IsDeleted")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Product_IsDeleted") { IsClustered = false, IsUnique = false }))
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}