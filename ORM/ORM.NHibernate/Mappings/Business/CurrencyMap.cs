using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class CurrencyMap : ClassMap<Currency>
    {
        public CurrencyMap()
        {
            Table("Currencies");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("INT")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.ISOCode)
                .Column("ISOCode")
                .CustomSqlType("VARCHAR(3)")
                .Index("Currency_ISOCode")
                .Not.Nullable();

            Map(x => x.Abbreviation)
                .Column("Abbreviation")
                .CustomSqlType("VARCHAR(5)")
                .Index("Currency_Abbreviation")
                .Not.Nullable();

            Map(x => x.Name)
                .Column("Name")
                .CustomSqlType("NVARCHAR(50)")
                .Index("Currency_Name")
                .Not.Nullable();
        }
    }
}