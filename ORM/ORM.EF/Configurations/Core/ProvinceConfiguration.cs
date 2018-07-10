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
    internal class ProvinceConfiguration : EntityTypeConfiguration<Province>, IEntityConfiguration
    {
        public ProvinceConfiguration()
        {
            ToTable("Provinces");

            HasKey(x => x.ID);

            HasRequired(x => x.Country);

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
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Province_ISOCode") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.Abbreviation)
                .HasColumnOrder(2)
                .HasColumnName("Abbreviation")
                .HasColumnType("VARCHAR")
                .HasMaxLength(5)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Province_Abbreviation") { IsClustered = false, IsUnique = false }))
                .IsOptional();

            Property(p => p.Name)
                .HasColumnOrder(3)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Province_Name") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            HasRequired(x => x.Country)
                .WithMany(p => p.Provinces)
                .WillCascadeOnDelete(false); 

            HasMany(p => p.Cities)
                .WithRequired(p => p.Province);

        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}