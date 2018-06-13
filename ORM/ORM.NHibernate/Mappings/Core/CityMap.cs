using Domain.Entities.Core;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Core
{
    internal class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Table("Cities");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("UNIQUEIDENTIFIER")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.ISOCode)
                .Column("ISOCode")
                .CustomSqlType("VARCHAR(3)")
                .Index("City_ISOCode")
                .Not.Nullable();

            Map(x => x.Abbreviation)
                .Column("Abbreviation")
                .CustomSqlType("VARCHAR(5)")
                .Index("City_Abbreviation")
                .Not.Nullable();

            Map(x => x.Name)
                .Column("Name")
                .CustomSqlType("NVARCHAR(50)")
                .Index("City_Name")
                .Not.Nullable();

            HasOne(x => x.Province);

            HasOne(x => x.Country);
        }
    }
}