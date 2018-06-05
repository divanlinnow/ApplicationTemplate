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
    internal class OrderConfiguration : EntityTypeConfiguration<Order>, IEntityConfiguration
    {
        public OrderConfiguration()
        {
            ToTable("Orders");

            HasKey(x => x.ID);

            Property(p => p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0)
                .HasColumnName("ID")
                .HasColumnType("UNIQUEIDENTIFIER")
                .IsRequired();

            HasRequired(x => x.Customer)
                .WithRequiredPrincipal();

            Property(p => p.PlacementDate)
                .HasColumnOrder(2)
                .HasColumnName("PlacementDate")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Order_PlacementDate") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            //HasOptional(x => x.Products);

            //HasOptional(x => x.Services);
            
            Property(p => p.TrackingNumber)
                .HasColumnOrder(5)
                .HasColumnName("TrackingNumber")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Order_TrackingNumber") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            HasOptional(x => x.DeliveryAddress);

            HasOptional(x => x.CollectionAddress);

            Property(p => p.Created)
                .HasColumnOrder(8)
                .HasColumnName("Created")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.CreatedBy)
                .WithRequiredPrincipal();

            Property(p => p.Modified)
                .HasColumnOrder(10)
                .HasColumnName("Modified")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.ModifiedBy)
                .WithRequiredPrincipal();

            Property(p => p.IsForCollection)
                .HasColumnOrder(12)
                .HasColumnName("IsForCollection")
                .HasColumnType("BIT")
                .IsRequired();

            Property(p => p.IsForDelivery)
                .HasColumnOrder(13)
                .HasColumnName("IsForDelivery")
                .HasColumnType("BIT")
                .IsRequired();

            Property(p => p.IsQuote)
                .HasColumnOrder(14)
                .HasColumnName("IsQuote")
                .HasColumnType("BIT")
                .IsConcurrencyToken()
                .IsRequired();

            Property(p => p.IsCancelled)
                .HasColumnOrder(15)
                .HasColumnName("IsCancelled")
                .HasColumnType("BIT")
                .IsConcurrencyToken()
                .IsRequired();

            Property(p => p.IsActive)
                .HasColumnOrder(16)
                .HasColumnName("IsActive")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Order_IsActive") { IsClustered = false, IsUnique = false }))
                .HasColumnType("BIT")
                .IsRequired();

            Property(p => p.IsDeleted)
                .HasColumnOrder(17)
                .HasColumnName("IsDeleted")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Order_IsDeleted") { IsClustered = false, IsUnique = false }))
                .IsConcurrencyToken()
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}