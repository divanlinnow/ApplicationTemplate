using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customers");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("INT")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            HasOne(x => x.User);

            //HasMany(x => x.Orders);

            Map(x => x.CreditBlocked)
                .Column("CreditBlocked")
                .CustomSqlType("BIT")
                .Not.Nullable();

            Map(x => x.CreditLimit)
                .Column("CreditLimit")
                .CustomSqlType("DECIMAL")
                .Not.Nullable();

            Map(x => x.AllowancePeriod_Days)
                .Column("AllowancePeriod_Days")
                .CustomSqlType("SMALLINT")
                .Not.Nullable();

            Map(x => x.AllowancePeriod_Months)
                .Column("AllowancePeriod_Months")
                .CustomSqlType("SMALLINT")
                .Not.Nullable();

            Map(x => x.IsPreferredCustomer)
                .Column("IsPreferredCustomer")
                .CustomSqlType("BIT")
                .Not.Nullable();
        }
    }
}