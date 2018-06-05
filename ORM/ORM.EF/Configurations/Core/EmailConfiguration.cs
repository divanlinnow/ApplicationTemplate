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
    internal class EmailConfiguration : EntityTypeConfiguration<Email>, IEntityConfiguration
    {
        public EmailConfiguration()
        {
            ToTable("EmailAddresses");

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
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Email_Type") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.AccountType)
                .HasColumnOrder(2)
                .HasColumnName("AccountType")
                .HasColumnType("INT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Email_AccountType") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.EmailAddress)
                .HasColumnOrder(3)
                .HasColumnName("EmailAddress")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(320)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("EmailAddress") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.IncomingMailServer)
                .HasColumnOrder(4)
                .HasColumnName("IncomingMailServer")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.OutgoingMailServer)
                .HasColumnOrder(5)
                .HasColumnName("OutgoingMailServer")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.IncomingMailServerPort)
                .HasColumnOrder(6)
                .HasColumnName("IncomingMailServerPort")
                .HasColumnType("INT")
                .IsRequired();

            Property(p => p.OutgoingMailServerPort)
                .HasColumnOrder(7)
                .HasColumnName("OutgoingMailServerPort")
                .HasColumnType("INT")
                .IsRequired();

            Property(p => p.IncomingServerUseSSL)
                .HasColumnOrder(8)
                .HasColumnName("IncomingServerUseSSL")
                .HasColumnType("BIT")
                .IsRequired();

            Property(p => p.OutgoingServerUseSSL)
                .HasColumnOrder(9)
                .HasColumnName("OutgoingServerUseSSL")
                .HasColumnType("BIT")
                .IsRequired();

            Property(p => p.PriorityOrder)
                .HasColumnOrder(10)
                .HasColumnName("PriorityOrder")
                .HasColumnType("SMALLINT")
                .IsOptional();

            Property(p => p.Created)
                .HasColumnOrder(11)
                .HasColumnName("Created")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.CreatedBy)
                .WithRequiredPrincipal();

            Property(p => p.Modified)
                .HasColumnOrder(13)
                .HasColumnName("Modified")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.ModifiedBy)
                .WithRequiredPrincipal();

            Property(p => p.IsDeleted)
                .HasColumnOrder(15)
                .HasColumnName("IsDeleted")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Email_IsDeleted") { IsClustered = false, IsUnique = false }))
                .IsConcurrencyToken()
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}