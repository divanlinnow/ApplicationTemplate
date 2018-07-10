using Domain.Entities.Core;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Core
{
    internal class LanguageMap : ClassMap<Language>
    {
        public LanguageMap()
        {
            Table("Languages");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("INT")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            Map(x => x.ISOCode)
                .Column("ISOCode")
                .CustomSqlType("VARCHAR(3)")
                .Index("Language_ISOCode")
                .Not.Nullable();

            Map(x => x.Abbreviation)
                .Column("Abbreviation")
                .CustomSqlType("VARCHAR(5)")
                .Index("Language_Abbreviation")
                .Not.Nullable();

            Map(x => x.Name)
                .Column("Name")
                .CustomSqlType("NVARCHAR(50)")
                .Index("Language_Name")
                .Not.Nullable();
        }
    }
}