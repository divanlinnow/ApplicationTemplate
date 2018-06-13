using System;

namespace Domain.Entities.Business
{
    public class ServiceOrderItem
    {
        #region Properties

        public virtual Guid OrderId { get; set; }

        public virtual Guid ServiceId { get; set; }

        public virtual decimal Quantity { get; set; }

        #endregion Properties
    }
}