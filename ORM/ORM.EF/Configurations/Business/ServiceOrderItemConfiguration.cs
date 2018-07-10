using Domain.Entities.Business;
using ORM.EF.Contexts;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace ORM.EF.Configurations.Business
{
    [Export(typeof(IEntityConfiguration))]
    internal class ServiceOrderItemConfiguration : EntityTypeConfiguration<ServiceOrderItem>, IEntityConfiguration
    {
        public ServiceOrderItemConfiguration()
        {
            ToTable("ServiceOrderItem");

            HasKey(x => new { x.OrderId, x.ServiceId });

            Property(p => p.OrderId)
                .HasColumnOrder(0)
                .HasColumnName("OrderId")
                .HasColumnType("INT")
                .IsRequired();

            Property(p => p.ServiceId)
                .HasColumnOrder(1)
                .HasColumnName("ServiceId")
                .HasColumnType("INT")
                .IsRequired();

            Property(p => p.Quantity)
                .HasColumnOrder(2)
                .HasColumnName("Quantity")
                .HasColumnType("DECIMAL")
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}