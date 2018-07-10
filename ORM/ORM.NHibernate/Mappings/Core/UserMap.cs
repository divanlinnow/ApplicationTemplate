using Domain.Entities.Core;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Core
{
    internal class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("INT")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.Prefix)
                .Column("Prefix")
                .CustomSqlType("SMALLINT")
                .Nullable();

            Map(x => x.FirstName)
                .Column("FirstName")
                .CustomSqlType("NVARCHAR(50)")
                .Not.Nullable();

            Map(x => x.LastName)
                .Column("LastName")
                .CustomSqlType("NVARCHAR(50)")
                .Not.Nullable();

            Map(x => x.Suffix)
                .Column("Suffix")
                .CustomSqlType("SMALLINT")
               .Nullable();

            Map(x => x.UserName)
                .Column("UserName")
                .CustomSqlType("NVARCHAR(50)")
                .Index("User_UserName")
                .Not.Nullable();

            Map(x => x.Password)
                .Column("Password")
                .CustomSqlType("VARCHAR(500)")
                .Not.Nullable();

            Map(x => x.Salt)
                .Column("Salt")
                .CustomSqlType("VARCHAR(500)")
                .Not.Nullable();

            Map(x => x.Type)
                .Column("Type")
                .CustomSqlType("SMALLINT")
                .Index("User_Type")
                .Not.Nullable();

            Map(x => x.Status)
                .Column("Status")
                .CustomSqlType("SMALLINT")
                .Index("User_Status")
                .Not.Nullable();

            Map(x => x.Gender)
                .Column("Gender")
                .CustomSqlType("SMALLINT")
                .Not.Nullable();

            HasOne(x => x.Language);

            HasMany(x => x.Roles);

            HasMany(x => x.Emails);

            HasMany(x => x.PhoneNumbers);

            HasMany(x => x.Addresses);

            Map(x => x.BloodType)
                .Column("BloodType")
                .CustomSqlType("SMALLINT")
                .Index("User_BloodType")
                .Nullable();

            Map(x => x.FoodPreferenceType)
                .Column("FoodPreferenceType")
                .CustomSqlType("SMALLINT")
                .Index("User_FoodPreferenceType")
                .Nullable();

            Map(x => x.DateOfBirth)
                .Column("DateOfBirth")
                .CustomSqlType("DATETIME2(0)")
                .Not.Nullable();

            Map(x => x.Created)
               .Column("Created")
               .CustomSqlType("DATETIME2(0)")
               .Not.Nullable();

            HasOne(x => x.CreatedBy);

            Map(x => x.Modified)
                .Column("Modified")
                .CustomSqlType("DATETIME2(0)")
                .Not.Nullable();

            HasOne(x => x.ModifiedBy);

            Map(x => x.IsConfirmed)
                .Column("IsConfirmed")
                .CustomSqlType("BIT")
                .Index("User_IsConfirmed")
                .Not.Nullable();

            Map(x => x.IsDeleted)
                .Column("IsDeleted")
                .CustomSqlType("BIT")
                .Index("User_IsDeleted")
                .Not.Nullable();
        }
    }
}