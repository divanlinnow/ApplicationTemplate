using Domain.Models.Core;
using System;
using System.Collections.Generic;

namespace Domain.Models.Business
{
    public class OrderDto : EntityBaseDto
    {
        #region Properties

        public virtual CustomerDto Customer { get; set; }

        public virtual DateTime PlacementDate { get; set; }

        public virtual IList<ProductOrderItemDto> Products { get; set; }

        public virtual IList<ServiceOrderItemDto> Services { get; set; }

        public virtual string TrackingNumber { get; set; }

        public virtual AddressDto DeliveryAddress { get; set; }

        public virtual AddressDto CollectionAddress { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual UserDto CreatedBy { get; set; }

        public virtual DateTime Modified { get; set; }

        public virtual UserDto ModifiedBy { get; set; }

        public virtual bool IsForCollection { get; set; }

        public virtual bool IsForDelivery { get; set; }

        public virtual bool IsQuote { get; set; }

        public virtual bool IsCancelled { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsDeleted { get; set; }

        #endregion Properties
    }
}