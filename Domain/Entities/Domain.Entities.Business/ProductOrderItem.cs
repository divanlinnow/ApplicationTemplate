using System;

namespace Domain.Entities.Business
{
    public class ProductOrderItem
    {
        #region Properties

        public virtual Guid OrderId { get; set; }

        public virtual Guid ProductId { get; set; }

        public virtual decimal Quantity { get; set; }

        #endregion Properties
    }
}