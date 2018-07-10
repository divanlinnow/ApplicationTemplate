using Domain.Entities.Core;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Core
{
    internal class ProvinceMap : ClassMap<Province>
    {
        public ProvinceMap()
        {
            Table("Provinces");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("INT")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            HasOne(x => x.Country);

            Map(x => x.ISOCode)
                .Column("ISOCode")
                .CustomSqlType("VARCHAR(3)")
                .Index("Province_ISOCode")
                .Not.Nullable();

            Map(x => x.Abbreviation)
                .Column("Abbreviation")
                .CustomSqlType("VARCHAR(5)")
                .Index("Province_Abbreviation")
                .Not.Nullable();

            Map(x => x.Name)
                .Column("Name")
                .CustomSqlType("NVARCHAR(50)")
                .Index("Province_Name")
                .Not.Nullable();
        }
    }
}