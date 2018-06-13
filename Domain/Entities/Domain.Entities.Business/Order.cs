using Domain.Entities.Core;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Business
{
    public class Order : EntityBase
    {
        #region Properties

        public virtual Customer Customer { get; set; }

        public virtual DateTime PlacementDate { get; set; }

        public virtual IList<ProductOrderItem> Products { get; set; }

        public virtual IList<ServiceOrderItem> Services { get; set; }

        public virtual string TrackingNumber { get; set; }

        public virtual Address DeliveryAddress { get; set; }

        public virtual Address CollectionAddress { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual bool IsForCollection { get; set; }

        public virtual bool IsForDelivery { get; set; }

        public virtual bool IsQuote { get; set; }

        public virtual bool IsCancelled { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}