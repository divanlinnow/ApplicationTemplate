using Domain.Entities.Business;
using FluentNHibernate.Mapping;

namespace ORM.NHibernate.Mappings.Business
{
    internal class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("Orders");

            Id(x => x.ID)
                .Column("ID")
                .CustomSqlType("INT")
                .GeneratedBy.Assigned()
                .Not.Nullable();

            HasOne(x => x.Customer);

            Map(x => x.PlacementDate)
                .Column("PlacementDate")
                .CustomSqlType("DATETIME2(0)")
                .Index("Order_PlacementDate")
                .Not.Nullable();

            HasMany(x => x.Products);

            HasMany(x => x.Services);

            Map(x => x.TrackingNumber)
                .Column("TrackingNumber")
                .CustomSqlType("NVARCHAR(50)")
                .Not.Nullable();

            HasOne(x => x.DeliveryAddress);

            HasOne(x => x.CollectionAddress);

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

            Map(x => x.IsForCollection)
                .Column("IsForCollection")
                .CustomSqlType("BIT")
                .Not.Nullable();

            Map(x => x.IsForDelivery)
                .Column("IsForDelivery")
                .CustomSqlType("BIT")
                .Not.Nullable();

            Map(x => x.IsQuote)
                .Column("IsQuote")
                .CustomSqlType("BIT")
                .Not.Nullable();

            Map(x => x.IsCancelled)
                .Column("IsCancelled")
                .CustomSqlType("BIT")
                .Not.Nullable();

            Map(x => x.IsActive)
                .Column("IsActive")
                .CustomSqlType("BIT")
                .Index("Order_IsActive")
                .Not.Nullable();

            Map(x => x.IsDeleted)
                .Column("IsDeleted")
                .CustomSqlType("BIT")
                .Index("Order_IsDeleted")
                .Not.Nullable();
        }
    }
}