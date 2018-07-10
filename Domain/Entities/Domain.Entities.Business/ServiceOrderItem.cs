using System;

namespace Domain.Entities.Business
{
    public class ServiceOrderItem
    {
        #region Properties

        public virtual int OrderId { get; set; }

        public virtual int ServiceId { get; set; }

        public virtual decimal Quantity { get; set; }

        #endregion Properties
    }
}