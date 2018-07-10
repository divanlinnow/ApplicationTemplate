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
    internal class CityConfiguration : EntityTypeConfiguration<City>, IEntityConfiguration
    {
        public CityConfiguration()
        {
            ToTable("Cities");

            HasKey(x => x.ID);

            Property(p => p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .IsRequired();

            Property(p => p.ISOCode)
                .HasColumnOrder(1)
                .HasColumnName("ISOCode")
                .HasColumnType("VARCHAR")
                .HasMaxLength(3)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("City_ISOCode") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.Abbreviation)
                .HasColumnOrder(2)
                .HasColumnName("Abbreviation")
                .HasColumnType("VARCHAR")
                .HasMaxLength(5)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("City_Abbreviation") { IsClustered = false, IsUnique = false }))
                .IsOptional();

            Property(p => p.Name)
                .HasColumnOrder(3)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("City_Name") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            HasRequired(p => p.Province)
                .WithMany(p => p.Cities)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Country)
                .WithMany();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}