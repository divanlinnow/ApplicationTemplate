using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class ServiceOrderItemMap : ClassMap<ServiceOrderItem>
    {
        public ServiceOrderItemMap()
        {
            Table("ServiceOrderItems");

            //CompositeId()
            //    .KeyProperty(x => x.OrderId)
            //    .KeyReference(x => x.Service.Id);

            //Map(x => x.OrderId)
            //    .Column("OrderId")
            //    .CustomSqlType("UNIQUEIDENTIFIER")
            //    .Not.Nullable();

            //Map(x => x.Service.Id)
            //    .Column("ProductId")
            //    .CustomSqlType("UNIQUEIDENTIFIER")
            //    .Not.Nullable();

            //Map(x => x.Quantity)
            //    .Column("Quantity")
            //    .CustomSqlType("DECIMAL")
            //    .Not.Nullable();
        }
    }
}