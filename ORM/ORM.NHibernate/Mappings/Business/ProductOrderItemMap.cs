using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class ProductOrderItemMap : ClassMap<ProductOrderItem>
    {
        public ProductOrderItemMap()
        {
            Table("ProductOrderItems");

            //CompositeId()
            //    .KeyProperty(x => x.OrderId)
            //    .KeyReference(x => x.Product.Id);

            //Map(x => x.OrderId)
            //    .Column("OrderId")
            //    .CustomSqlType("INT")
            //    .Not.Nullable();

            //Map(x => x.Product.Id)
            //    .Column("ProductId")
            //    .CustomSqlType("INT")
            //    .Not.Nullable();

            //Map(x => x.Quantity)
            //    .Column("Quantity")
            //    .CustomSqlType("DECIMAL")
            //    .Not.Nullable();
        }
    }
}