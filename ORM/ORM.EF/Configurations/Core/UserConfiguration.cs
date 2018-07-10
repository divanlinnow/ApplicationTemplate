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
    internal class UserConfiguration : EntityTypeConfiguration<User>, IEntityConfiguration
    {
        public UserConfiguration()
        {
            ToTable("Users");

            HasKey(x => x.ID);

            Property(p => p.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .IsRequired();

            Property(p => p.Prefix)
                .HasColumnOrder(1)
                .HasColumnName("Prefix")
                .HasColumnType("INT")
                .IsOptional();

            Property(p => p.FirstName)
                .HasColumnOrder(2)
                .HasColumnName("FirstName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.LastName)
                .HasColumnOrder(3)
                .HasColumnName("LastName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Suffix)
                .HasColumnOrder(4)
                .HasColumnName("Suffix")
                .HasColumnType("INT")
                .IsOptional();

            Property(p => p.UserName)
                .HasColumnOrder(5)
                .HasColumnName("UserName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("User_UserName") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.Password)
                .HasColumnOrder(6)
                .HasColumnName("Password")
                .HasColumnType("VARCHAR")
                .HasMaxLength(500)
                .IsRequired();

            Property(p => p.Salt)
                .HasColumnOrder(7)
                .HasColumnName("Salt")
                .HasColumnType("VARCHAR")
                .HasMaxLength(500)
                .IsRequired();

            Property(p => p.Type)
                .HasColumnOrder(8)
                .HasColumnName("Type")
                .HasColumnType("INT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("User_Type") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.Status)
                .HasColumnOrder(9)
                .HasColumnName("Status")
                .HasColumnType("INT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("User_Status") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.Gender)
                .HasColumnOrder(10)
                .HasColumnName("Gender")
                .HasColumnType("INT")
                .IsRequired();

            HasRequired(x => x.Language)
                .WithRequiredPrincipal();

            HasMany(x => x.Roles);

            HasMany(x => x.Emails);

            HasMany(x => x.PhoneNumbers);

            HasMany(x => x.Addresses);

            Property(p => p.BloodType)
                .HasColumnOrder(16)
                .HasColumnName("BloodType")
                .HasColumnType("INT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("User_BloodType") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.FoodPreferenceType)
                .HasColumnOrder(17)
                .HasColumnName("FoodPreferenceType")
                .HasColumnType("INT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("User_FoodPreferenceType") { IsClustered = false, IsUnique = false }))
                .IsRequired();

            Property(p => p.DateOfBirth)
                .HasColumnOrder(18)
                .HasColumnName("DateOfBirth")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            Property(p => p.Created)
                .HasColumnOrder(19)
                .HasColumnName("Created")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.CreatedBy)
                .WithRequiredPrincipal();

            Property(p => p.Modified)
                .HasColumnOrder(21)
                .HasColumnName("Modified")
                .HasColumnType("DATETIME2")
                .HasPrecision(0)
                .IsRequired();

            HasRequired(x => x.ModifiedBy)
                .WithRequiredPrincipal();

            Property(p => p.IsConfirmed)
                .HasColumnOrder(23)
                .HasColumnName("IsConfirmed")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("User_IsConfirmed") { IsClustered = false, IsUnique = false }))
                .IsConcurrencyToken()
                .IsRequired();

            Property(p => p.IsDeleted)
                .HasColumnOrder(24)
                .HasColumnName("IsDeleted")
                .HasColumnType("BIT")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("User_IsDeleted") { IsClustered = false, IsUnique = false }))
                .IsConcurrencyToken()
                .IsRequired();
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}