using Domain.Entities.Core;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Core
{
    internal class EmailMap : ClassMap<Email>
    {
        public EmailMap()
        {
            Table("EmailAddresses");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("UNIQUEIDENTIFIER")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.Type)
                .Column("Type")
                .CustomSqlType("SMALLINT")
                .Index("Email_Type")
                .Not.Nullable();

            Map(x => x.AccountType)
                .Column("AccountType")
                .CustomSqlType("SMALLINT")
                .Index("Email_AccountType")
                .Not.Nullable();

            Map(x => x.EmailAddress)
                .Column("EmailAddress")
                .CustomSqlType("NVARCHAR(320)")
                .Index("EmailAddress")
                .Not.Nullable();

            Map(x => x.IncomingMailServer)
                .Column("IncomingMailServer")
                .CustomSqlType("NVARCHAR(100)")
                .Not.Nullable();

            Map(x => x.OutgoingMailServer)
                .Column("OutgoingMailServer")
                .CustomSqlType("NVARCHAR(100)")
                .Not.Nullable();

            Map(x => x.IncomingMailServerPort)
                .Column("IncomingMailServerPort")
                .CustomSqlType("SMALLINT")
                .Not.Nullable();

            Map(x => x.OutgoingMailServerPort)
                .Column("OutgoingMailServerPort")
                .CustomSqlType("SMALLINT")
                .Not.Nullable();

            Map(x => x.IncomingServerUseSSL)
                .Column("IncomingServerUseSSL")
                .CustomSqlType("BIT")
                .Not.Nullable();

            Map(x => x.OutgoingServerUseSSL)
                .Column("OutgoingServerUseSSL")
                .CustomSqlType("BIT")
                .Not.Nullable();

            Map(x => x.PriorityOrder)
                .Column("PriorityOrder")
                .CustomSqlType("SMALLINT")
                .Nullable();

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

            Map(x => x.IsDeleted)
                .Column("IsDeleted")
                .CustomSqlType("BIT")
                .Index("Email_IsDeleted")
                .Not.Nullable();
        }
    }
}