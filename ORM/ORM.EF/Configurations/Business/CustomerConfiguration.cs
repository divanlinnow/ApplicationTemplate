using Domain.Entities.Business;
using ORM.EF.Contexts;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace ORM.EF.Configurations.Business
{
    [Export(typeof(IEntityConfiguration))]
    internal class CustomerConfiguration : EntityTypeConfiguration<Customer>, IEntityConfiguration
    {
        public CustomerConfiguration()
        {
            ToTable("Customers");

            HasKey(x => x.ID);
            
            Property(p => p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .IsRequired();

            HasRequired(x => x.User)
                 .WithRequiredPrincipal();

            //HasMany(x => x.Orders)
            //    .WithRequired(x => x.Customer)
            //    .HasForeignKey(x => x.Id);

            Property(p => p.CreditBlocked)
                .HasColumnOrder(3)
                .HasColumnName("CreditBlocked")
                .HasColumnType("BIT")
                .IsRequired();

            Property(p => p.CreditLimit)
                .HasColumnOrder(4)
                .HasColumnName("CreditLimit")
                .HasColumnType("DECIMAL")
                .IsRequired();

            Property(p => p.AllowancePeriod_Days)
                .HasColumnOrder(5)
                .HasColumnName("AllowancePeriod_Days")
                .HasColumnType("SMALLINT")
                .IsRequired();

            Property(p => p.AllowancePeriod_Months)
                .HasColumnOrder(6)
                .HasColumnName("AllowancePeriod_Months")
                .HasColumnType("SMALLINT")
                .IsRequired();

            Property(p => p.IsPreferredCustomer)
                .HasColumnOrder(7)
                .HasColumnName("IsPreferredCustomer")
                .HasColumnType("BIT")
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}