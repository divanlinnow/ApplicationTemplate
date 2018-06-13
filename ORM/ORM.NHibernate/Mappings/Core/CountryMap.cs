using Domain.Entities.Core;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Core
{
    internal class CountryMap : ClassMap<Country>
    {
        public CountryMap()
        {
            Table("Countries");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("UNIQUEIDENTIFIER")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.ISOCode)
                .Column("ISOCode")
                .CustomSqlType("VARCHAR(3)")
                .Index("Country_ISOCode")
                .Not.Nullable();

            Map(x => x.Abbreviation)
                .Column("Abbreviation")
                .CustomSqlType("VARCHAR(5)")
                .Index("Country_Abbreviation")
                .Not.Nullable();

            Map(x => x.Name)
                .Column("Name")
                .CustomSqlType("NVARCHAR(55)")
                .Index("Country_Name")
                .Not.Nullable();
        }
    }
}